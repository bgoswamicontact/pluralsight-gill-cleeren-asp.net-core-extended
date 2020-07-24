using BethenysPieShop.Models;
using BethenysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BethenysPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            var pieslistViewModel = new PiesListViewModel()
            {
                Pies = string.IsNullOrEmpty(category)? _pieRepository.AllPies : _pieRepository.AllPies.Where(x => x.Category.CategoryName == category),
                CurrentCategory = string.IsNullOrEmpty(category)  ? "All pies" : category
            };
            return View(pieslistViewModel);
        }
        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();
            return View(pie);
        }
    }
}