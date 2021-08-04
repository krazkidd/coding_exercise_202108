using System;
using System.Collections.Generic;
using System.Linq;
using coding_exercise_202108.ex1;

namespace coding_exercise_202108
{
    class Program1
    {
        static void Main(string[] args)
        {
            IEnumerable<ClimateData> data = new JsonReader<ClimateData>().ReadFromFile(args[0]);

            double minSpread = Double.MaxValue;
            double maxSpread = Double.MinValue;

            // NOTE: I realize I am looping through the data three times. Leaving for readability.

            foreach (ClimateData cd in data)
            {
                minSpread = Math.Min(minSpread, cd.GetSpread());
                maxSpread = Math.Max(maxSpread, cd.GetSpread());
            }

            IEnumerable<ClimateData> datesMinSpread = data.Where(cd => minSpread == cd.GetSpread());
            IEnumerable<ClimateData> datesMaxSpread = data.Where(cd => maxSpread == cd.GetSpread());

            foreach (ClimateData cd in datesMinSpread.Concat(datesMaxSpread))
            {
                Console.WriteLine(cd.ToSpreadString());
            }
        }

    }
}
