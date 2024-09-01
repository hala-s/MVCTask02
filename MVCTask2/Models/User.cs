using System.ComponentModel.DataAnnotations;

namespace MVCTask2.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAT { get; set; }
    }
}
