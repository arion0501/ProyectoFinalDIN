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
    public partial class Ventana4 : Window
    {
        public Ventana4()
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
                return (Origen + " / " + Destino + ". Transporte: " + Transporte + " , Estancia: " + Estancia + ". Fecha Ida: " + FechaIda.ToString() + " / Vuelta: " + FechaVuelta.ToString() + ". Estado: " + Estado);
            }
        }

        private void VolverAVentanaAnterior_Click(object sender, RoutedEventArgs e)
        {
            Ventana2 ventana2 = new Ventana2();
            ventana2.Show();

            this.Close();
        }

        private void listViajes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(listViajes != null)
            {
                MessageBox.Show("La información del viaje seleccionado es: " + listViajes.SelectedItem.ToString());
            }
        }

        private void AñadirElemento_Click(object sender, RoutedEventArgs e)
        {
            Ventana5 ventana5 = new Ventana5(this);
            ventana5.Show();
        }

        public void ActualizarInformacion(string origen, string destino, string transporte, string estancia, DateTime fechaIda, DateTime fechaVuelta, string estado)
        {
            Viaje nuevoViaje = new Viaje(origen, destino, transporte, estancia, fechaIda, fechaVuelta, estado);
            listViajes.Items.Add(nuevoViaje);
        }
    }
}
