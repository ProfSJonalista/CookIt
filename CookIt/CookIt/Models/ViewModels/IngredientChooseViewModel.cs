using System;
using System.Collections.Generic;
using System.Text;

namespace CookIt.Models.ViewModels
{
    //view model for IngredientChoosePage
    public class IngredientChooseViewModel
    {
        public string ResourceKey { get; set; }
        public string Name { get; set; }
        public bool Filter { get; set; }
    }
}
