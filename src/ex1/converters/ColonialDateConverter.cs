using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace coding_exercise_202108.ex1
{
    /// <summary>
    /// JSON converter for dates in month/day/year string format.
    /// </summary>
    /// <remarks>Not sure what standard (e.g. ANSI) the format is defined in, so I called it "colonial".</remarks>
    public class ColonialDateConverter
        : JsonConverter<DateTime>
    {

        public const string FORMAT = "M/d/yyyy";

        public override DateTime Read(ref Utf8JsonReader rdr, Type type, JsonSerializerOptions options)
        {
            string dateStr = rdr.GetString();

            //TODO? third argument (culture)
            return DateTime.ParseExact(dateStr, FORMAT, null);
        }

        public override void Write(Utf8JsonWriter wrt, DateTime dt, JsonSerializerOptions options)
        {
            wrt.WriteStringValue(dt.ToString(FORMAT));
        }

    }
}
