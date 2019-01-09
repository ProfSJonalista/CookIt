using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Text;
using CookIt.Models.ViewModels;
using CookIt.Resources.strings;

namespace CookIt.Services
{
    public class IngredientService
    {
        public List<IngredientViewModel> GetIngredientList()
        {
            List<IngredientViewModel> ingredientVMList = new List<IngredientViewModel>();

            ResourceManager ingredientResource = new ResourceManager(typeof(Ingredients));

            ResourceSet resourceSet = ingredientResource.GetResourceSet(Ingredients.Culture, true, true);
            foreach (DictionaryEntry entry in resourceSet)
            {
                ingredientVMList.Add(new IngredientViewModel()
                {
                    ResourceKey = entry.Key.ToString(),
                    Name = entry.Value.ToString(),
                    Filter = false
                });
            }

            return ingredientVMList;
        }
    }
}
