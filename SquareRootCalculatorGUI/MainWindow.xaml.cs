using System;
using System.Threading.Tasks;
using System.Windows;
using SquareRootCalculator; // Ensure this reference exists

namespace SquareRootCalculatorGUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(InputBox.Text, out double number) && number >= 0)
            {
                LogBox.Text = "";
                StatusLabel.Content = "Calculating...";

                try
                {
                    double result = await Task.Run(() => ComputeSquareRoot(number));

                    StatusLabel.Content = $"Result: {result:F4}";
                }
                catch (Exception ex)
                {
                    StatusLabel.Content = ex.Message;
                }
            }
            else
            {
                StatusLabel.Content = "Invalid input!";
            }
        }

        public double ComputeSquareRoot(double Y)
        {
            if (Y < 0) throw new ArgumentException("Cannot compute square root for a negative number");
            if (Y == 0) return 0;

            double maxError = 0.001;
            int maxIterations = 100;
            double squareRoot = Y;
            double prevSquareRoot;
            int i = 1;

            do
            {
                prevSquareRoot = squareRoot;
                squareRoot = 0.5 * (prevSquareRoot + Y / prevSquareRoot);

                Dispatcher.Invoke(() => LogBox.Text = $"Iteration {i}: {squareRoot:F4}\n" + LogBox.Text);

                Task.Delay(100).Wait(); // Simulating computation delay
                i++;

            } while (Math.Abs(prevSquareRoot - squareRoot) > maxError && i < maxIterations);

            Dispatcher.Invoke(() => LogBox.Text = $"Calculation completed after {i} iterations\n" + LogBox.Text);

            Dispatcher.Invoke(() => LogBox.Text = $"Square root of {Y} is {squareRoot:F4}. \n" + LogBox.Text);

            return squareRoot;
        }
    }
}
