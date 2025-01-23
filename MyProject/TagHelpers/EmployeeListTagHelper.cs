using Microsoft.AspNetCore.Razor.TagHelpers;
using MyProject.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyProject.TagHelpers
{
    [HtmlTargetElement("employee-list")]
    public class EmployeeListTagHelper:TagHelper
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id=1,
                Firstname="Aysel",
                Lastname="Aliyeva",
                CityId=1,
                Point=10
            },
            new Employee
            {
                Id=2,
                Firstname="Leyla",
                Lastname="Mammadova",
                CityId=77,
                Point=98
            },
            new Employee
            {
                Id=3,
                Firstname="Huseyn",
                Lastname="Huseynzade",
                CityId=1,
                Point=90
            },
        };

        private const string SortAttribute = "sort";
        [HtmlAttributeName(SortAttribute)]
        public string Sort { get; set; }

        private const string CountAttribute = "count";
        [HtmlAttributeName(CountAttribute)]
        public int Count { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "section";
            StringBuilder sb=new StringBuilder();

            var query = employees.Take(Count);

            if (Sort == "a-z")
            {
                query = query.OrderBy(e => e.Firstname).ToList();
            }
            else if (Sort == "z-a")
            {
                query=query.OrderByDescending(e=>e.Firstname).ToList();
            }

            foreach (var item in query)
            {
                sb.AppendFormat("<h2><a href='/home/Employee/{0}'>{1}</a></h2>", item.Id, item.Firstname);
            }

            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
