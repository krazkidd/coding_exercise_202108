using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace coding_exercise_202108
{
    public class JsonReader<T>
    {

        public T[] ReadFromFile(string filename)
        {
            using (StreamReader rdr = new StreamReader(filename))
            {
                return JsonSerializer.Deserialize<T[]>(rdr.ReadToEnd());
            }
        }

    }
}
