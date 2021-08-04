using System;
using System.Text.Json.Serialization;

namespace coding_exercise_202108.ex2
{
    public class ClubData
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

        /// <summary>
        /// The absolute difference between goals for and goals against
        /// </summary>
        public int GetGoalSpread()
        {
            return Math.Abs(GoalsFor - GoalsAgainst);
        }

    }
}
