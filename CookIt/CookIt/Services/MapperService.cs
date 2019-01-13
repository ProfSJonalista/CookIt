using CookIt.Models.Entities;
using CookIt.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CookIt.Services
{
    public class MapperService
    {
        private Helpers.Converter _converter;

        public MapperService()
        {
            _converter = new Helpers.Converter();
        }

        public RecipeViewModel MapRecipe(Recipe recipe)
        {
            return new RecipeViewModel()
            {
                Id = recipe.Id,
                Name = recipe.Name,
                NoOfPortions = recipe.NoOfPortions,
                ImageName = recipe.ImageName,
                PreparationTime = recipe.PreparationTime,
                UserFavourite = recipe.UserFavourite,
                Steps = MapStepList(recipe.Steps),
                Ingredients = MapIngredientList(recipe.Ingredients)
            };
        }

        private List<StepViewModel> MapStepList(List<Step> steps)
        {
            List<StepViewModel> stepViewModels = new List<StepViewModel>();
            steps.ForEach(step => stepViewModels.Add(MapStep(step)));

            return stepViewModels;
        }

        private StepViewModel MapStep(Step step)
        {
            return new StepViewModel()
            {
                Id = step.Id,
                Recipe = step.Recipe,
                StepNumber = step.StepNumber,
                Description = step.Description,
                TimeSpans = string.IsNullOrEmpty(step.TimeSpans) ? new List<TimeSpan>() : _converter.ConvertStringToTimeSpanList(step.TimeSpans)
            };
        }

        private List<IngredientViewModel> MapIngredientList(List<Ingredient> ingredients)
        {
            List<IngredientViewModel> ingredientViewModels = new List<IngredientViewModel>();
            ingredients.ForEach(ingredient => ingredientViewModels.Add(MapIngredient(ingredient)));

            return ingredientViewModels;
        }

        private IngredientViewModel MapIngredient(Ingredient ingredient)
        {
            return new IngredientViewModel()
            {
                Id = ingredient.Id,
                RecipeId = ingredient.Recipe,
                Name = ingredient.Name,
                ForLater = ingredient.ForLater,
                IngredientResourceKey = ingredient.IngredientResourceKey
            };
        }

        internal List<Ingredient> MapIngredientList(List<IngredientViewModel> ingredientsToMap)
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            ingredientsToMap.ForEach(x => ingredients.Add(MapIngredient(x)));

            return ingredients;
        }

        private Ingredient MapIngredient(IngredientViewModel x)
        {
            return new Ingredient()
            {
                Id = x.Id,
                Name = x.Name,
                Recipe = x.RecipeId,
                ForLater = x.ForLater,
                IngredientResourceKey = x.IngredientResourceKey
            };
        }
    }
}
