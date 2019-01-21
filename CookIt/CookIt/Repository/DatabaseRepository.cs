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
        //Inserts full recipe into SQLiteDB
        public void Insert(Recipe recipe)
        {
            var recipeId = InsertToDB(recipe); //gets recipeId

            //binds recipeId to each ingredient and inserts into db
            recipe.Ingredients.ForEach(ingredient =>
            {
                ingredient.Recipe = recipe.Id;
                InsertToDB(ingredient);
            });

            //binds recipeId to each step and inserts into db
            recipe.Steps.ForEach(step =>
            {
                step.Recipe = recipe.Id;
                InsertToDB(step);
            });

            //resets id
            recipeId = 0;
        }

        //inserts object of type T to db
        //generic method
        private int InsertToDB<T>(T ObjectToInsert)
        {
            using (var db = new SQLiteConnection(App.DatabaseLocation))
            {
                db.CreateTable<T>();
                return db.Insert(ObjectToInsert, typeof(T));
            }
        }

        //checks if db is empty
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

        //gets recipes based on current culture
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

        //updates ingredient list
        internal void SaveIngredientsForLater(List<Ingredient> ingredients)
        {
            ingredients.ForEach(x => Update(x));
        }

        //updates object of type T
        //generic method
        public void Update<T>(T objectToUpdate)
        {
            using (var db = new SQLiteConnection(App.DatabaseLocation))
            {
                db.Update(objectToUpdate);
            }
        }
    }
}
