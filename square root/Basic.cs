using System.Xml.Linq;

namespace SquareRootCalculator 
{ 
    class Basic
    {
        // It would make sense to make this method static as it doesn't rely on any instance variables.
        static double CalculateSquareRoot(double Y)
        {
            // Handle invalid inputs.
            if (Y < 0) throw new ArgumentException("Cannot compute square root for a negative number");
            if (Y == 0) return 0;

            // Initialise the constants for the algorithm.
            const double maxError = 0.001;
            const int maxIterations = 100;

            // Named squareRoot as instruccted instead of "guess" which would've been a clearer name.
            double squareRoot = Y;
            double prevSquareRoot;
            int i = 0;

            do
            {
                //Console.WriteLine("Iteration: " + i);
                prevSquareRoot = squareRoot;
                // Provided formula in the instructions.
                squareRoot = 0.5 * (prevSquareRoot + Y / prevSquareRoot);
                //Console.WriteLine("Current guess: " + squareRoot);
                i++;
            }
            // Compare the outcome of the current iteration with the previous one to determine if the error is within the acceptable range.
            while (Math.Abs(prevSquareRoot - squareRoot) > maxError && i < maxIterations);
            Console.WriteLine($"Calculation Complete. Square root of {Y} is {squareRoot}. \nNumber of iterations: {i}");

            return squareRoot;
        }

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
                    CalculateSquareRoot(number);
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
