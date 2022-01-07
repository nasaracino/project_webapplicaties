using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyWatchList.Data;
using MyWatchList.Models;
using MyWatchList.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWatchList.Controllers
{
    public class RegistrerenController : Controller
    {
        private readonly MyWatchListContext _context;
        public List<Gebruiker> gebruikers;
        RegistrerenViewModel vm = new RegistrerenViewModel();
        public RegistrerenController(MyWatchListContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            vm = new RegistrerenViewModel();
            gebruikers = await _context.Gebruikers.ToListAsync();
            return View(vm);
        }

        public async Task<IActionResult> Registreren([Bind("Voornaam, Achternaam, Email, Geboortedatum, Wachtwoord")] Gebruiker gebruiker)
        {
            if (ModelState.IsValid && !gebruikers.Contains(gebruiker))
            {
                vm = new RegistrerenViewModel()
                {
                    Voornaam = gebruiker.Voornaam,
                    Achternaam = gebruiker.Achternaam,
                    Email = gebruiker.Email,
                    Geboortedatum = gebruiker.Geboortedatum,
                    Wachtwoord = gebruiker.Wachtwoord,
                    IsBeheerder = false,
                    Gebruiker = gebruiker,
            };
                _context.Add(gebruiker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
