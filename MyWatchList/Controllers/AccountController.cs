using Microsoft.AspNetCore.Mvc;
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
    public class AccountController : Controller
    {
        private readonly MyWatchListContext _context;
        public Gebruiker gebruiker;
        AccountViewModel vm = new AccountViewModel();

        public AccountController(MyWatchListContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            gebruiker = await _context.Gebruikers.FindAsync(id);
            vm = new AccountViewModel()
            {
                Voornaam = gebruiker.Voornaam,
                Achternaam = gebruiker.Achternaam,
                Email = gebruiker.Email,
                Geboortedatum = gebruiker.Geboortedatum,
                GebruikerId = id
            };
            return View(vm);

        }

        public async Task<IActionResult> Aanpassen(int id, [Bind("Voornaam, Achternaam, Email, Wachtwoord, Geboortedatum")] Gebruiker gebruiker)
        {
            gebruiker.GebruikerID = id;
            vm.GebruikerId = gebruiker.GebruikerID;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gebruiker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GebruikerExists(gebruiker.GebruikerID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
               return RedirectToAction(nameof(Index), new { id = gebruiker.GebruikerID});
            }
            return View(vm);
        }
        private bool GebruikerExists(int id)
        {
            Gebruiker gebruiker = _context.Gebruikers.Find(id);
            if (gebruiker != null)
            {
                return true;
            }
            return false;
        }
    }
}
