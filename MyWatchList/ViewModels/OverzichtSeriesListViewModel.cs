using MyWatchList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWatchList.ViewModels
{
    public class OverzichtSeriesListViewModel
    {
        public string OverzichtSeriesSearch { get; set; }
        public List<Serie> Series { get; set; }
    }
}
