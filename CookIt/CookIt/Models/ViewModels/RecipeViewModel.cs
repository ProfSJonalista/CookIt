using System;
using System.Collections.Generic;
using System.Text;

namespace CookIt.Models.ViewModels
{
    public class RecipeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NoOfPortions { get; set; }
        public string ImageName { get; set; }
        public string PreparationTime { get; set; }
        public bool UserFavourite { get; set; }
        public List<StepViewModel> Steps { get; set; }
        public List<IngredientViewModel> Ingredients { get; set; }
    }

    public class IngredientViewModel
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public string Name { get; set; }
        public bool ForLater { get; set; }
        public string IngredientResourceKey { get; set; }
    }

    public class StepViewModel
    {
        public int Id { get; set; }
        public int Recipe { get; set; }
        public int StepNumber { get; set; }
        public string Description { get; set; }
        public List<TimeSpan> TimeSpans { get; set; }
    }
}
