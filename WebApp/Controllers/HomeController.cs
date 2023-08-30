using InfrastructureLayer.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.owner = _context.Owners.First();
            model.profileItems = _context.ProfileItems.ToList();
            ViewData["Address"] = model.owner.Address;
            return View(model);
        }
    }
}
