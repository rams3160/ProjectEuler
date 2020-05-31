using System;
using System.Collections.Generic;
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

            var result = main.SumOfPrimes(2000000);
            Console.WriteLine(result);
        }

    }
}
