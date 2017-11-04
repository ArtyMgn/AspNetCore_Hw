using System.ComponentModel.DataAnnotations;

namespace SecondHomework.Models
{
    public class Student
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Surname { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
