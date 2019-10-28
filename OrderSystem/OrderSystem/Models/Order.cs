using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Models
{
    public class Order
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsPaid { get; set; }

        public Order()
        {
            Name = string.Empty;
            Price = 00.00m;
            IsPaid = false;
        }
    }
}
