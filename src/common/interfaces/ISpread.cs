using System;

namespace coding_exercise_202108
{
    public interface ISpread<T>
        where T : IComparable<T>
    {

        // T Max
        // {
        //     get;
        // }

        // T Min
        // {
        //     get;
        // }

        /// <summary>
        /// Get the "spread"
        ///
        /// The definition of spread will depend on the data type, but generally
        /// it will be the difference between some "max" value and some "min" value.
        /// </summary>
        T GetSpread();

        /// <summary>
        /// Print the instance's identifying info and spread info
        /// </summary>
        string ToSpreadString();

    }
}
