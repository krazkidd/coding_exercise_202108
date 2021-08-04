using System;
using System.Collections.Generic;
using System.Linq;
using coding_exercise_202108.ex1;

namespace coding_exercise_202108
{
    class Program1
    {
        static void Main(string[] args)
        {
            new Program<ClimateData, double>().Run(args[0]);
        }

    }
}
