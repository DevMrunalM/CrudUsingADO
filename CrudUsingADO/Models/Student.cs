using System.ComponentModel.DataAnnotations;

namespace CrudUsingADO.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [Required]
        [Display(Name = "Student Name")]
        public string? Name { get; set; }


        [Required]
        [Display(Name = "Enter Email")]
        [DataType(DataType.EmailAddress)]

        public string? Email { get; set; }


        [Required]
        [Display(Name = "Enter Course")]
        public string? Course { get; set; }

    }
}
