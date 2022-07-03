using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Dev
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Avatar { get; set; }
        public string? Squad { get; set; }
        public string? Login { get; set; }
        public string? Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}