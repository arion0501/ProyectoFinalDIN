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
using static ProyectoFinalDIN.vistaClientes;

namespace ProyectoFinalDIN
{
    /// <summary>
    /// Lógica de interacción para Ventana4.xaml
    /// </summary>
    public partial class vistaViajes : Window
    {
        private List<ModeloGlobal.Cliente> ListaClientes;

        public vistaViajes()
        {
            InitializeComponent();
            listViajes.Items.Add(new ModeloGlobal.Viaje("Paris", "Lisboa", "Avión", "Hotel", DateTime.Now, DateTime.Now.AddDays(4), "Cancelado"));
            listViajes.Items.Add(new ModeloGlobal.Viaje("Valencia", "Barcelona", "Tren", "Apartamento", DateTime.Now, DateTime.Now.AddDays(5), "Pospuesto"));
            listViajes.Items.Add(new ModeloGlobal.Viaje("Madrid", "Galicia", "Helicóptero", "Villa", DateTime.Now, DateTime.Now.AddDays(2), "Aprobado"));
            listViajes.Items.Add(new ModeloGlobal.Viaje("Ibiza", "Roma", "Avión", "Hotel", DateTime.Now, DateTime.Now.AddDays(1), "Aprobado"));
            listViajes.Items.Add(new ModeloGlobal.Viaje("Dublín", "Edinburgo", "Ave", "Apartamento", DateTime.Now, DateTime.Now.AddDays(6), "Cancelado"));
        }

       

        private void VolverAVentanaAnterior_Click(object sender, RoutedEventArgs e)
        {
            vistaMenuInicio vistaMenu = new vistaMenuInicio();
            vistaMenu.Show();

            this.Close();
        }

        private void AñadirElemento_Click(object sender, RoutedEventArgs e)
        {
            this.IsEnabled = false;
            vistaAnyadirViaje vistaAnyadir = new vistaAnyadirViaje(this);
            vistaAnyadir.Closed += VistaAnyadir_Closed;
            vistaAnyadir.Show();
        }


        private void VistaAnyadir_Closed(object sender, EventArgs e)
        {
            this.IsEnabled = true;
        }

        public void ActualizarInformacion(string origen, string destino, string transporte, string estancia, DateTime fechaIda, DateTime fechaVuelta, string estado)
        {
            ModeloGlobal.Viaje nuevoViaje = new ModeloGlobal.Viaje(origen, destino, transporte, estancia, fechaIda, fechaVuelta, estado);
            listViajes.Items.Add(nuevoViaje);

            foreach (ModeloGlobal.Cliente cliente in ListaClientes)
            {
                cliente.Viajes.Add(nuevoViaje);
            }
        }

        private void visualizarInfoViaje_Click(object sender, RoutedEventArgs e)
        {
            if (listViajes.SelectedItem != null)
            {
                ModeloGlobal.Viaje viajeSeleccionado = (ModeloGlobal.Viaje)listViajes.SelectedItem;
                MessageBox.Show("Información del viaje seleccionado:\n" + viajeSeleccionado.ToString(), "Información del Viaje", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Selecciona un viaje para ver la información.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BorrarElemento_Click(object sender, RoutedEventArgs e)
        {
            if (listViajes.SelectedItem != null)
            {
                componenteVista componente = new componenteVista();

                bool confirmacion = componente.RealizarAccion();

                if (confirmacion)
                {
                    listViajes.Items.Remove(listViajes.SelectedItem);
                }
            }
            else
            {
                MessageBox.Show("Selecciona un viaje para borrar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
