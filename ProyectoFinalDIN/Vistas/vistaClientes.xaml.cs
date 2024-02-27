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
        private List<Viaje> viajesDisponibles;

        public vistaClientes()
        {
            InitializeComponent();

            viajesDisponibles = new List<Viaje>
            {
                new Viaje("Paris", "Lisboa", "Avión", "Hotel", DateTime.Now, DateTime.Now.AddDays(4), "Cancelado"),
                new Viaje("Valencia", "Barcelona", "Tren", "Apartamento", DateTime.Now, DateTime.Now.AddDays(5), "Pospuesto"),
                new Viaje("Madrid", "Galicia", "Helicóptero", "Villa", DateTime.Now, DateTime.Now.AddDays(2), "Aprobado"),
                new Viaje("Ibiza", "Roma", "Avión", "Hotel", DateTime.Now, DateTime.Now.AddDays(1), "Aprobado"),
                new Viaje("Dublín", "Edinburgo", "Ave", "Apartamento", DateTime.Now, DateTime.Now.AddDays(6), "Cancelado")
            };

            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente("06016039k", "Marcos", "Garcia-Seco", "Dado de Alta"),
                new Cliente("44295375s", "Carlos", "Guemes", "No dado de Alta"),
                new Cliente("54336198w", "Laura", "Pascal", "No Dado de Alta"),
                new Cliente("73669361h", "Luis", "Rodriguez", "No dado de Alta"),
                new Cliente("02237469z", "Ruben", "Gallardo", "Dado de Alta")
            };

            foreach (Cliente cliente in clientes)
            {
                Random random = new Random();
                if (viajesDisponibles.Count > 0)
                {
                    int indexViajeAleatorio = random.Next(viajesDisponibles.Count);
                    Viaje viajeAsignado = viajesDisponibles[indexViajeAleatorio];
                    cliente.AñadirViaje(viajeAsignado);
                    viajesDisponibles.RemoveAt(indexViajeAleatorio);
                }
            }

            foreach (Cliente cliente in clientes)
            {
                this.clientesCB.Items.Add(cliente);
            }
        }

        private void VolverAVentanaAnterior_Click(object sender, RoutedEventArgs e)
        {
            vistaMenuInicio vistaMenu = new vistaMenuInicio();
            vistaMenu.Show();

            this.Close();
        }

        private void visualizarInfoCliente_Click(object sender, RoutedEventArgs e)
        {
            if (clientesCB.SelectedItem != null)
            {
                Cliente clienteSeleccionado = (Cliente)clientesCB.SelectedItem;

                string infoCliente = $"Información del cliente seleccionado:\n{clienteSeleccionado}\n\nViajes:\n";

                if (clienteSeleccionado.Viajes.Count > 0)
                {
                    infoCliente += string.Join("\n", clienteSeleccionado.Viajes.Select(v => v.ToString()));
                }
                else
                {
                    infoCliente += "Este cliente no tiene viajes asignados.";
                }

                MessageBox.Show(infoCliente, "Información del Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Selecciona un cliente para ver la información.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
            else
            {
                MessageBox.Show("Selecciona un cliente para borrar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
