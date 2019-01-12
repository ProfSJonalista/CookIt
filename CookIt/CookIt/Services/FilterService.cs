using CookIt.Models.Entities;
using CookIt.Models.ViewModels;
using CookIt.Repository;
using CookIt.Resources.strings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CookIt.Services
{
    public class FilterService
    {
        private string _cultureInfo = Strings.Culture.ToString();
        private RecipeService _recipeService;
        private DatabaseRepository _databaseRepository;

        public FilterService()
        {
            _recipeService = new RecipeService();
            _databaseRepository = new DatabaseRepository();
        }

        internal List<RecipeViewModel> GetFilteredRecipes(List<IngredientChooseViewModel> filterList)
        {
            List<Recipe> recipeEntitiesToFilter = _databaseRepository.GetRecipes(_cultureInfo);

            if (filterList != null && filterList.Count > 0)
            {
                filterList.ForEach(filter =>
                {
                    recipeEntitiesToFilter = recipeEntitiesToFilter
                    .Where(recipe => recipe.Ingredients
                                     .Any(ingredient =>
                                     {
                                         var match = ingredient.IngredientResourceKey.Equals(filter.ResourceKey);
                                         if (match)
                                             ingredient.ForLater = true;

                                         return match;
                                     })).ToList();
                });
            }

            return _recipeService.GetRecipeViewModels(recipeEntitiesToFilter);
        }

        internal List<RecipeViewModel> GetFilteredRecipes(bool userFavourite)
        {
            List<Recipe> recipeEntitiesToFilter = _databaseRepository.GetRecipes(_cultureInfo);

            recipeEntitiesToFilter = recipeEntitiesToFilter.Where(recipe => recipe.UserFavourite == userFavourite).ToList();

            return _recipeService.GetRecipeViewModels(recipeEntitiesToFilter);
        }

        internal List<RecipeViewModel> GetUnfilteredRecipes()
        {
            List<Recipe> recipeEntitiesToFilter = _databaseRepository.GetRecipes(_cultureInfo);
            return _recipeService.GetRecipeViewModels(recipeEntitiesToFilter);
        }
    }
}
