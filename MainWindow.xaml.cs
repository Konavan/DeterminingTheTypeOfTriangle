using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeterminingTheTypeOfTriangle
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement el in Stk.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
            }
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            string input1 = a.Text.Replace('.', ',');
            string input2 = b.Text.Replace('.', ',');
            string input3 = c.Text.Replace('.', ',');

            if (double.TryParse(input1, out double side1) &&
                double.TryParse(input2, out double side2) &&
                double.TryParse(input3, out double side3))
            {
                if (IsValidTriangle(side1, side2, side3))
                {
                    string triangleType = GetTriangleType(side1, side2, side3);
                    Result.Text =  triangleType;
                }
                else
                {
                    Result.Text = "Невозможен такой\nтреугольник.";
                }
            }
            else
            {
                Result.Text = "Пожалуйста, введите\nчисла";
            }
        }

        private bool IsValidTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

        private string GetTriangleType(double a, double b, double c)
        {
            if (a == b && b == c)
                return "равносторонний";
            else if (a == b || b == c || a == c)
                return "равнобедренный";
            else
                return "разносторонний";
        }
        private void TxB1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                b.Focus();
                e.Handled = true;
            }
        }

        private void TxB2(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                c.Focus();
                e.Handled = true;
            }
        }

        private void TxB3(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click(sender, e);
            }
        }
    }
}
