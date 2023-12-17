using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VVE_Pizza.Context;
using VVE_Pizza.Models;
using VVE_Pizza.ViewModels;

namespace VVE_Pizza.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationContext _applicationContext;
        private readonly UserManager<User> _userManager;

        public OrderController(
            ApplicationContext applicationContext,
            UserManager<User> userManager)
        {
            _applicationContext = applicationContext;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmAsync(int pizzaId)
        {
            var selectedPizza = await _applicationContext.Pizzas.FirstOrDefaultAsync(pizza => pizza.Id == pizzaId);

            if (selectedPizza == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new OrderViewModel
            {
                PizzaId = selectedPizza.Id,
                PizzaName = selectedPizza.Name,
                Amount = selectedPizza.Price
            };


            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                model.Email = user.Email;
                model.Address = user.Address;
                model.Phone = user.Phone;
            }

            ViewBag.PizzaPhoto = selectedPizza.Photo;

            return View(model);
        }


        [HttpPost]
        public async Task<ActionResult> ConfirmAsync(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    PizzaId = model.PizzaId,
                    DeliveryType = model.DeliveryType,
                    Email = model.Email,
                    Address = model.Address,
                    Phone = model.Phone,
                    Amount = model.Amount

                };

                await _applicationContext.Orders.AddAsync(order);
                await _applicationContext.SaveChangesAsync();

                return RedirectToAction("Index", "Home");

            }

            var selectedPizza = await _applicationContext.Pizzas.FirstOrDefaultAsync(pizza => pizza.Id == model.PizzaId);
            ViewBag.PizzaPhoto = selectedPizza.Photo;

            return View(model);
        }
    }
}
