using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class SystemUser : AuditableEntity<int>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [MaxLength(10)]
        public string Phone { get; set; }

        public bool IsAdmin { get; set; }
    }
}
