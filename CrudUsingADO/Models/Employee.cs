using System.ComponentModel.DataAnnotations;

namespace CrudUsingADO.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required]
        [Display(Name="Employee Name")]
        public string? Name { get; set; }


        [Required]
        [Display(Name = "Enter Email")]
        [DataType(DataType.EmailAddress)]

        public string? Email { get; set; }


        [Required]
        [Display(Name = "Enter Salary")]
        public double Salary { get; set; }


    }
}
