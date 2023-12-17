using VVE_Pizza.Enums;

namespace VVE_Pizza.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public decimal Amount { get; set; }      
    }
}
