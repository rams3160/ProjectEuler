using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            ProjectEuler main = new ProjectEuler();

            var result = main.NonAbundantSums();
            Console.WriteLine(result);

        }

    }
}
