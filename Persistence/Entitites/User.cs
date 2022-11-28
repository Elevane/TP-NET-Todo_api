using System.Security.Cryptography;
using System.Text;

namespace Todo.Persistence.Entities

{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string? Token { get; set; }
        public string Email { get; set; }
        public string? Username { get; set; }
        public string? todo { get; set; }
        public string Password { get; set; }
    }
}