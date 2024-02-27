using ProyectoFinalDIN.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDIN.Modelos
{
    public class Cliente : INotifyPropertyChanged
    {
        public String Dni { get; set; }
        public String Nombre { get; set; }
        public String Apellidos { get; set; }
        public String Estado { get; set; }

        public Cliente(string dni, string nombre, string apellidos, string estado)
        {
            Dni = dni;
            Nombre = nombre;
            Apellidos = apellidos;
            Estado = estado;
            Viajes = new HashSet<Viaje>();
        }

        public void AñadirViaje(Viaje viaje)
        {
            Viajes.Add(viaje);
            OnPropertyChanged(nameof(Viajes));
        }

        private HashSet<Viaje> _viajes;
        public HashSet<Viaje> Viajes
        {
            get { return _viajes; }
            set
            {
                if (_viajes != value)
                {
                    _viajes = value;
                    OnPropertyChanged(nameof(Viajes));
                }
            }
        }

        public override string ToString()
        {
            return $"DNI: {Dni}\nNombre: {Nombre}\nApellidos: {Apellidos}\nEstado: {Estado}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}