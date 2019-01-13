using CookIt.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CookIt.Services.Helpers
{
    public class RecipeServiceHelper
    {
        public List<int> GetIngredientIds(List<IngredientViewModel> ingredients)
        {
            return ingredients.Where(x => x.ForLater).Select(y => y.Id).ToList();
        }
    }
}
