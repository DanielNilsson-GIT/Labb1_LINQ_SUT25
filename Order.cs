using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_LINQ_SUT25
{
    internal class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }

        public int TotalAmount { get; set; }
        public string Status { get; set; }
        
        //navigation prop
        public Customer Customer { get; set; }
    }
}
