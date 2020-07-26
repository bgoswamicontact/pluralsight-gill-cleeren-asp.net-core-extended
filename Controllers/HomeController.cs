using BethenysPieShop.Models;
using BethenysPieShop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new ErrorViewModel{ 
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}