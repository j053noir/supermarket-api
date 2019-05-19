using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace supermarket.Models
{
    public class OrderDetails
    {
        [Key, Column(Order = 0)]
        public Guid OrderId { get; set; }

        public virtual Order Order { get; set; }

        [Key, Column(Order = 1)]
        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Amount { get; set; }

        public double Subtotal { get; set; }

    }
}