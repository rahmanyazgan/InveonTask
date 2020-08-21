using System.ComponentModel.DataAnnotations;

namespace Entities.Concrete
{
    public class SystemUser : AuditableEntity<long>
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
        public string Password { get; set; }

        public string Phone { get; set; }

        public bool IsAdmin { get; set; }
    }
}
