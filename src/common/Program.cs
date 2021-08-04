using System;
using System.Collections.Generic;
using System.Linq;

namespace coding_exercise_202108
{
    //TODO is there a way to force ISpread<> without the second type argument V?
    public class Program<T, V>
        where T : ISpread<V>
        where V : IComparable<V>
    {
        public void Run(string filename)
        {
            IEnumerable<T> data = JsonReader.ReadFromFile<T>(filename);

            // NOTE: I realize I am looping through the data multiple times. Leaving for readability.

            // get min and max spreads
            V minSpread = data.Min(cd => cd.GetSpread());
            V maxSpread = data.Max(cd => cd.GetSpread());

            //TODO can this be simplified? looks silly
            Comparer<V> comparer = Comparer<V>.Create(new Comparison<V>((x, y) => x.CompareTo(y)));

            // get all items with the min spread value
            IEnumerable<T> minSpreads = data.Where(cd => comparer.Compare(minSpread, cd.GetSpread()) == 0);
            // get all items with the max spread value
            IEnumerable<T> maxSpreads = data.Where(cd => comparer.Compare(maxSpread, cd.GetSpread()) == 0);

            // print all
            foreach (T cd in minSpreads.Concat(maxSpreads))
            {
                Console.WriteLine(cd.ToSpreadString());
            }
        }

    }
}