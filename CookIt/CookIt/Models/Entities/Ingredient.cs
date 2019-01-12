﻿using SQLite;
using SQLiteNetExtensions.Attributes;

namespace CookIt.Models.Entities
{
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
}