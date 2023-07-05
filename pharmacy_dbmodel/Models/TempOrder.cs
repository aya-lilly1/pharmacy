using pharmacy_DbModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_dbmodel.Models
{
    public class TempOrder
    {
        public int  Id { get; set; }
        public int DurgId { get; set; }
        public string DurgName { get; set; } =string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderAt { get; set; }
        public string UserId { get; set; }


        [ForeignKey(nameof(UserId))]
        public ApplicationUser applicationUser { get; set; }
    }
}
