using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWatchList.ViewModels;
using MyWatchList.Models;
using MyWatchList.Data;
using Microsoft.EntityFrameworkCore;

namespace MyWatchList.Controllers
{
    public class OverzichtSeriesController : Controller
    {

        public List<Serie> series;
        private readonly MyWatchListContext _context;
        OverzichtSeriesListViewModel overzichtVM = new OverzichtSeriesListViewModel();
        SeriesDetailViewModel svm = new SeriesDetailViewModel();
        public Serie serie = new Serie();

        public async Task<IActionResult> Index()
        {
            series = await _context.Series.ToListAsync();
            overzichtVM.Series = series;
            return View(overzichtVM);
        }

        public OverzichtSeriesController(MyWatchListContext context)
        {
            series = new List<Serie>();
            _context = context;
        }

        public async Task<IActionResult> Search(OverzichtSeriesListViewModel viewModel)
        {
            series = await _context.Series.ToListAsync();
            if (!string.IsNullOrEmpty(viewModel.OverzichtSeriesSearch))
            {
                viewModel.Series = series.Where(x => x.Titel.ToLower().Contains(viewModel.OverzichtSeriesSearch.ToLower())).ToList();
            }
            else
            {
                viewModel.Series = series;
            }
            return View("Index", viewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            svm.SerieId = id;
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                serie = await _context.Series.FindAsync(id);
                _context.Remove(serie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            serie = await _context.Series.FindAsync(id);
            serie.SpeeltIn = await _context.SpeeltIns.ToListAsync();
            List<Acteur> acteurs = await _context.Acteurs.ToListAsync();

            if (id == null)
            {
                return NotFound();
            }


            List<SpeeltIn> rollen = new List<SpeeltIn>();
            List<Acteur> acteursInSerie = new List<Acteur>();
            foreach (var rol in serie.SpeeltIn)
            {
                if (rol.SerieID == id)
                {
                    rollen.Add(rol);
                     int acteurId = rol.ActeurID;
                    foreach (var acteur in acteurs)
                    {
                        if (acteurId == acteur.ActeurID)
                        {
                            acteursInSerie.Add(acteur);
                        }
                    }
                }
            }
            if (serie == null)
            {
                return NotFound();
            }

            svm = new SeriesDetailViewModel()
            {
                Titel = serie.Titel,
                AantalSeizoenen = serie.AantalSeizoenen,
                MinimumLeeftijd = serie.MinimumLeeftijd,
                JaarVanUitkomst = serie.JaarVanUitkomst,
                Hoofdrollen = rollen,
                Acteurs = acteursInSerie,
                SerieId = id
            };

            return View(svm);
        }
    }
}
