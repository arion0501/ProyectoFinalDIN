﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoFinalDIN
{
    /// <summary>
    /// Lógica de interacción para componenteVista.xaml
    /// </summary>
    public partial class componenteVista : UserControl
    {
        public componenteVista()
        {
            InitializeComponent();
        }

        public bool RealizarAccion()
        {
            MessageBoxResult result = MessageBox.Show("¿Está seguro de que desea realizar esta acción?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question);

            return result == MessageBoxResult.Yes;
        }
    }
}