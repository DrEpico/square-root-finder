using System.Xml.Linq;

namespace SquareRootCalculator 
{ 
    public class Basic
    {

        //i can do this using two different helper methods and call them as callback functions depending on which one i want to use 
        //1. algorithmically find the closest whole number square root of the inputted square value 
        //static int ClosestSquareRoot(int n, bool isActive)
        //{
        //    int i = 0;

        //    // Find the largest integer whose square is ≤ n
        //    while (i * i <= n)
        //    {
        //        i++;
        //    }

        //    // 'lower' is the largest integer whose square is still ≤ n
        //    int lower = i - 1;
        //    // 'upper' is the next integer whose square is greater than n
        //    int upper = i;

        //    // Compare which square is closer to 'n' and return the closest one
        //    return (Math.Abs(lower * lower - n) <= Math.Abs(upper * upper - n)) ? lower : upper;
        //}

        public static double compute(double Y)
        {
            // Handle invalid inputs.
            if (Y < 0) throw new ArgumentException("Cannot compute square root for a negative number");
            if (Y == 0) return 0;

            // Initialise 
            double maxError = 0.001;
            int maxIterations = 100;
            // Named squareRoot as instruccted instead of "guess" which would've been a clearer name.
            double squareRoot = Y;
            double prevSquareRoot;
            int i = 0;
            do
            {
                Console.WriteLine("Iteration: " + i);
                prevSquareRoot = squareRoot;
                // Provided formula in the instructions.
                squareRoot = 0.5 * (prevSquareRoot + Y / prevSquareRoot);
                Console.WriteLine("Current guess: " + squareRoot);
                i++;

            } 
            // Compare 
            while (Math.Abs(prevSquareRoot - squareRoot) > maxError && i < maxIterations);
            Console.WriteLine("Calculation Complete. Square root of " + Y + " is " + squareRoot + ". Number of iterations: " + i );
            return squareRoot;
        }

        static void Main()
        {
            Console.WriteLine("Starting the program...");
            //Console.WriteLine("Closest Square Root of 26: " + ClosestSquareRoot(26, true));
            Console.WriteLine("computing... " + compute(18581285));
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine(); 
        }
    }
}
