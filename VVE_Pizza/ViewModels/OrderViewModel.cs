using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using VVE_Pizza.Enums;
using VVE_Pizza.Models;

namespace VVE_Pizza.ViewModels
{
    public class OrderViewModel
    {
        [Required]
        public int PizzaId { get; set; }

        [Required]
        public string PizzaName { get; set; }

        [Required]
        [Display(Name = "Доставка")]
        public DeliveryType DeliveryType { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;
        [Required]
        [Display(Name = "Адрес")]
        public string Address { get; set; } = null!;
        [Required]
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; } = null!;
        [Required]
        [Display(Name = "Сумма")]
        public decimal Amount { get; set; } 
    }
}
