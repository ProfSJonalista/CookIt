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
    //service to filter recipe
    public class FilterService
    {
        private readonly string _cultureInfo = Strings.Culture.ToString();
        private RecipeService _recipeService;
        private DatabaseRepository _databaseRepository;

        public FilterService()
        {
            _recipeService = new RecipeService();
            _databaseRepository = new DatabaseRepository();
        }

        //returns recipes base on a provided filter list
        internal List<RecipeViewModel> GetFilteredRecipes(List<IngredientChooseViewModel> filterList)
        {
            List<Recipe> recipeEntitiesToFilter = _databaseRepository.GetRecipes(_cultureInfo);

            if (filterList != null && filterList.Count > 0)
            {
                //for each filter, recipes are checked if they match requirements
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

            //returns recipes mapped to view model
            return _recipeService.GetRecipeViewModels(recipeEntitiesToFilter);
        }

        //returns recipes that are saved for later
        internal List<RecipeViewModel> GetSavedForLaterRecipes(bool savedForLater)
        {
            List<Recipe> recipeEntitiesToFilter = _databaseRepository.GetRecipes(_cultureInfo);

            recipeEntitiesToFilter = recipeEntitiesToFilter.Where(recipe => 
                                                recipe.Ingredients.Any(ingredient => ingredient.ForLater == savedForLater)).ToList();

            return _recipeService.GetRecipeViewModels(recipeEntitiesToFilter);
        }

        //returns unfiltered recipes
        internal List<RecipeViewModel> GetUnfilteredRecipes()
        {
            List<Recipe> recipeEntitiesToFilter = _databaseRepository.GetRecipes(_cultureInfo);
            return _recipeService.GetRecipeViewModels(recipeEntitiesToFilter);
        }
    }
}
