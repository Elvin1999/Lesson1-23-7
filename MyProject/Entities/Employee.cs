using System.ComponentModel.DataAnnotations;

namespace MyProject.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int Point { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(10,ErrorMessage = "Length should be more than 10")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Surname is required.")]
        public string Lastname { get; set; }
    }
}
