using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

//Recipe entities
namespace CookIt.Models.Entities
{
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ResourceCultureInfo { get; set; }
        public string Name { get; set; }
        public int NoOfPortions { get; set; }
        public string ImageName { get; set; }
        public string PreparationTime { get; set; }
        [OneToMany]
        public List<Step> Steps { get; set; }
        [OneToMany]
        public List<Ingredient> Ingredients { get; set; }
    }

    public class Ingredient
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(Recipe))]
        public int Recipe { get; set; }
        public string Name { get; set; }
        public bool ForLater { get; set; }
        public string IngredientResourceKey { get; set; }
    }

    public class Step
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(Recipe))]
        public int Recipe { get; set; }
        public int StepNumber { get; set; }
        public string Description { get; set; }
        public string TimeSpans { get; set; }
    }
}
