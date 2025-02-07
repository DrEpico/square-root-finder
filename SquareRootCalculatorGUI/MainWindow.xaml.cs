using System;
using System.Threading.Tasks;
using System.Windows;

namespace SquareRootCalculatorGUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // This method is called when the Calculate button is clicked.
        private async void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Check if the input is a valid number and greater than or equal to 0.
            if (double.TryParse(InputBox.Text, out double number) && number >= 0)
            {
                LogBox.Text = "";
                StatusLabel.Content = "Calculating...";

                try
                {
                    // Call the ComputeSquareRoot method asynchronously.
                    double result = await Task.Run(() => ComputeSquareRoot(number));

                    // Display the result in the status label.
                    StatusLabel.Content = $"Result: {result:F4}";
                }
                catch (Exception ex)
                {
                    // Display the exception message in the status label.
                    StatusLabel.Content = ex.Message;
                }
            }
            else
            {
                StatusLabel.Content = "Invalid input";
            }
        }

        public double ComputeSquareRoot(double Y)
        {
            // Handle invalid inputs (0 and negative values).
            if (Y < 0) throw new ArgumentException("Cannot compute square root for a negative number");
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
                prevSquareRoot = squareRoot;
                // Provided formula in the instructions.
                squareRoot = 0.5 * (prevSquareRoot + Y / prevSquareRoot);

                Dispatcher.Invoke(() => LogBox.Text = $"Iteration {i}: {squareRoot:F4}\n" + LogBox.Text);

                Task.Delay(50).Wait(); 

                i++;

            }
            // Compare the outcome of the current iteration with the previous one to determine if the error is
            // within the acceptable range.
            while (Math.Abs(prevSquareRoot - squareRoot) > maxError && i < maxIterations);

            Task.Delay(50).Wait();

            Dispatcher.Invoke(() => LogBox.Text = $"Calculation completed after {i} iterations.\n" + LogBox.Text);
            
            Task.Delay(50).Wait();

            Dispatcher.Invoke(() => LogBox.Text = $"Square root of {Y} is {squareRoot:F4}. \n" + LogBox.Text);

            // Return the final square root value (Could be fed to other methods).
            return squareRoot;
        }
    }
}
