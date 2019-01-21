using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CookIt.Services.Helpers
{
    public class Converter
    {
        //Converts string to TimeSpan list
        public List<TimeSpan> ConvertStringToTimeSpanList(string timeSpanAsString)
        {
            List<TimeSpan> timeSpansToReturn = new List<TimeSpan>();
            List<double> timeSpansAsDouble = timeSpanAsString.Split(',').Select(double.Parse).ToList();
            
            timeSpansAsDouble.ForEach(timeSpan => timeSpansToReturn.Add(TimeSpan.FromMilliseconds(timeSpan)));

            return timeSpansToReturn;
        }
    }
}
