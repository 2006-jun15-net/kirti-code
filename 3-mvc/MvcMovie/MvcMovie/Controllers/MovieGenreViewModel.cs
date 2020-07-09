using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class MovieGenreViewModel
    {
        public List<Movie> Movies { get; set; }
        public SelectList Genres { get; set; }
        public string MovieGenre { get; set; }
        public string SearchString { get; set; }
    }
}