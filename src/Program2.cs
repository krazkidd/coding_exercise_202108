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
            IEnumerable<ClubData> data = ReadData(args[0]);

            int minSpread = Int32.MaxValue;
            int maxSpread = Int32.MinValue;

            // NOTE: I realize I am looping through the data three times. Leaving for readability.

            foreach (ClubData cd in data)
            {
                minSpread = Math.Min(minSpread, cd.GetGoalSpread());
                maxSpread = Math.Max(maxSpread, cd.GetGoalSpread());
            }

            IEnumerable<ClubData> clubsMinSpread = data.Where(cd => minSpread == cd.GetGoalSpread());
            IEnumerable<ClubData> clubsMaxSpread = data.Where(cd => maxSpread == cd.GetGoalSpread());

            foreach (ClubData cd in clubsMinSpread.Concat(clubsMaxSpread))
            {
                Console.WriteLine(String.Format("{0} {1} {2} {3} {4}", cd.Position, cd.Club, cd.GoalsFor, cd.GoalsAgainst, cd.GetGoalSpread()));
            }
        }

        private static IEnumerable<ClubData> ReadData(string filename)
        {
            using (StreamReader rdr = new StreamReader(filename))
            {
                return JsonSerializer.Deserialize<ClubData[]>(rdr.ReadToEnd());
            }
        }

    }
}
