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
    /// Lógica de interacción para Ventana3.xaml
    /// </summary>
    public partial class Ventana3 : Window
    {
        public Ventana3()
        {
            InitializeComponent();
            clientesCB.Items.Add("Marcos");
            clientesCB.Items.Add("Carlos");
            clientesCB.Items.Add("Manuel");
            clientesCB.Items.Add("Ismael");
            clientesCB.Items.Add("Laura");
        }

        private void VolverAVentanaAnterior_Click(object sender, RoutedEventArgs e)
        {
            Ventana2 ventana2 = new Ventana2();
            ventana2.Show();

            this.Close();
        }

        private void clientesCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (clientesCB.SelectedItem != null)
            {
                MessageBox.Show("Cliente: " + clientesCB.SelectedItem.ToString(), 
                    "Info del cliente");
            }
        }

        private void EliminarElemento_Click(object sender, RoutedEventArgs e)
        {
            if (clientesCB.SelectedItem != null)
            {
                componenteVista componente = new componenteVista();
                componente.realizarAccion();
                clientesCB.Items.Remove(clientesCB.SelectedItem);
            }
        }
    }
}
