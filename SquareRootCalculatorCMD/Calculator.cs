namespace SquareRootCalculator 
{ 
    public class Calculator
    { 
            // It would make sense to make this method static as it doesn't rely on any instance variables.
        public static double CalculateSquareRoot(double Y)
        {
            // Handle invalid inputs.
            if (Y < 0) 
            {
                throw new ArgumentException("Cannot compute square root for a negative number");
            }            
            if (Y == 0) return 0;

            // Initialise the constants for the algorithm.
            const double maxError = 0.001;
            const int maxIterations = 100;

            // Named squareRoot as instruccted instead of "guess" which would've been a clearer name.
            double squareRoot = Y;
            double prevSquareRoot;
            int i = 1;

            do
            {
                //Console.WriteLine("Iteration: " + i);
                prevSquareRoot = squareRoot;
                // Provided formula in the instructions.
                squareRoot = 0.5 * (prevSquareRoot + Y / prevSquareRoot);
                //Console.WriteLine("Current guess: " + squareRoot);
                i++;
            }
            // Compare the outcome of the current iteration with the previous one to determine if the error is
            // within the acceptable range.
            while (Math.Abs(prevSquareRoot - squareRoot) > maxError && i < maxIterations);
            
            Console.WriteLine($"Calculation Complete. Square root of {Y} is {squareRoot}. \nNumber of iterations: {i}");
            return squareRoot;
        }

        
    }
}
