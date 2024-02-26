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
            clientesCB.Items.Add(new Cliente("06016039k", "Marcos", "Garcia-Seco", "Dado de Alta"));
            clientesCB.Items.Add(new Cliente("44295375s", "Carlos", "Guemes", "No dado de Alta"));
            clientesCB.Items.Add(new Cliente("54336198w", "Laura", "Pascal", "No Dado de Alta"));
            clientesCB.Items.Add(new Cliente("73669361h", "Luis", "Rodriguez", "No dado de Alta"));
            clientesCB.Items.Add(new Cliente("02237469z", "Ruben", "Gallardo", "Dado de Alta"));
        }

        public class Cliente
        {
            public String Dni
            { get; set; }

            public String Nombre
            { get; set; }

            public String Apellidos
            { get; set; }

            public String Estado
            { get; set; }

            public Cliente(string dni, string nombre, string apellidos, string estado)
            {

                Dni = dni;
                Nombre = nombre;
                Apellidos = apellidos;
                Estado = estado;
            }

            override
            public String ToString()
            {
                return ("DNI: " + Dni + "\nNombre: " + Nombre + "\nApellidos: " + Apellidos + "\nEstado: " + Estado);
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
                MessageBox.Show("Información del cliente seleccionado:\n" + clienteSeleccionado.ToString(), "Información del Cliente", MessageBoxButton.OK, MessageBoxImage.Information);
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
                componente.realizarAccion();
                clientesCB.Items.Remove(clientesCB.SelectedItem);
            }
        }

        private void AñadirElemento_Click(object sender, RoutedEventArgs e)
        {
            vistaAnyadirCliente vistaAnyadir = new vistaAnyadirCliente(this);
            vistaAnyadir.Show();

            this.Close();
        }
    }
}
