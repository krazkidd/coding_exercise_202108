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
            //       This can be optimized later.

            foreach (T val in GetMinimums(data).Concat(GetMaximums(data)))
            {
                Console.WriteLine(val.ToString());
            }
        }

        private IEnumerable<T> GetMinimums(IEnumerable<T> data)
        {
            // get min
            T min = data.Min(cd => cd);

            // return all items with the min value
            return data.Where(cd => cd.CompareTo(min) == 0);
        }

        private IEnumerable<T> GetMaximums(IEnumerable<T> data)
        {
            // get max
            T max = data.Max(cd => cd);

            // return all items with the max value
            return data.Where(cd => cd.CompareTo(max) == 0);
        }

    }
}
