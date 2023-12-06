using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecipeManager.Data;
using RecipeManager.Models;

namespace RecipeManager.Pages.Recipes
{
    public class IndexModel : PageModel
    {
        private readonly RecipeManager.Data.RecipeManagerContext _context;

        public IndexModel(RecipeManager.Data.RecipeManagerContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Type { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? FoodType { get; set; }
        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Recipe
                                            orderby m.Type
                                            select m.Type;

            var movies = from m in _context.Recipe
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(FoodType))
            {
                movies = movies.Where(x => x.Type == FoodType);
            }
            Type = new SelectList(await genreQuery.Distinct().ToListAsync());
            Recipe = await movies.ToListAsync();
        }
    }
}
