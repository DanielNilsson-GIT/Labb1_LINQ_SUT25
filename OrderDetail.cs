using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_LINQ_SUT25
{
    internal class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }

        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
       
        //navigationprops
        public Order? Order { get; set; }

        public Product Product { get; set; }
       
    }
}
