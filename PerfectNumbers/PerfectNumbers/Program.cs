using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PerfectNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //variable declarations
            int lowBound;
            int uppBound;
            List<int> perfectNumbers = new List<int>();

            //Read and parse lower bound input
            Console.WriteLine("Enter lower bound:");
            string inputLowBound = Console.ReadLine();
            Int32.TryParse(inputLowBound, out lowBound);
            if (lowBound < 1)
            {
                lowBound = 1;
            }

            //read and parse upper bound input
            Console.WriteLine("Enter upper bound:");
            string inputUppBound = Console.ReadLine();
            Int32.TryParse(inputUppBound, out uppBound);

            //start stopwatch for benchmarking
            Stopwatch s1 = Stopwatch.StartNew();
            //iterate through values between boundaries
            for (int i = lowBound; i <= uppBound; i++)
            {
                //As the known perfect numbers all end in 6 or 8, only run the check for numbers ending in 6 or 8
                if (i % 10 == 6 || i % 10 == 8)
                {
                    int result = 0;
                    //iterate though possible divisors (no divisors can be found after value / 2)
                    for (int j = 1; j <= i / 2; j++)
                    {
                        //if j is divisor of i, add it to the result
                        if (i % j == 0)
                        {
                            result += j;
                        }
                    }
                    //if result equals original value, then value is a perfect number
                    if (result == i)
                    {
                        perfectNumbers.Add(result);
                    }
                }
            }

            Console.WriteLine("Perfect numbers within given range: ");
            if (perfectNumbers.Count == 0)
            {
                Console.WriteLine("No perfect numbers found within given range");
            }
            else
            {
                foreach (int i in perfectNumbers)
                {
                    Console.WriteLine(i);
                }
            }

            Console.WriteLine("Check complete");
            Console.WriteLine("Time taken in milliseconds: " + s1.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
