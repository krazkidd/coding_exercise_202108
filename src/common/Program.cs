using System;
using System.Collections.Generic;
using System.Linq;

namespace coding_exercise_202108
{
    public class Program<T>
        where T : IComparable<T>
    {
        public void Run(string filename)
        {
            IEnumerable<T> data = JsonReader.ReadFromFile<T>(filename);

            // NOTE: I realize I am looping through the data multiple times. Leaving for readability.

            // get min and max spreads
            T minSpread = data.Min(cd => cd);
            T maxSpread = data.Max(cd => cd);

            // get all items with the min spread value
            IEnumerable<T> minSpreads = data.Where(cd => cd.CompareTo(minSpread) == 0);
            // get all items with the max spread value
            IEnumerable<T> maxSpreads = data.Where(cd => cd.CompareTo(maxSpread) == 0);

            // print all
            foreach (T cd in minSpreads.Concat(maxSpreads))
            {
                Console.WriteLine(cd.ToString());
            }
        }

    }
}
