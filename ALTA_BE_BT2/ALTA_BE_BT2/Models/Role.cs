using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALTA_BE_BT2.Models
{
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        public string? RoleName { get; set; }

         // Quan hệ 1-nhiều với User
        public ICollection<User> Users { get; set; } = new List<User>();

        // Quan hệ 1-nhiều với AllowAccess
        public ICollection<AllowAccess> AllowAccesses { get; set; } = new List<AllowAccess>();

    }
}