using System;
using System.Windows;

namespace SquareCalculation
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnCalculateClick(object sender, RoutedEventArgs e)
        {
            double areaOfCircle = double.Parse(InputArea.Text);
            double radius = Math.Sqrt(areaOfCircle / Math.PI);
            double sideOfSquare = radius * Math.Sqrt(2);
            double perimeterOfSquare = 4 * sideOfSquare;
            double areaOfSquare = sideOfSquare * sideOfSquare;

            OutputArea.Text = "Area: " + areaOfSquare.ToString();
            OutputPerimeter.Text = "Perimeter: " + perimeterOfSquare.ToString();
        }
    }
}

