using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VVE_Pizza.Context;
using VVE_Pizza.Models;
using VVE_Pizza.ViewModels;

namespace VVE_Pizza.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationContext _applicationContext;

        public AdminController(ApplicationContext applicationContext) 
        {
            _applicationContext = applicationContext;
        }

        [HttpGet]
        public IActionResult AddPizza()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddPizza(PizzaAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var pizza = new Pizza

                {
                    Name = model.Name,
                    Description = model.Description,
                    Size = model.Size,
                    Price = model.Price,

                };

                if (model.Photo != null)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(model.Photo.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)model.Photo.Length);
                    }
                    pizza.Photo = imageData;
                }

                await _applicationContext.Pizzas.AddAsync(pizza);
                await _applicationContext.SaveChangesAsync();

                return RedirectToAction("Index", "Home");

            }
            return View(model);
        }
    }

   
}
