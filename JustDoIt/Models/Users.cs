using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JustDoIt.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string SecondName { get; set; }

        public int Age { get; set; }
        
        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public List<Notes> Notest { get; set; }

        public Users() { }

    }
}