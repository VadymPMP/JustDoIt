using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace JustDoIt.Models
{
    public class Users : IdentityUser
    {   
        public string FirstName { get; set; }
        
        public string SecondName { get; set; }

        public int Age { get; set; }

        public List<Notes> Notest { get; set; }

        public Users() { }

    }
}