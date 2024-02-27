using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalDIN.Modelos
{
    internal class ModeloGlobal
    {
        public class Cliente
        {
            public String Dni { get; set; }
            public String Nombre { get; set; }
            public String Apellidos { get; set; }
            public String Estado { get; set; }
            public List<Viaje> Viajes { get; set; } = new List<Viaje>();

            public Cliente(string dni, string nombre, string apellidos, string estado)
            {
                Dni = dni;
                Nombre = nombre;
                Apellidos = apellidos;
                Estado = estado;
            }

            public override string ToString()
            {
                return $"DNI: {Dni}\nNombre: {Nombre}\nApellidos: {Apellidos}\nEstado: {Estado}";
            }
        }

        public class Viaje
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
                return $"{Origen} -> {Destino}\nTransporte: {Transporte}\nEstancia: {Estancia}\nFecha Ida: {FechaIda.ToString()} / Vuelta: {FechaVuelta.ToString()}\nEstado: {Estado}";
            }
        }
    }
}