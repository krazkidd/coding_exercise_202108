using System.Text.Json;
using System.IO;

namespace coding_exercise_202108
{
    public static class JsonReader
    {

        public static T[] ReadFromFile<T>(string filename)
        {
            using (StreamReader rdr = new StreamReader(filename))
            {
                return JsonSerializer.Deserialize<T[]>(rdr.ReadToEnd());
            }
        }

    }
}
