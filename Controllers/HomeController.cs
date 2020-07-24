using BethenysPieShop.Models;
using BethenysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethenysPieShop.Controllers
{
    public class HomeController : Controller
    {
        private IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }
        public IActionResult Index()
        {
            var pies = new HomeViewModel
            {
                Pies = _pieRepository.PiesOfTheWeek
            };
            return View(pies);
        }
    }
}