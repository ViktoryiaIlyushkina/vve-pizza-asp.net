using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VVE_Pizza.Context;
using VVE_Pizza.Models;
using VVE_Pizza.ViewModels;

namespace VVE_Pizza.Controllers
{
    public class PizzaController : Controller
    {
        private readonly ApplicationContext _applicationContext;

        public PizzaController(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task<IActionResult> ShowAsync(int id)
        {
            var selectedPizza = await _applicationContext.Pizzas.FirstOrDefaultAsync(pizza => pizza.Id == id);

            if (selectedPizza == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new PizzaViewModel
            {
                Id = selectedPizza.Id,
                Name = selectedPizza.Name,
                Description = selectedPizza.Description,
                Price = selectedPizza.Price,
                Size = selectedPizza.Size,
                Photo = selectedPizza.Photo
            };


            return View(model);
        }
    }
}
