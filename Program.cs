using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace coding_exercise_202108
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<ClimateData> data = ReadData(args[0]);

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
                Console.WriteLine(String.Format("{0} {1} {2} {3}", cd.Date.ToString(ColonialDateConverter.FORMAT), cd.Maximum, cd.Minimum, cd.GetSpread()));
            }
        }

        private static IEnumerable<ClimateData> ReadData(string filename)
        {
            using (StreamReader rdr = new StreamReader(filename))
            {
                return JsonSerializer.Deserialize<ClimateData[]>(rdr.ReadToEnd());
            }
        }

    }
}
