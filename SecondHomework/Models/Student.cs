using System.ComponentModel.DataAnnotations;

namespace SecondHomework.Models
{
    public class Student
    {
        [Display(Name = "Идентификатор")]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Имя")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [Display(Name = "Фамилия")]
        [Required]
        [StringLength(100)]
        public string Surname { get; set; }

        [Display(Name = "Адрес электронной почты")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
