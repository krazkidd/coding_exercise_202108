using System;

namespace coding_exercise_202108
{
    public interface ISpread<T>
    {

        T GetSpread();

        string ToSpreadString();

    }
}
