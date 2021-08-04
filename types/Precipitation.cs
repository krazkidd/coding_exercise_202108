using System;
using System.Text.Json.Serialization;

namespace coding_exercise_202108
{
    public class Precipitation
    {

        private enum NOAAContractions
        {
            /// <summary>
            /// Missing
            /// </summary>
            M,

            /// <summary>
            /// Thunder
            /// </summary>
            T
        }

        public double? Depth
        {
            get;
            private set;
        }

        public bool IsMissing
        {
            get;
            private set;
        }

        public bool IsThunder
        {
            get;
            private set;
        }

        public Precipitation(double depth)
        {
            Depth = depth;
        }

        // public Precipitation(NOAAContractions contraction)
        // {
        //     IsMissing = (contraction == NOAAContractions.M);
        //     IsThunder = (contraction == NOAAContractions.T);
        // }

        public Precipitation(string contraction)
        {
            NOAAContractions val;
            if (Enum.TryParse<NOAAContractions>(contraction, out val))
            {
                IsMissing = (val == NOAAContractions.M);
                IsThunder = (val == NOAAContractions.T);
            }
        }

        public override string ToString()
        {
            if (Depth.HasValue)
            {
                return Depth.ToString();
            }
            else if (IsThunder)
            {
                return NOAAContractions.T.ToString();
            }
            else // if (IsMissing)
            {
                return NOAAContractions.M.ToString();
            }
        }

    }
}
