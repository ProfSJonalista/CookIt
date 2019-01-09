using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace CookIt.Models.Entities
{
    public class Step
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [ForeignKey(typeof(Recipe))]
        public int RecipeId { get; set; }
        public string Description { get; set; }
        public List<TimeSpan> TimeSpans { get; set; }
    }
}