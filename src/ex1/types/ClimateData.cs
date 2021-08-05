using System;
using System.Text.Json.Serialization;

namespace coding_exercise_202108.ex1
{
    public class ClimateData
        : IComparable<ClimateData>
    {

        [JsonConverter(typeof(ColonialDateConverter))]
        public DateTime Date
        {
            get;
            set;
        }

        public double Maximum
        {
            get;
            set;
        }

        public double Minimum
        {
            get;
            set;
        }
   
        public double Average
        {
            get;
            set;
        }
   
        /// <summary>
        /// Difference from "normal" (i.e. 30-year average).
        /// </summary>
        public double Departure
        {
            get;
            set;
        }
   
        /// <summary>
        /// Heating degree days
        /// </summary>
        /// <remarks>Quantifies energy demand to heat a building.</remarks>
        public double HDD
        {
            get;
            set;
        }
    
        /// <summary>
        /// Cooling degree days
        /// </summary>
        /// <remarks>Quantifies energy demand to cool a building.</remarks>
        public double CDD
        {
            get;
            set;
        }

        [JsonConverter(typeof(PrecipitationConverter))]
        public Precipitation Precipitation
        {
            get;
            set;
        }

        [JsonPropertyName("New Snow")]
        [JsonConverter(typeof(PrecipitationConverter))]
        public Precipitation NewSnow
        {
            get;
            set;
        }

        [JsonPropertyName("Snow Depth")]
        [JsonConverter(typeof(PrecipitationConverter))]
        public Precipitation SnowDepth
        {
            get;
            set;
        }

        public double GetSpread()
        {
            return Maximum - Minimum;
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3}", Date.ToString(ColonialDateConverter.FORMAT), Maximum, Minimum, GetSpread());
        }

        #region IComparable

        public int CompareTo(ClimateData other)
        {
            return GetSpread().CompareTo(other.GetSpread());
        }

        #endregion

    }
}
