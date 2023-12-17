using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Numerics;
using VVE_Pizza.Context;
using VVE_Pizza.Enums;
using VVE_Pizza.Models;
using VVE_Pizza.ViewModels;

namespace VVE_Pizza.Controllers
{
    [Authorize]
    public class HistoryController : Controller
    {
        private readonly ApplicationContext _applicationContext;
        private readonly UserManager<User> _userManager;

        public HistoryController(
            ApplicationContext applicationContext,
            UserManager<User> userManager)
        {
            _applicationContext = applicationContext;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> ShowHistoryAsync()
        {
            var orders = await _applicationContext.Orders.ToListAsync();
            var pizzas = await _applicationContext.Pizzas.ToListAsync();


            var list = new List<History>();
            var user = await _userManager.GetUserAsync(HttpContext.User);

            foreach (var order in orders)
            {
                var orderedPizza = await _applicationContext.Pizzas.FirstOrDefaultAsync(pizza => pizza.Id == order.PizzaId);
                var model = new History
                {
                    UserName = user.Name,
                    PizzaName = orderedPizza.Name,
                    Photo = orderedPizza.Photo,
                    DeliveryType = order.DeliveryType,
                    Email = order.Email,
                    Address = order.Address,
                    Phone = order.Phone,
                    Amount = order.Amount,
                    OrderTime = DateTime.Now,

                };

                if (order.Email == user.Email)
                {
                    list.Add(model);
                }
            }

            return View(list);
        }
    }
}
