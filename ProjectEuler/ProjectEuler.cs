using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ProjectEuler
{
    class ProjectEuler
    {
        public int MultiplesOfThree(int max)
        {
            var numbers = Enumerable.Range(1, max - 1).ToList();

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
            for (int i = number; i > 100; i--)
            {
                for (int j = number; j > 100; j--)
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

            while (iterate)
            {

                int count = 0;
                for (int j = 1; j <= max; j++)
                {
                    if (number % j == 0)
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (count == max)
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
            for (int i = 1; i <= max; i++)
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

            while (primes.Count() < number)
            {
                currentNumber += 1;
                var divisorCount = 0;

                for (int i = 1; i <= currentNumber; i++)
                {
                    if (currentNumber % i == 0)
                    {
                        divisorCount++;
                    }
                }

                if (divisorCount == 2)
                {
                    primes.Add(currentNumber);
                }
            }
            return primes.Last();
        }

        public ulong LargestAdjacentProduct(string number, int adjacency)
        {
            ulong biggest = 0;

            for (int i = 0; i < number.Length - adjacency + 1; i++)
            {
                var series = number.Substring(i, adjacency);
                ulong multiplied = 1;

                foreach (var num in series)
                {

                    multiplied = ulong.Parse(num.ToString()) * multiplied;
                }

                if (multiplied > biggest)
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

                for (int j = a; j <= sum; j++)
                {
                    b = j;
                    c = sum - a - b;

                    var aSqr = Math.Pow(a, 2);
                    var bSqr = Math.Pow(b, 2);
                    var cSqr = Math.Pow(c, 2);

                    if (aSqr + bSqr == cSqr)
                    {
                        return "nums: " + a.ToString() + " " + b.ToString() + " " + c.ToString() + " product: " + a * b * c;
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

            for (int i = 2; i < limit; i++)
            {
                if (isPrime(i))
                {
                    sum += i;
                }
            }

            return sum;
        }

        public int LargestProductInGrid()
        {
            var grid = new[,]
            {
                {08, 02, 22, 97, 38, 15, 00, 40, 00, 75, 04, 05, 07, 78, 52, 12, 50, 77, 91, 08},
                {49, 49, 99, 40, 17, 81, 18, 57, 60, 87, 17, 40, 98, 43, 69, 48, 04, 56, 62, 00},
                {81, 49, 31, 73, 55, 79, 14, 29, 93, 71, 40, 67, 53, 88, 30, 03, 49, 13, 36, 65},
                {52, 70, 95, 23, 04, 60, 11, 42, 69, 24, 68, 56, 01, 32, 56, 71, 37, 02, 36, 91},
                {22, 31, 16, 71, 51, 67, 63, 89, 41, 92, 36, 54, 22, 40, 40, 28, 66, 33, 13, 80},
                {24, 47, 32, 60, 99, 03, 45, 02, 44, 75, 33, 53, 78, 36, 84, 20, 35, 17, 12, 50},
                {32, 98, 81, 28, 64, 23, 67, 10, 26, 38, 40, 67, 59, 54, 70, 66, 18, 38, 64, 70},
                {67, 26, 20, 68, 02, 62, 12, 20, 95, 63, 94, 39, 63, 08, 40, 91, 66, 49, 94, 21},
                {24, 55, 58, 05, 66, 73, 99, 26, 97, 17, 78, 78, 96, 83, 14, 88, 34, 89, 63, 72},
                {21, 36, 23, 09, 75, 00, 76, 44, 20, 45, 35, 14, 00, 61, 33, 97, 34, 31, 33, 95},
                {78, 17, 53, 28, 22, 75, 31, 67, 15, 94, 03, 80, 04, 62, 16, 14, 09, 53, 56, 92},
                {16, 39, 05, 42, 96, 35, 31, 47, 55, 58, 88, 24, 00, 17, 54, 24, 36, 29, 85, 57},
                {86, 56, 00, 48, 35, 71, 89, 07, 05, 44, 44, 37, 44, 60, 21, 58, 51, 54, 17, 58},
                {19, 80, 81, 68, 05, 94, 47, 69, 28, 73, 92, 13, 86, 52, 17, 77, 04, 89, 55, 40},
                {04, 52, 08, 83, 97, 35, 99, 16, 07, 97, 57, 32, 16, 26, 26, 79, 33, 27, 98, 66},
                {88, 36, 68, 87, 57, 62, 20, 72, 03, 46, 33, 67, 46, 55, 12, 32, 63, 93, 53, 69},
                {04, 42, 16, 73, 38, 25, 39, 11, 24, 94, 72, 18, 08, 46, 29, 32, 40, 62, 76, 36},
                {20, 69, 36, 41, 72, 30, 23, 88, 34, 62, 99, 69, 82, 67, 59, 85, 74, 04, 36, 16},
                {20, 73, 35, 29, 78, 31, 90, 01, 74, 31, 49, 71, 48, 86, 81, 16, 23, 57, 05, 54},
                {01, 70, 54, 71, 83, 51, 54, 69, 16, 92, 33, 48, 61, 43, 52, 01, 89, 19, 67, 48},
            };

            var rows = grid.GetLength(0);
            var columns = grid.GetLength(1);

            var greatest = 0;

            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < columns; c++)
                {
                    if (c < columns - 3)
                    {
                        // Right and "Left"
                        greatest = Math.Max(greatest, grid[r, c] * grid[r, c + 1] * grid[r, c + 2] * grid[r, c + 3]);
                    }

                    if (r < rows - 3)
                    {
                        // Down and "Up"
                        greatest = Math.Max(greatest, grid[r, c] * grid[r + 1, c] * grid[r + 2, c] * grid[r + 3, c]);

                        // Diagonally, down to the right
                        if (c < columns - 3)
                            greatest = Math.Max(greatest, grid[r, c] * grid[r + 1, c + 1] * grid[r + 2, c + 2] * grid[r + 3, c + 3]);

                        // Diagonally, down to the left
                        if (c > 3)
                            greatest = Math.Max(greatest, grid[r, c] * grid[r + 1, c - 1] * grid[r + 2, c - 2] * grid[r + 3, c - 3]);
                    }
                }
            }

            return greatest;
        }


        public int HighlyDivisibleTriangularNumber(int numberOfDivisors)
        {
            int triNumIndex = 1;
            var factorsCount = 0;
            var triNum = 0;

            while (factorsCount <= numberOfDivisors)
            {
                triNum = 0;
                factorsCount = 0;

                for (int i = 1; i <= triNumIndex; i++)
                {
                    triNum += i;
                }
                for (int i = 1; i < Math.Sqrt(triNum); i++)
                {
                    if (triNum % i == 0)
                    {
                        factorsCount += 2;
                    }
                    if (i * i == triNum)
                    {
                        factorsCount--;
                    }
                }
                triNumIndex += 1;
            }

            return triNum;
        }

        public string LargeSum(int digits)
        {
            BigInteger sum = 0;
            string[] numbers = new string[]
            {
                "37107287533902102798797998220837590246510135740250",
                "46376937677490009712648124896970078050417018260538",
                "74324986199524741059474233309513058123726617309629",
                "91942213363574161572522430563301811072406154908250",
                "23067588207539346171171980310421047513778063246676",
                "89261670696623633820136378418383684178734361726757",
                "28112879812849979408065481931592621691275889832738",
                "44274228917432520321923589422876796487670272189318",
                "47451445736001306439091167216856844588711603153276",
                "70386486105843025439939619828917593665686757934951",
                "62176457141856560629502157223196586755079324193331",
                "64906352462741904929101432445813822663347944758178",
                "92575867718337217661963751590579239728245598838407",
                "58203565325359399008402633568948830189458628227828",
                "80181199384826282014278194139940567587151170094390",
                "35398664372827112653829987240784473053190104293586",
                "86515506006295864861532075273371959191420517255829",
                "71693888707715466499115593487603532921714970056938",
                "54370070576826684624621495650076471787294438377604",
                "53282654108756828443191190634694037855217779295145",
                "36123272525000296071075082563815656710885258350721",
                "45876576172410976447339110607218265236877223636045",
                "17423706905851860660448207621209813287860733969412",
                "81142660418086830619328460811191061556940512689692",
                "51934325451728388641918047049293215058642563049483",
                "62467221648435076201727918039944693004732956340691",
                "15732444386908125794514089057706229429197107928209",
                "55037687525678773091862540744969844508330393682126",
                "18336384825330154686196124348767681297534375946515",
                "80386287592878490201521685554828717201219257766954",
                "78182833757993103614740356856449095527097864797581",
                "16726320100436897842553539920931837441497806860984",
                "48403098129077791799088218795327364475675590848030",
                "87086987551392711854517078544161852424320693150332",
                "59959406895756536782107074926966537676326235447210",
                "69793950679652694742597709739166693763042633987085",
                "41052684708299085211399427365734116182760315001271",
                "65378607361501080857009149939512557028198746004375",
                "35829035317434717326932123578154982629742552737307",
                "94953759765105305946966067683156574377167401875275",
                "88902802571733229619176668713819931811048770190271",
                "25267680276078003013678680992525463401061632866526",
                "36270218540497705585629946580636237993140746255962",
                "24074486908231174977792365466257246923322810917141",
                "91430288197103288597806669760892938638285025333403",
                "34413065578016127815921815005561868836468420090470",
                "23053081172816430487623791969842487255036638784583",
                "11487696932154902810424020138335124462181441773470",
                "63783299490636259666498587618221225225512486764533",
                "67720186971698544312419572409913959008952310058822",
                "95548255300263520781532296796249481641953868218774",
                "76085327132285723110424803456124867697064507995236",
                "37774242535411291684276865538926205024910326572967",
                "23701913275725675285653248258265463092207058596522",
                "29798860272258331913126375147341994889534765745501",
                "18495701454879288984856827726077713721403798879715",
                "38298203783031473527721580348144513491373226651381",
                "34829543829199918180278916522431027392251122869539",
                "40957953066405232632538044100059654939159879593635",
                "29746152185502371307642255121183693803580388584903",
                "41698116222072977186158236678424689157993532961922",
                "62467957194401269043877107275048102390895523597457",
                "23189706772547915061505504953922979530901129967519",
                "86188088225875314529584099251203829009407770775672",
                "11306739708304724483816533873502340845647058077308",
                "82959174767140363198008187129011875491310547126581",
                "97623331044818386269515456334926366572897563400500",
                "42846280183517070527831839425882145521227251250327",
                "55121603546981200581762165212827652751691296897789",
                "32238195734329339946437501907836945765883352399886",
                "75506164965184775180738168837861091527357929701337",
                "62177842752192623401942399639168044983993173312731",
                "32924185707147349566916674687634660915035914677504",
                "99518671430235219628894890102423325116913619626622",
                "73267460800591547471830798392868535206946944540724",
                "76841822524674417161514036427982273348055556214818",
                "97142617910342598647204516893989422179826088076852",
                "87783646182799346313767754307809363333018982642090",
                "10848802521674670883215120185883543223812876952786",
                "71329612474782464538636993009049310363619763878039",
                "62184073572399794223406235393808339651327408011116",
                "66627891981488087797941876876144230030984490851411",
                "60661826293682836764744779239180335110989069790714",
                "85786944089552990653640447425576083659976645795096",
                "66024396409905389607120198219976047599490197230297",
                "64913982680032973156037120041377903785566085089252",
                "16730939319872750275468906903707539413042652315011",
                "94809377245048795150954100921645863754710598436791",
                "78639167021187492431995700641917969777599028300699",
                "15368713711936614952811305876380278410754449733078",
                "40789923115535562561142322423255033685442488917353",
                "44889911501440648020369068063960672322193204149535",
                "41503128880339536053299340368006977710650566631954",
                "81234880673210146739058568557934581403627822703280",
                "82616570773948327592232845941706525094512325230608",
                "22918802058777319719839450180888072429661980811197",
                "77158542502016545090413245809786882778948721859617",
                "72107838435069186155435662884062257473692284509516",
                "20849603980134001723930671666823555245252804609722",
                "53503534226472524250874054075591789781264330331690"
            };

            foreach (var num in numbers)
            {
                sum = sum + BigInteger.Parse(num);
            }

            return sum.ToString().Substring(0, digits);
        }

        public long LongestCollatzSequence(int max)
        {
            var longest = 0;
            int longestIndex = 0;


            for (int i = 2; i <= max; i++)
            {
                var length = GenerateCollatzSequence(i);

                if (length > longest)
                {
                    longest = length;
                    longestIndex = i;
                }
            }

            return longestIndex;

        }

        public int GenerateCollatzSequence(long num)
        {
            //start with one to include initial sequence item passed in
            var sequenceCount = 1;

            while (num != 1)
            {
                if (num % 2 == 0)
                {
                    num = num / 2;
                }
                else
                {
                    num = (3 * num) + 1;
                }
                sequenceCount++;
            }
            return sequenceCount;
        }

        public long LatticePaths(int gridSize)
        {
            long[,] grid = new long[gridSize + 1, gridSize + 1];

            //Initialise the grid with boundary conditions
            for (int i = 0; i < gridSize; i++)
            {
                grid[i, gridSize] = 1; grid[gridSize, i] = 1;
            }

            for (int i = gridSize - 1; i >= 0; i--)
            {
                for (int j = gridSize - 1; j >= 0; j--)
                {
                    grid[i, j] = grid[i + 1, j] + grid[i, j + 1];
                }
            }

            return grid[0, 0];
        }

        public long PowerDigitSum(int number, int power)
        {
            BigInteger result = BigInteger.Pow(number, power);
            var resultString = result.ToString();
            long sum = 0;

            foreach (var num in resultString)
            {
                sum = sum + long.Parse(num.ToString());
            }

            return sum;
        }

        public long NumberLetterCounts(int max)
        {
            List<string> words = new List<string>();
            long count = 0;

            for (int i = 1; i <= max; i++)
            {
                var word = NumberToWords(i);
                words.Add(word);
            }

            foreach (var word in words)
            {
                count = count + word.Length;
            }

            return count;
        }

        public string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus" + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + "million";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + "thousand";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + "hundred";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += unitsMap[number % 10];
                }
            }

            return words;
        }

        public int MaximumPathSum(int[][] numsArray)
        {
            //This is the dataset for this problem, can paste in main to run again later.
            //int[][] nums = new int[][]
            //{
            //    new int[] {75},
            //    new int[] {95,64},
            //    new int[] {17,47,82},
            //    new int[] {18,35,87,10},
            //    new int[] {20,04,82,47,65},
            //    new int[] {19,01,23,75,03,34},
            //    new int[] {88,02,77,73,07,63,67},
            //    new int[] {99,65,04,28,06,16,70,92},
            //    new int[] {41,41,26,56,83,40,80,70,33},
            //    new int[] {41,48,72,33,47,32,37,16,94,29},
            //    new int[] {53,71,44,65,25,43,91,52,97,51,14},
            //    new int[] {70,11,33,28,77,73,17,78,39,68,17,57},
            //    new int[] {91,71,52,38,17,14,91,43,58,50,27,29,48},
            //    new int[] {63,66,04,68,89,53,67,30,73,16,69,87,40,31},
            //    new int[] {04,62,98,27,23,09,70,98,73,93,38,53,60,04,23},
            //};

            int lines = numsArray.GetLength(0);

            for (int i = lines - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    numsArray[i][j] += Math.Max(numsArray[i + 1][j], numsArray[i + 1][j + 1]);
                }
            }

            return numsArray[0][0];

        }

        public long CountingSundays(int startYear, int endYear, int dayOfMonth = 0)
        {
            int sundays = 0;

            if (dayOfMonth != 0)
            {
                for (int i = startYear; i <= endYear; i++)
                {
                    for (int month = 1; month <= 12; month++)
                    {
                        var dayOfWeek = new DateTime(i, month, dayOfMonth).DayOfWeek;
                        if (dayOfWeek == DayOfWeek.Sunday)
                        {
                            sundays++;
                        }
                    }
                }
            }
            else
            {
                for (int year = startYear; year <= endYear; year++)
                {
                    for (int month = 1; month <= 12; month++)
                    {
                        var days = DateTime.DaysInMonth(year, month);
                        for (int day = 1; day <= days; days++)
                        {
                            var dayOfWeek = new DateTime(year, month, day).DayOfWeek;
                            if (dayOfWeek == DayOfWeek.Sunday)
                            {
                                sundays++;
                            }
                        }
                    }
                }
            }
            return sundays;
        }

        public long FactorialDigitSum(int number)
        {
            BigInteger factorial = 1;
            long sum = 0;

            for (int i = 2; i <= number; i++)
            {
                factorial = factorial * i;
            }

            var factString = factorial.ToString();
            foreach (var digit in factString)
            {
                sum = sum + long.Parse(digit.ToString());
            }

            return sum;
        }

        public List<int> GetDivisors(int num, bool includeNum = true)
        {
            List<int> divisors = new List<int>();

            if (includeNum)
            {
                for (int i = 1; i < Math.Ceiling(Math.Sqrt(num)); i++)
                {
                    if (num % i == 0)
                    {
                        var pair = num / i;
                        divisors.Add(i);
                        divisors.Add(pair);
                    }
                }
            }
            else
            {
                for (int i = 2; i < Math.Ceiling(Math.Sqrt(num)); i++)
                {
                    if (num % i == 0)
                    {
                        var pair = num / i;
                        divisors.Add(i);
                        divisors.Add(pair);
                    }
                }
                divisors.Add(1);
            }


            return divisors;
        }

        public int SumDivisors(int num, bool includeNum = true)
        {
            int sum = 0;

            if (includeNum)
            {
                for (int i = 1; i < Math.Ceiling(Math.Sqrt(num)); i++)
                {
                    if (num % i == 0)
                    {
                        var pair = num / i;
                        sum = sum + i + pair;
                    }
                }
            }
            else
            {
                for (int i = 2; i < Math.Ceiling(Math.Sqrt(num)); i++)
                {
                    if (num % i == 0)
                    {
                        var pair = num / i;
                        sum = sum + i + pair;
                    }
                }
                sum += 1;
            }

            return sum;
        }

        public long SumOfAmicableNumbers(int max)
        {
            long sum = 0;
            int num1;
            int num2;

            for (int i = 2; i <= max; i++)
            {
                num1 = SumDivisors(i, false);
                if (num1 > i && num1 <= max)
                {
                    num2 = SumDivisors(num1, false);
                    if (num2 == i)
                    {
                        sum += i + num1;
                    }
                }
            }

            return sum;
        }

        public List<string> ReadCSV(string path, char trimKey)
        {
            StreamReader r = new StreamReader(path);
            string line = r.ReadToEnd();
            r.Close();

            List<string> names = line.Split(',').ToList();

            names.Sort();

            for(int i= 0; i < names.Count; i++)
            {
                names[i] = names[i].Trim(trimKey);
            }

            return names;
        }

        public BigInteger NameScore(List<string> names)
        {

            BigInteger sum = 0;

            for(int i = 0; i < names.Count; i++)
            {
                var charScore = 0;
                foreach(var character in names[i])
                {
                    charScore += Convert.ToInt32(character - 64);
                }
                sum = sum + (charScore * (i+1));
            }

            return sum;
        }


        public string LexicographicPermutation(int[] permutation,int speficiedPermutation)
        {

            int count = 1;
            while (count < speficiedPermutation)
            {
                int N = permutation.Length;
                int i = N - 1;
                while (permutation[i - 1] >= permutation[i])
                {
                    i = i - 1;

                }
                int j = N;
                while (permutation[j - 1] <= permutation[i - 1])
                {
                    j = j - 1;
                }

                swap(i - 1, j - 1);

                i++;
                j = N;
                while (i < j) {
                    swap(i - 1, j - 1);
                    i++;
                    j--;
                }
                count++;
            }

            string permNum = "";
            for (int k = 0; k < permutation.Length; k++) {
                permNum = permNum + permutation[k];
            }

            return permNum;

            void swap(int i, int j)
            {
                int k = permutation[i];
                permutation[i] = permutation[j];
                permutation[j] = k;
            }

        }

        public BigInteger FibonacciFinder(int n)
        {
            BigInteger firstnumber = 0, secondnumber = 1, result = 0;

            if (n == 0) return 0; //To return the first Fibonacci number   
            if (n == 1) return 1; //To return the second Fibonacci number   


            for (int i = 2; i <= n; i++)
            {
                result = firstnumber + secondnumber;
                firstnumber = secondnumber;
                secondnumber = result;
            }

            return result;
        }

        public BigInteger FirstOccuranceFibonachi(int digits)
        {
            int i = 0;
            int index = 2;
            BigInteger limit = BigInteger.Pow(10, digits - 1);
            BigInteger[] fib = new BigInteger[3];

            fib[0] = 1;
            fib[2] = 1;

            while (fib[i] <= limit)
            {
                i = (i + 1) % 3;
                index++;
                fib[i] = fib[(i + 1) % 3] + fib[(i + 2) % 3];
            }

            return index;
        }

        public int[] ESieve(int upperLimit)
        {
            //found on math blog, i undeerstand the idea of a sieve but i need to understand code more.

            int sieveBound = (int)(upperLimit - 1) / 2;
            int upperSqrt = ((int)Math.Sqrt(upperLimit) - 1) / 2;

            BitArray PrimeBits = new BitArray(sieveBound + 1, true);

            for (int i = 1; i <= upperSqrt; i++)
            {
                if (PrimeBits.Get(i))
                {
                    for (int j = i * 2 * (i + 1); j <= sieveBound; j += 2 * i + 1)
                    {
                        PrimeBits.Set(j, false);
                    }
                }
            }

            List<int> numbers = new List<int>((int)(upperLimit / (Math.Log(upperLimit) - 1.08366)));
            numbers.Add(2);
            for (int i = 1; i <= sieveBound; i++)
            {
                if (PrimeBits.Get(i))
                {
                    numbers.Add(2 * i + 1);
                }
            }

            return numbers.ToArray();
        }

        private int sumOfFactorsPrime(int number, int[] primelist)
        {
            int sum = 1;
            int currentPrime = primelist[0];
            int i = 0;
            int j;

            while (currentPrime * currentPrime <= number && number > 1 && i < primelist.Length)
            {
                currentPrime = primelist[i];
                i++;
                if (number % currentPrime == 0)
                {
                    j = currentPrime * currentPrime;
                    number = number / currentPrime;
                    while (number % currentPrime == 0)
                    {
                        j = j * currentPrime;
                        number = number / currentPrime;
                    }
                    sum = sum * (j - 1) / (currentPrime - 1);
                }
            }

            //A prime factor larger than the square root remains, so add that
            if (number > 1)
            {
                sum *= number + 1;
            }
            return sum - number;
        }


        public long NonAbundantSums()
        {
            //from mathblog, need to unerstand this one more.
            //limit given in problem
            const int limit = 28123;
            List<int> abundent = new List<int>();
            int[] primelist = ESieve((int)Math.Sqrt(limit));


            long sum = 0;

            // Find all abundant numbers
            for (int i = 2; i <= limit; i++)
            {
                if (sumOfFactorsPrime(i, primelist) > i)
                {
                    abundent.Add(i);
                }
            }

            // Make all the sums of two abundant numbers
            bool[] canBeWrittenasAbundent = new bool[limit + 1];
            for (int i = 0; i < abundent.Count; i++)
            {
                for (int j = i; j < abundent.Count; j++)
                {
                    if (abundent[i] + abundent[j] <= limit)
                    {
                        canBeWrittenasAbundent[abundent[i] + abundent[j]] = true;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            //Sum the numbers which are not sums of two abundant numbers
            for (int i = 1; i <= limit; i++)
            {
                if (!canBeWrittenasAbundent[i])
                {
                    sum += i;
                }
            }

            return sum;
        }

        public List<int> FractionToDecimal(int numerator, int divisor)
        {
            List<int> decimals = new List<int>();
            var previousDigit = 0;

            numerator = numerator % divisor * 10;
            while (true)
            {
                var digit = numerator / divisor;
                if ((decimals.Count > 1 && decimals[0] == digit) || digit == 0 || previousDigit == digit)
                {
                    break;
                }
                decimals.Add(digit);
                previousDigit = digit;
                numerator = numerator % divisor * 10;
            }
            return decimals;
        }

        public int LongestReciprocalCycle(int max)
        {
            int sequenceLength = 0;

            for (int i = max; i > 1; i--)
            {
                if (sequenceLength >= i)
                {
                    break;
                }

                int[] decimals = new int[i];
                int value = 1;
                int position = 0;

                while (decimals[value] == 0 && value != 0)
                {
                    decimals[value] = position;
                    value *= 10;
                    value %= i;
                    position++;
                }

                if (position - decimals[value] > sequenceLength)
                {
                    sequenceLength = position - decimals[value];
                }
            }

            return sequenceLength + 1;
        }

        public int QuadraticPrimes(int max)
        {
            int[] primes;
            int aMax = 0;
            int bMax = 0;
            int nMax = 0;

            primes = ESieve(87400);

            for (int a = -max; a <= max; a++)
            {
                for (int b = -max; b <= max; b++)
                {
                    int n = 0;
                    while (isPrime(Math.Abs(n * n + a * n + b)))
                    {
                        n++;
                    }

                    if (n > nMax)
                    {
                        aMax = a;
                        bMax = b;
                        nMax = n;
                    }
                }
            }

            return aMax * bMax;

            bool isPrime(int testNumber)
            {
                int i = 0;
                while (primes[i] <= testNumber)
                {
                    if (primes[i] == testNumber)
                    {
                        return true;
                    }
                    i++;
                }
                return false;
            }
        }

        public double NumberSpiralSum(int size)
        {
            //remove special case: middle
            var iterations = (size - 1) / 2;

            double sum = 0;

            for(int i = 1; i <= iterations; i++)
            {
                //formula is found by finding each corner and reducing terms.
                //4(2n+1)^2 - 12n
                var powTerm = 2 * i + 1;
                var powResult = Math.Pow(powTerm, 2);
                var result = (4 * powResult) - (12 * i);

                sum = sum + result;
            }

            return sum + 1; //add special case: middle

        }

        public int DistinctTerm(int lowerLimit, int upperLimit)
        {
            List<double> terms = new List<double>();

            for(int i = lowerLimit; i <= upperLimit; i++)
            {
                for (int j = lowerLimit; j <= upperLimit; j++){
                    var term = Math.Pow(i, j);
                    terms.Add(term);
                }
            }

            return terms.Distinct().Count();
        }

        public double SumOfDigitPowers(int power)
        {
            //calcualte bounds
            var largestPow = Math.Pow(9, power);
            var largestPowString = largestPow.ToString();
            var digitCount = (largestPowString.Length + 1) * largestPow;

            double sum = 0;

            for(int i = 1634; i < digitCount; i++)
            {
                var numberString = i.ToString();
                double powSum = 0;
                foreach( var number in numberString)
                {
                    var num = Int64.Parse(number.ToString());
                    var pow = Math.Pow(num, power);
                    powSum = powSum + pow;
                }
                if (powSum == i)
                {
                    sum = sum + powSum;
                }
            }

            return sum;
        }
    }
}