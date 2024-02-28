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

namespace ProyectoFinalDIN.Vistas
{
    /// <summary>
    /// Lógica de interacción para vistaPago.xaml
    /// </summary>
    public partial class vistaPago : Window
    {
        public bool PagoExitoso { get; set; }
        public vistaPago(int costoReserva)
        {
            InitializeComponent();
            txtCosto.Content = $"El coste de la reserva es de {costoReserva}€";
            PagoExitoso = false;
        }

        private void AceptarPago_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea usar este método de pago?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result.Equals(MessageBoxResult.Yes))
            {
                MessageBox.Show("El pago se ha realizado con éxito, ¡Muchas gracias!", "Pago Exitoso", MessageBoxButton.OK, MessageBoxImage.Information);
                PagoExitoso = true;
                this.Close();
            }
            else
            {

            }
        }

        private void CancelarPago_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult confirmacionCancelar = MessageBox.Show("¿Está seguro de que desea cancelar el pago?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirmacionCancelar == MessageBoxResult.Yes)
            {
                MessageBox.Show("Pago cancelado", "Cancelación", MessageBoxButton.OK, MessageBoxImage.Information);
                PagoExitoso = false;

                this.Close();
            }
        } 
    }
}