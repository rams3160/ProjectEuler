using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ProjectEuler
{
    class ProjectEuler
    {
        public int MultiplesOfThree(int max)
        {
            var numbers = Enumerable.Range(1, max-1).ToList();

            IList<int> multiples = new List<int>();

            foreach (var number in numbers)
            {
                if (number % 5 == 0 || number % 3 == 0)
                {
                    multiples.Add(number);
                }
            }

            return multiples.Sum();

        }

        public int EvenFibonachiNumbers(int max)
        {
            int x = 0;
            int y = 1;
            int z;

            IList<int> fibs = new List<int>();

            for (int i = 0; i < max; i++)
            {

                z = x + y;

                if (z > max)
                    break;

                if (z % 2 == 0)
                    fibs.Add(z);

                x = y;
                y = z;
            }

           return fibs.Sum();
        }

        public long LargestPrimeFactor(long number)
        {
            long divisor = 2;
            while (divisor * divisor <= number)
            {
                if (number % divisor == 0)
                {
                    number /= divisor;
                }
                else
                {
                    ++divisor;
                }
            }

            return number;
        }

        public int LargestPalindromeProduct(int number)
        {
            IList<int> palindromes = new List<int>();
            for(int i = number; i > 100; i--)
            {
                for(int j = number; j > 100; j--)
                {
                    var product = i * j;
                    var stringProduct = product.ToString();

                    if (stringProduct.Length == 6)
                    {
                        if (stringProduct.First() == stringProduct.Last())
                        {
                            if (stringProduct[1] == stringProduct[4])
                            {
                                if (stringProduct[2] == stringProduct[3])
                                {
                                    palindromes.Add(product);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (stringProduct.First() == stringProduct.Last())
                        {
                            if (stringProduct[1] == stringProduct[3])
                            {
                                palindromes.Add(product);
                            }
                        }
                    }
                }
               
            }
            return palindromes.Max();
        }

        public int SmallestMultiple(int max)
        {
            bool iterate = true;
            int number = 1;

            while (iterate) {

                int count = 0;
                for (int j = 1; j <= max; j++)
                {
                    if(number%j == 0)
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                if(count == max)
                {
                    iterate = false;
                    return number;
                }
                else
                {
                    number += 1;
                }

            }
            return 0;
        }

        public int SumSquareDifference(int max)
        {
            var SumOfSquares = 0;
            var Sums = 0;
            for(int i = 1; i <= max; i++)
            {
                SumOfSquares = SumOfSquares + (int)Math.Pow(i, 2);
                Sums = Sums + i;
            }

            var SquareOfSums = (int)Math.Pow(Sums, 2);

            return SquareOfSums - SumOfSquares;
        }

        public int primeFinder(int number)
        {
            IList<int> primes = new List<int>();

            var currentNumber = 1;

            while(primes.Count() < number)
            {
                currentNumber += 1;
                var divisorCount = 0;

                for(int i = 1; i <= currentNumber; i++)
                {
                    if (currentNumber%i == 0)
                    {
                        divisorCount++;
                    }
                }

                if(divisorCount == 2)
                {
                    primes.Add(currentNumber);
                }
            }
            return primes.Last();
        }

        public ulong LargestAdjacentProduct(string number, int adjacency)
        {
            ulong biggest = 0;
            
            for(int i =0; i < number.Length-adjacency+1; i++) 
            {
                var series = number.Substring(i, adjacency);
                ulong multiplied = 1;

                foreach(var num in series)
                {
                    
                    multiplied = ulong.Parse(num.ToString()) * multiplied;
                }

                if(multiplied > biggest)
                {
                    biggest = multiplied;
                }
            }

            return biggest;
        }

        public string SpecialPythagoreanTriplets(int sum)
        {
            //a + b + c = 1000

            //a = 1000 - b - c
            //b = 1000 - a - c
            //c = 1000 - a - b

            var a = 0;
            var b = 0;
            var c = 0;

            for (int i = 1; i <= sum; i++)
            {
                 a = i;

                for(int j = a; j <= sum; j++)
                {
                     b = j;
                     c = sum - a - b;

                    var aSqr = Math.Pow(a, 2);
                    var bSqr = Math.Pow(b, 2);
                    var cSqr = Math.Pow(c, 2);

                    if (aSqr + bSqr == cSqr)
                    {
                        return "nums: " + a.ToString() + " " + b.ToString() + " " + c.ToString() + " product: " + a*b*c;
                    }
                }
            }
            return "Not Found"; 
        }

        private bool isPrime(int num)
        {
            int range = num;
            for (int i = 2; i < range; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
                range = num / i;
            }
            return true;
        }

        public long SumOfPrimes(int limit)
        {
            long sum = 0;

            for(int i = 2; i < limit; i++)
            {
                if(isPrime(i))
                {
                    sum += i;
                }
            }

            return sum;
        }
    }
}
