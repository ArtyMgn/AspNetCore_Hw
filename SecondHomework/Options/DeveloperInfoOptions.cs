using System.ComponentModel.DataAnnotations;

namespace SecondHomework.Options
{
    public class DeveloperInfoOptions
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}