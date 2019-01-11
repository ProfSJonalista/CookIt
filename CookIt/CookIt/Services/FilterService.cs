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
        private DatabaseRepository _databaseRepository;

        public FilterService()
        {
            _databaseRepository = new DatabaseRepository();
        }

        internal List<RecipeViewModel> GetFilteredRecipes(List<IngredientChooseViewModel> filterList)
        {
            var cultureInfo = Strings.Culture.ToString();

            List<Recipe> recipeEntitiesToFilter = _databaseRepository.GetRecipes(cultureInfo);

            if(filterList != null && filterList.Count > 0)
            {
                filterList.ForEach(filter =>
                {
                    recipeEntitiesToFilter = recipeEntitiesToFilter
                    .Where(recipe => recipe.Ingredients
                                     .Any(ingredient => ingredient.IngredientResourceKey.Equals(filter.ResourceKey))).ToList();
                });
            }

            throw new NotImplementedException();
        }
    }
}
