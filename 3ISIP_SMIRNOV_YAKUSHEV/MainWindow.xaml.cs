using System;
using System.ComponentModel;
using System.Windows;

namespace _3ISIP_SMIRNOV_YAKUSHEV
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Event handler for closing the window with a confirmation
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit?", "Exit Confirmation", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;  // Prevent closing
            }
        }

        // Event handler for the "Вычислить" button
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double x = Convert.ToDouble(xInput.Text);
                double m = Convert.ToDouble(mInput.Text);
                double result = CalculateFunction(x, m);  // Calculate the value of j
                ResultTextBox.Text = result.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input values");
            }
        }

        // Event handler for the "Очистить" button
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            xInput.Clear();
            mInput.Clear();
            ResultTextBox.Clear();
        }

        // Function to calculate the value of j based on selected formula
        private double CalculateFunction(double x, double m)
        {
            double result = 0;

            // Calculate based on the selected function
            if (shRadio.IsChecked == true)
                result = Math.Sinh(5 * x) + 3 * m * Math.Abs(x);
            else if (x2Radio.IsChecked == true)
                result = x * x;
            else if (expRadio.IsChecked == true)
                result = Math.Exp(x);

            // Apply the given function j logic
            if (Math.Abs(x * m) > 10)
            {
                result = Math.Log(Math.Abs(result) + Math.Abs(m));
            }
            else if (Math.Abs(x * m) < 10)
            {
                result = Math.Exp(result + m);
            }
            else
            {
                result = result + m;
            }

            return result;
        }
    }
}
