using ProyectoFinalDIN.Modelos;
using ProyectoFinalDIN.Vistas;
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
using static ProyectoFinalDIN.vistaViajes;

namespace ProyectoFinalDIN
{
    /// <summary>
    /// Lógica de interacción para Ventana3.xaml
    /// </summary>
    public partial class vistaClientes : Window
    {
        public vistaClientes()
        {
            InitializeComponent();
            this.DataContext = this;

            this.listaClientes.Add(new ModeloGlobal.Cliente("06016039k", "Marcos", "Garcia-Seco", "Dado de Alta"));
            this.listaClientes.Add(new ModeloGlobal.Cliente("44295375s", "Carlos", "Guemes", "No dado de Alta"));
            this.listaClientes.Add(new ModeloGlobal.Cliente("54336198w", "Laura", "Pascal", "No Dado de Alta"));
            this.listaClientes.Add(new ModeloGlobal.Cliente("73669361h", "Luis", "Rodriguez", "No dado de Alta"));
            this.listaClientes.Add(new ModeloGlobal.Cliente("02237469z", "Ruben", "Gallardo", "Dado de Alta"));
        }

        private List<ModeloGlobal.Cliente> listaClientes = new List<ModeloGlobal.Cliente>();

        private void VolverAVentanaAnterior_Click(object sender, RoutedEventArgs e)
        {
            vistaMenuInicio vistaMenu = new vistaMenuInicio();
            vistaMenu.Show();

            this.Close();
        }

        private void visualizarInfoCliente_Click(object sender, RoutedEventArgs e)
        {
            if (listaClientes.Any())
            {
                if (clientesCB.SelectedItem != null)
                {
                    ModeloGlobal.Cliente clienteSeleccionado = (ModeloGlobal.Cliente)clientesCB.SelectedItem;
                    MessageBox.Show("Información del cliente seleccionado:\n" + clienteSeleccionado.ToString() + "\n\nViajes:\n" + string.Join("\n", clienteSeleccionado.Viajes.Select(v => v.ToString())), "Información del Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Selecciona un cliente para ver la información.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("La lista de clientes está vacía.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarElemento_Click(object sender, RoutedEventArgs e)
        {
            if (clientesCB.SelectedItem != null)
            {
                componenteVista componente = new componenteVista();

                bool confirmacion = componente.RealizarAccion();

                if (confirmacion)
                {
                    clientesCB.Items.Remove(clientesCB.SelectedItem);
                }
            }
        }

        private void AñadirElemento_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;

            vistaAnyadirCliente vistaAnyadir = new vistaAnyadirCliente(this);
            vistaAnyadir.Closed += VistaAnyadir_Closed;
            vistaAnyadir.Show();
        }

        private void VistaAnyadir_Closed(object sender, EventArgs e)
        {
            this.IsEnabled = true;
        }
    }
}
