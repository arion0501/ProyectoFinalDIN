using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDIN.Modelos
{
    public class Viaje : INotifyPropertyChanged
    {
        public String Origen { get; set; }
        public String Destino { get; set; }
        public String Transporte { get; set; }
        public String Estancia { get; set; }
        public DateTime FechaIda { get; set; }
        public DateTime FechaVuelta { get; set; }
        public String Estado { get; set; }

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

        public override string ToString()
        {
            return $"Itinerario: {Origen} -> {Destino}\nTransporte: {Transporte}\nEstancia: {Estancia}\nFecha Ida: {FechaIda.ToString()} / Vuelta: {FechaVuelta.ToString()}\nEstado: {Estado}";
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

