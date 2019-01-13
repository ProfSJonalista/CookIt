using CookIt.Models.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CookIt.Models.ViewModels;

namespace CookIt.Repository 
{
    public class DatabaseRepository
    {
        public void Insert(Recipe recipe)
        {
            var recipeId = InsertToDB(recipe);

            recipe.Ingredients.ForEach(ingredient =>
            {
                ingredient.Recipe = recipe.Id;
                InsertToDB(ingredient);
            });

            recipe.Steps.ForEach(step =>
            {
                step.Recipe = recipe.Id;
                InsertToDB(step);
            });

            recipeId = 0;
        }

        private int InsertToDB<T>(T ObjectToInsert)
        {
            using (var db = new SQLiteConnection(App.DatabaseLocation))
            {
                db.CreateTable<T>();
                return db.Insert(ObjectToInsert, typeof(T));
            }
        }

        public bool CheckIfDatabaseIsEmpty()
        {
            using (var db = new SQLiteConnection(App.DatabaseLocation))
            {
                db.CreateTable<Recipe>();
                db.CreateTable<Ingredient>();
                db.CreateTable<Step>();
                var recipes = db.Table<Recipe>().Where(rec => rec.ResourceCultureInfo.Equals("pl")).ToList();

                return recipes == null || recipes.Count == 0;
            }
        }

        internal List<Recipe> GetRecipes(string cultureInfo)
        {
            List<Recipe> recipesToReturn = new List<Recipe>();

            using (var db = new SQLiteConnection(App.DatabaseLocation))
            {
                recipesToReturn = db.Table<Recipe>().Where(recipe => recipe.ResourceCultureInfo.Equals(cultureInfo)).ToList();

                recipesToReturn.ForEach(recipe =>
                {
                    recipe.Ingredients = db.Table<Ingredient>().Where(ingredient => ingredient.Recipe == recipe.Id).ToList();
                    recipe.Steps = db.Table<Step>().Where(step => step.Recipe == recipe.Id).ToList();
                });
            }

            return recipesToReturn;
        }

        internal void SaveIngredientsForLater(List<Ingredient> ingredients)
        {
            using (var db = new SQLiteConnection(App.DatabaseLocation))
            {
                ingredients.ForEach(x => db.Update(x));
            }
        }
    }
}
