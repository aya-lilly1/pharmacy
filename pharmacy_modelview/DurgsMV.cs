using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_modelview
{
    public class DurgsMV
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
