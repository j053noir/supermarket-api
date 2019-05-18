using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace supermarket.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Index(IsUnique = true)]
        public string Reference { get; set; }

        public string Name { get; set; }

        public double Cost { get; set; }
    }
}