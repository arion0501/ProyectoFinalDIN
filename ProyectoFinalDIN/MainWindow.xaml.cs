using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

namespace ProyectoFinalDIN
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            TextBoxDNI.Text = "Introduzca DNI";
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxDNI.Text == "Introduzca DNI")
            {
                TextBoxDNI.Text = "";
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextBoxDNI.Text))
            {
                TextBoxDNI.Text = "Introduzca DNI";
            }
        }

        public static bool ValidarDNI(string dni)
        {
            if (dni.Length != 9)
            {
                return false;
            }

            string digitos = dni.Substring(0, 8);
            char letra = char.ToUpper(dni[8]);

            int numero;
            if (!int.TryParse(digitos, out numero))
            {
                return false;
            }

            string letras = "TRWAGMYFPDXBNJZSQVHLCKE";
            int resto = numero % 23;

            return letra == letras[resto];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string dniIngresado = TextBoxDNI.Text;
            Ventana2 ventana2 = new Ventana2();

            if (ValidarDNI(dniIngresado))
            {
                ventana2.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("DNI incorrecto. Inténtalo de nuevo.", "Error de inicio de sesión", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
