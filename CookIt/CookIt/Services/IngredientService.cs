﻿using System;
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
        //returns list with ingredient names for IngredientChoosePage
        public List<IngredientChooseViewModel> GetIngredientList()
        {
            List<IngredientChooseViewModel> ingredientVMList = new List<IngredientChooseViewModel>();

            ResourceManager ingredientResource = new ResourceManager(typeof(Ingredients));
            ResourceSet resourceSet = ingredientResource.GetResourceSet(Ingredients.Culture, true, true);

            foreach (DictionaryEntry entry in resourceSet)
            {
                ingredientVMList.Add(new IngredientChooseViewModel()
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
