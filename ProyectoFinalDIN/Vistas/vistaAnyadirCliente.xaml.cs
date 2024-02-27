using ProyectoFinalDIN.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public static bool ValidarDNI(string dni)
        {
            if (dni.Length != 9)
            {
                return false;
            }

            string digitos = dni.Substring(0, 8);
            char letra = char.ToUpper(dni[8]);

            int numero;
            if (!int.TryParse(digitos, out numero))
            {
                return false;
            }

            string letras = "TRWAGMYFPDXBNJZSQVHLCKE";
            int resto = numero % 23;

            return letra == letras[resto];
        }

        private void btnGuardarCliente_Click(object sender, RoutedEventArgs e)
        {
            string dni = txtDni.Text;
            string nombre = txtNombre.Text;
            string apellidos = txtApellidos.Text;
            string estado = CBAlta.IsChecked.GetValueOrDefault() ? "Dado de Alta" : "No Dado de Alta";

            if (!string.IsNullOrWhiteSpace(dni) && !string.IsNullOrWhiteSpace(nombre) && !string.IsNullOrWhiteSpace(apellidos))
                {
                if (ValidarDNI(dni)) { 
                    Cliente nuevoCliente = new Cliente(dni, nombre, apellidos, estado);

                ventanaPadre.clientesCB.Items.Add(nuevoCliente);

                MessageBox.Show("Cliente añadido con éxito.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                this.Close();
                }
                else
                {
                    MessageBox.Show("Introduzca un formate de DNI válido.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void VolverAVentanaAnterior_Click(object sender, RoutedEventArgs e)
        {
            componenteVista componente = new componenteVista();

            bool confirmacion = componente.RealizarAccion();

            if (confirmacion)
            {
                this.Close();
            }
        }
    }
}
