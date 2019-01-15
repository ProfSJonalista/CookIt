using CookIt.Models.Entities;
using CookIt.Models.ViewModels;
using CookIt.Repository;
using CookIt.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookIt.Services
{
    public class RecipeService
    {
        private MapperService _mapperService;
        private DatabaseRepository _databaseRepository;
        private RecipeServiceHelper _recipeServiceHelper;

        public RecipeService()
        {
            _mapperService = new MapperService();
            _databaseRepository = new DatabaseRepository();
            _recipeServiceHelper = new RecipeServiceHelper();
        }

        public List<RecipeViewModel> GetRecipeViewModels(List<Recipe> recipesToMap)
        {
            List<RecipeViewModel> mappedRecipes = new List<RecipeViewModel>();
            recipesToMap.ForEach(rec => mappedRecipes.Add(_mapperService.MapRecipe(rec)));

            return mappedRecipes;
        }

        public void SaveIngredientsForLater(RecipeViewModel recipeViewModel)
        {
            _databaseRepository.SaveIngredientsForLater(_mapperService.MapIngredientList(recipeViewModel.Ingredients));
        }

        internal void Update(RecipeViewModel recipe)
        {
            _databaseRepository.Update(_mapperService.MapRecipe(recipe));
        }
    }
}
