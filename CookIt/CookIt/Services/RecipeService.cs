using CookIt.Models.Entities;
using CookIt.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookIt.Services
{
    public class RecipeService
    {
        private MapperService _mapperService;

        public RecipeService()
        {
            _mapperService = new MapperService();
        }

        public List<RecipeViewModel> GetRecipeViewModels(List<Recipe> recipesToMap)
        {
            List<RecipeViewModel> mappedRecipes = new List<RecipeViewModel>();
            recipesToMap.ForEach(rec => mappedRecipes.Add(_mapperService.MapRecipe(rec)));

            return mappedRecipes;
        }
    }
}
