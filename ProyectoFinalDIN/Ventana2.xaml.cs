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
using System.Windows.Shapes;

namespace ProyectoFinalDIN
{
    /// <summary>
    /// Lógica de interacción para Ventana2.xaml
    /// </summary>
    public partial class Ventana2 : Window
    {
        public Ventana2()
        {
            InitializeComponent();
        }

        private void gestionCliente_Click(object sender, RoutedEventArgs e)
        {
            Ventana3 ventana3 = new Ventana3();
            ventana3.Show();

            this.Close();
        }

        private void gestionViaje_Click(object sender, RoutedEventArgs e)
        {
            Ventana4 ventana4 = new Ventana4();
            ventana4.Show();

            this.Close();
        }

        private void VolverAVentanaAnterior_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            inicio.Show();

            this.Close();
        }
    }
}