using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

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
}
