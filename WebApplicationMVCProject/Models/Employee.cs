using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVCProject.Models
{
    public class Employee
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Employee Full Name")]
        [MaxLength(40)]
        [MinLength(2)]
        [DataType(DataType.Text)]
        public string? Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email_ID { get; set; }

        [Required]
        [Display(Name ="Create Password")]
        [DataType(DataType.Password)]
        public string? Create_Password { get; set; }

        [Required]
        [Display(Name ="Mobile No")]
        public string? Mobile_No { get; set; }

        [Required]
        [Range(18,60)]
        public int Age { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOJ { get; set; }

        [ScaffoldColumn(false)]
        public int IsActive { get; set; }
    }
}
