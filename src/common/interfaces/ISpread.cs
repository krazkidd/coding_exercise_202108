namespace coding_exercise_202108
{
    public interface ISpread<T>
    {

        // T Max
        // {
        //     get;
        // }

        // T Min
        // {
        //     get;
        // }

        T GetSpread();

        string ToSpreadString();

    }
}
