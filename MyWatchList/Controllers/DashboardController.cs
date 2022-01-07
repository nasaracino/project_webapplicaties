using Microsoft.AspNetCore.Mvc;
using MyWatchList.Data;
using MyWatchList.Models;
using MyWatchList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWatchList.Controllers
{
    public class DashboardController : Controller
    {
        private readonly MyWatchListContext _context;
        public Gebruiker gebruiker;
        public DashboardViewModel vm = new DashboardViewModel(); 

        public DashboardController(MyWatchListContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            vm = new DashboardViewModel();
            vm.GebruikerId = 1;
            return View(vm);
        }
    }
}
