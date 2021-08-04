using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using coding_exercise_202108.ex2;

namespace coding_exercise_202108
{
    class Program2
    {
        static void Main(string[] args)
        {
            new Program<ClubData, int>().Run(args[0]);
        }

    }
}
