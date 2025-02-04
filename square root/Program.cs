class Program
{
    static int ClosestSquareRoot(int n)
    {
        int i = 0;

        // Find the largest integer whose square is ≤ n
        while (i * i <= n)
        {
            i++;
        }

        // 'lower' is the largest integer whose square is still ≤ n
        int lower = i - 1;
        // 'upper' is the next integer whose square is greater than n
        int upper = i;

        // Compare which square is closer to 'n' and return the closest one
        return (Math.Abs(lower * lower - n) <= Math.Abs(upper * upper - n)) ? lower : upper;
    }

    //double Y = 0; //user input
    //double maxError = 0.001;
    //int maxIterations = 100;

    //double compute(double Y)
    //{
    //    //reject Y=0
    //    double squareRoot = 0; 
    //    while(Y != squareRoot)
    //    {
    //        squareRoot = 0.50 * (squareRoot + Y / squareRoot);
    //    }
    //    return Y;
    //}

    static void Main()
    {
        Console.WriteLine("Starting the program...");
        Console.WriteLine("Closest Square Root of 26: " + ClosestSquareRoot(12536332));
        Console.WriteLine("Press Enter to exit.");
        Console.ReadLine(); // Prevents CMD from closing instantly
    }
}
