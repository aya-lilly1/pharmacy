using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_modelview
{
    public class TempOrderMV
    {
        public int Id { get; set; }
        public int DurgId { get; set; }
        public string DurgName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderAt { get; set; } = DateTime.Now;
        //public string UserId { get; set; }


    }
}
