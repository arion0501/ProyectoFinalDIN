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
    /// Lógica de interacción para vistaAnyadirCliente.xaml
    /// </summary>
    public partial class vistaAnyadirCliente : Window
    {
        public vistaAnyadirCliente()
        {
            InitializeComponent();
        }

        private vistaClientes ventanaPadre;

        public vistaAnyadirCliente(vistaClientes ventanaPadre)
        {
            InitializeComponent();
            this.ventanaPadre = ventanaPadre;
        }
        private void btnGuardarCliente_Click(object sender, RoutedEventArgs e)
        {
            string dni = txtDni.Text;
            string nombre = txtNombre.Text;
            string apellidos = txtApellidos.Text;
            string estado = CBAlta.IsChecked.GetValueOrDefault() ? "Dado de Alta" : "No Dado de Alta";

            // Validar que se ingresen todos los campos necesarios
            if (!string.IsNullOrWhiteSpace(dni) && !string.IsNullOrWhiteSpace(nombre) && !string.IsNullOrWhiteSpace(apellidos))
            {
                // Crear un nuevo objeto Cliente con los datos ingresados
                vistaClientes.Cliente nuevoCliente = new vistaClientes.Cliente(dni, nombre, apellidos, estado);

                // Agregar el nuevo cliente a la lista en la ventana padre
                ventanaPadre.clientesCB.Items.Add(nuevoCliente);

                // Cerrar la ventana de añadir cliente
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
