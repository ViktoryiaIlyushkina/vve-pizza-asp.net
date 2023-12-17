using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using VVE_Pizza.Enums;

namespace VVE_Pizza.Models
{
    public class History
    {
        public string UserName { get; set; }
        public string PizzaName { get; set; }
        public byte[] Photo { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime OrderTime { get; set; } 
    }
}
