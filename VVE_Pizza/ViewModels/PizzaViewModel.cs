using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using VVE_Pizza.Enums;

namespace VVE_Pizza.ViewModels
{
    public class PizzaViewModel
    {
        public int Id { get; set; }

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
        public byte[] Photo { get; set; }

        [Required]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
    }
}
