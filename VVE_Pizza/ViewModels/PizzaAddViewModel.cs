using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using VVE_Pizza.Enums;

namespace VVE_Pizza.ViewModels
{
    public class PizzaAddViewModel
    {
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Размер")]
        public SizeType Size { get; set; }

        [Required]
        [Display(Name = "Фото")]
        public IFormFile Photo { get; set; }

        [Required]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
    }
}
