using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace coding_exercise_202108.ex1
{
    public class PrecipitationConverter
        : JsonConverter<Precipitation>
    {

        public override Precipitation Read(ref Utf8JsonReader rdr, Type type, JsonSerializerOptions options)
        {
            try
            {
                //TODO SLOW!!! this is going to throw very often because we don't know what data type to expect.
                //     i think Newtonsoft can handle this situation more efficiently (this seems to be a shortcoming
                //     of .NET's immature JSON serialization code). anyway, there may be cause to inverse the order
                //     of these so that we expect a string and fall back to checking for a number
                return new Precipitation(rdr.GetDouble());
            }
            catch (InvalidOperationException)
            {
                // probably a string

                string precipStr = rdr.GetString();

                double val;
                if (Double.TryParse(precipStr, out val))
                {
                    return new Precipitation(val);
                }
                else
                {
                    return new Precipitation(precipStr);
                }
            }
        }

        public override void Write(Utf8JsonWriter wrt, Precipitation p, JsonSerializerOptions options)
        {
            wrt.WriteStringValue(p.ToString());
        }

    }
}
