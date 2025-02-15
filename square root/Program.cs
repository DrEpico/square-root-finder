using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SquareRootCalculator;

namespace square_root
{
    class Program
    {
        static void Main()
        {
            bool continueComputing = true;

            while (continueComputing)
            {
                Console.Write("\nPlease enter a number: ");
                string input = Console.ReadLine();

                if (double.TryParse(input, out double number))
                {
                    Console.WriteLine("Computing...");

                    // Call the CalculateSquareRoot (static) method from the Basic class.
                    Basic.CalculateSquareRoot(number);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    continue;
                }

                Console.Write("\nWould you like to compute another square root? (yes/no): ");
                string response = Console.ReadLine()?.Trim().ToLower();

                if (response != "yes" && response != "y")
                {
                    continueComputing = false;
                }
            }

            Console.WriteLine("Program complete. Press Enter to exit.");
            Console.ReadLine();
        }
    }
}
