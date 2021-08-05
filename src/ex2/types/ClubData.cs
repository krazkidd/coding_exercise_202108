using System;
using System.Text.Json.Serialization;

namespace coding_exercise_202108.ex2
{
    public class ClubData
        : IComparable<ClubData>
    {

        /// <summary>
        /// Season ranking
        /// </summary>
        [JsonPropertyName("POSITION")]
        public int Position
        {
            get;
            set;
        }

        /// <summary>
        /// Club name
        /// </summary>
        [JsonPropertyName("CLUB")]
        public string Club
        {
            get;
            set;
        }

        /// <summary>
        /// Games played
        /// </summary>
        [JsonPropertyName("PLAYED")]
        public int Played
        {
            get;
            set;
        }

        /// <summary>
        /// Games won
        /// </summary>
        [JsonPropertyName("WON")]
        public int Won
        {
            get;
            set;
        }

        /// <summary>
        /// Games drawn
        /// </summary>
        [JsonPropertyName("DRAWN")]
        public int Drawn
        {
            get;
            set;
        }

        /// <summary>
        /// Games lost
        /// </summary>
        [JsonPropertyName("LOST")]
        public int Lost
        {
            get;
            set;
        }
    
        [JsonPropertyName("GF")]
        public int GoalsFor
        {
            get;
            set;
        }

        [JsonPropertyName("GA")]
        public int GoalsAgainst
        {
            get;
            set;
        }

        [JsonPropertyName("POINTS")]
        public int Points
        {
            get;
            set;
        }

        public int GetSpread()
        {
            // the absolute difference between goals for and goals against
            return Math.Abs(GoalsFor - GoalsAgainst);
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3} {4}", Position, Club, GoalsFor, GoalsAgainst, GetSpread());
        }

        #region IComparable

        public int CompareTo(ClubData other)
        {
            return GetSpread().CompareTo(other.GetSpread());
        }

        #endregion

    }
}
