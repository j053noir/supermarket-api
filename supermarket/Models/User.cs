using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace supermarket.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
        public string Name { get; set; }

        [Index(IsUnique = true)]
        public Guid Token { get; set; }
    }
}