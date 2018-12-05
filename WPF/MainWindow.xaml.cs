using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string buffer = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Buttons responsivness
            button_col.Width = new GridLength(Height / (3.0 / 2.0));

            // Textobx responsivness
            double fontsize = (Height - 20 * 3) / 6;
            val1_tbox.FontSize   = fontsize;
            val2_tbox.FontSize   = fontsize;
            result_tbox.FontSize = fontsize;
        }

        // Operation buttons
        private void Sum_btn_Click(object sender, RoutedEventArgs e)
        {
            result_tbox.Text = new Operation(val1_tbox.Text, val2_tbox.Text).Sum().ToString();
        }

        private void Sub_btn_Click(object sender, RoutedEventArgs e)
        {
            result_tbox.Text = new Operation(val1_tbox.Text, val2_tbox.Text).Subtract().ToString();

        }

        private void Mult_btn_Click(object sender, RoutedEventArgs e)
        {
            result_tbox.Text = new Operation(val1_tbox.Text, val2_tbox.Text).Multiply().ToString();

        }

        private void Div_btn_Click(object sender, RoutedEventArgs e)
        {
            result_tbox.Text = new Operation(val1_tbox.Text, val2_tbox.Text).Divide().ToString();

        }

        private void Mod_btn_Click(object sender, RoutedEventArgs e)
        {
            result_tbox.Text = new Operation(val1_tbox.Text, val2_tbox.Text).Modulo().ToString();

        }

        private void Clr_btn_Click(object sender, RoutedEventArgs e)
        {
            val1_tbox.Text   = "";
            val2_tbox.Text   = "";
            result_tbox.Text = "";
        }

        // Copypaste buttons
        private void Paste_btn_Click(object sender, RoutedEventArgs e)
        {
            switch ((sender as Button).Tag)
            {
                case "val1":
                    val1_tbox.Text = buffer;
                    break;

                case "val2":
                    val2_tbox.Text = buffer;
                    break;
            }
        }

        private void Copy_btn_Click(object sender, RoutedEventArgs e)
        {
            buffer = result_tbox.Text;
        }
    }

    class Operation
    {
        private readonly BigInteger A, B;

        public Operation(string a, string b)
        {
            BigInteger.TryParse(a, out A);
            BigInteger.TryParse(b, out B);
        }

        public BigInteger Sum()      => A + B;
        public BigInteger Subtract() => A - B;
        public BigInteger Multiply() => A * B;
        public BigInteger Divide()   => A / B;
        public BigInteger Modulo()   => A % B;
    }
}
