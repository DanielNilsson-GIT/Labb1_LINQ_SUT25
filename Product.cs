using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb1_LINQ_SUT25
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }

        public int SupplierId { get; set; }

        //navigationProps

        public Category Category { get; set; }
        public Supplier Supplier { get; set; }



    }
}
