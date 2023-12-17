using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using VVE_Pizza.Context;
using VVE_Pizza.Models;
using VVE_Pizza.ViewModels;

namespace VVE_Pizza.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _applicationContext;

        public HomeController(
            ILogger<HomeController> logger,
            ApplicationContext applicationContext)
        {
            _logger = logger;
            _applicationContext = applicationContext;   
        }

        public async Task<IActionResult> IndexAsync()
        {
            var pizzas = await _applicationContext.Pizzas.ToListAsync();
            var list = new List<PizzaViewModel>();

            foreach (var pizza in pizzas)
            {
                var model = new PizzaViewModel
                {
                    Id = pizza.Id,
                    Name = pizza.Name,
                    Description = pizza.Description,
                    Price = pizza.Price,
                    Size = pizza.Size,
                    Photo = pizza.Photo
                };
                list.Add(model);
            }
            return View(list);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}