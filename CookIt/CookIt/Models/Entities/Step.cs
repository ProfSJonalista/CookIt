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
        public int Recipe { get; set; }
        public int StepNumber { get; set; }
        public string Description { get; set; }
        public string TimeSpans { get; set; }
    }
}