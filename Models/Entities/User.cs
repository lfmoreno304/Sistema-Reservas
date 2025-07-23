using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ReservaInteligente.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }
        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }

        [Required]
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        public Role? Role { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
    }
}