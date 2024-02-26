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
    public partial class vistaMenuInicio : Window
    {
        public vistaMenuInicio()
        {
            InitializeComponent();
        }

        private void gestionCliente_Click(object sender, RoutedEventArgs e)
        {
            vistaClientes vClientes = new vistaClientes();
            vClientes.Show();

            this.Close();
        }

        private void gestionViaje_Click(object sender, RoutedEventArgs e)
        {
            vistaViajes v_Viajes = new vistaViajes();
            v_Viajes.Show();

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