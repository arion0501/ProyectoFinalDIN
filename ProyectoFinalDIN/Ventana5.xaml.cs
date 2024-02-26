using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProyectoFinalDIN
{
    public partial class Ventana5 : Window
    {
        private Ventana4 ventanaPadre;

        public Ventana5(Ventana4 ventanaPadre)
        {
            InitializeComponent();
            this.ventanaPadre = ventanaPadre;

            LlenarComboBox(cbOrigen, ObtenerDatosOrigen());
            LlenarComboBox(cbDestino, ObtenerDatosDestino());
            LlenarComboBox(cbTransporte, ObtenerDatosTransporte());
            LlenarComboBox(cbHotel, ObtenerDatosHotel());
        }

        private void LlenarComboBox(ComboBox comboBox, List<string> datos)
        {
            comboBox.ItemsSource = datos;
        }

        private List<string> ObtenerDatosOrigen()
        {
            return new List<string> { "Milan", "Valencia", "Venecia" };
        }

        private List<string> ObtenerDatosDestino()
        {
            return new List<string> { "Madrid", "Barcelona", "Lisboa" };
        }

        private List<string> ObtenerDatosTransporte()
        {
            return new List<string> { "Avión", "Tren", "Autobús" };
        }

        private List<string> ObtenerDatosHotel()
        {
            return new List<string> { "Hotel", "Aparatamento", "Villa" };
        }

        private void ReservarButton_Click(object sender, RoutedEventArgs e)
        {
            string origen = cbOrigen.Text;
            string destino = cbDestino.Text;
            string transporte = cbTransporte.Text;
            string estancia = cbHotel.Text;
            DateTime? fechaIda = dpFechaIda.SelectedDate;
            DateTime? fechaVuelta = dpFechaVuelta.SelectedDate;

            if (string.IsNullOrEmpty(origen) || string.IsNullOrEmpty(destino) || string.IsNullOrEmpty(transporte) || string.IsNullOrEmpty(estancia) || !fechaIda.HasValue || !fechaVuelta.HasValue)
            {
                MessageBox.Show("Debe completar todos los campos antes de realizar la reserva.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (fechaIda > fechaVuelta)
            {
                MessageBox.Show("La fecha de vuelta debe ser posterior a la fecha de ida.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show("Reserva realizada con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                ventanaPadre.ActualizarInformacion(origen, destino, transporte, estancia, fechaIda.Value, fechaVuelta.Value, ObtenerEstadoAleatorio());

                this.Close();
            }
        }

        private string ObtenerEstadoAleatorio()
        {
            Random random = new Random();
            List<string> estados = new List<string> { "Aprobado", "Cancelado", "Pospuesto" };
            return estados[random.Next(estados.Count)];
        }
    }
}