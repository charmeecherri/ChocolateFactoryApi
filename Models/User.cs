using System.ComponentModel.DataAnnotations;

namespace ChocolateFactoryApi.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public string Role { get; set; }

        public string Email { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; internal set; }
    }
}
