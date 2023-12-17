using System.Drawing;
using VVE_Pizza.Enums;

namespace VVE_Pizza.Models
{
    public class Pizza
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public SizeType Size { get; set; }
        public byte[]? Photo { get; set; }
        public decimal Price { get; set; }
        public List<Order> Orders { get; set; }
    }
}
