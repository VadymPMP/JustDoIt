using System;
using System.ComponentModel.DataAnnotations;

namespace JustDoIt.Models
{
    public class Notes
    {
        [Key]
        public int Id { get; set; }
        
        public DateTime Date { get; set; }

        public string UserId { get; set; }

        public Users User { get; set; }

        
        public string Note { get; set; }

        public Notes() { }
    }
}