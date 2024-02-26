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
    /// Lógica de interacción para Ventana4.xaml
    /// </summary>
    public partial class vistaViajes : Window
    {
        public vistaViajes()
        {
            InitializeComponent();
            listViajes.Items.Add(new Viaje("Paris", "Lisboa", "Avión", "Hotel", DateTime.Now, DateTime.Now.AddDays(4), "Cancelado"));
            listViajes.Items.Add(new Viaje("Valencia", "Barcelona", "Tren", "Apartamento", DateTime.Now, DateTime.Now.AddDays(5), "Pospuesto"));
            listViajes.Items.Add(new Viaje("Madrid", "Galicia", "Helicóptero", "Villa", DateTime.Now, DateTime.Now.AddDays(2), "Aprobado"));
        }

        public class Viaje
        {
            public String Origen
            { get; set; }

            public String Destino
            { get; set; }

            public String Transporte
            { get; set; }

            public String Estancia
            { get; set; }

            public DateTime FechaIda
            { get; set; }

            public DateTime FechaVuelta
            { get; set; }

            public String Estado
            { get; set; }

            public Viaje(string origen, string destino, string transporte, string estancia, DateTime fechaida, DateTime fechavuelta, String estado)
            {

                Origen = origen;
                Destino = destino;
                Transporte = transporte;
                Estancia = estancia;
                FechaIda = fechaida;
                FechaVuelta = fechavuelta;
                Estado = estado;
            }

            override
            public String ToString()
            {
                return (Origen + " -> " + Destino + "\nTransporte: " + Transporte + "\nEstancia: " + Estancia + "\nFecha Ida: " + FechaIda.ToString() + " / Vuelta: " + FechaVuelta.ToString() + "\nEstado: " + Estado);
            }
        }

        private void VolverAVentanaAnterior_Click(object sender, RoutedEventArgs e)
        {
            vistaMenuInicio vistaMenu = new vistaMenuInicio();
            vistaMenu.Show();

            this.Close();
        }

        private void AñadirElemento_Click(object sender, RoutedEventArgs e)
        {
            vistaAnyadirViaje vistaAnyadir = new vistaAnyadirViaje(this);
            vistaAnyadir.Show();
            
            this.Close();
        }

        public void ActualizarInformacion(string origen, string destino, string transporte, string estancia, DateTime fechaIda, DateTime fechaVuelta, string estado)
        {
            Viaje nuevoViaje = new Viaje(origen, destino, transporte, estancia, fechaIda, fechaVuelta, estado);
            listViajes.Items.Add(nuevoViaje);
        }

        private void visualizarInfoViaje_Click(object sender, RoutedEventArgs e)
        {
            if (listViajes.SelectedItem != null)
            {
                Viaje viajeSeleccionado = (Viaje)listViajes.SelectedItem;
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
                listViajes.Items.Remove(listViajes.SelectedItem);
            }
            else
            {
                MessageBox.Show("Selecciona un viaje para borrar.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
