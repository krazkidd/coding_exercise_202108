using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using coding_exercise_202108.ex2;

namespace coding_exercise_202108
{
    class Program2
    {
        static void Main(string[] args)
        {
            IEnumerable<ClubData> data = new JsonReader<ClubData>().ReadFromFile(args[0]);

            int minSpread = Int32.MaxValue;
            int maxSpread = Int32.MinValue;

            // NOTE: I realize I am looping through the data three times. Leaving for readability.

            foreach (ClubData cd in data)
            {
                minSpread = Math.Min(minSpread, cd.GetSpread());
                maxSpread = Math.Max(maxSpread, cd.GetSpread());
            }

            IEnumerable<ClubData> clubsMinSpread = data.Where(cd => minSpread == cd.GetSpread());
            IEnumerable<ClubData> clubsMaxSpread = data.Where(cd => maxSpread == cd.GetSpread());

            foreach (ClubData cd in clubsMinSpread.Concat(clubsMaxSpread))
            {
                Console.WriteLine(cd.ToSpreadString());
            }
        }

    }
}
