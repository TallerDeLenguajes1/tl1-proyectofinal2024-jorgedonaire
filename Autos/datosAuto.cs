using System;

namespace DatosAuto{
    public class Datos{
        public string Marca {get; set;}
        public string Modelo {get; set;}
        public DateTime FechaGanador{get; set;}
        public Datos(string marca, string modelo){
            Marca = marca;
            Modelo = modelo;
        }
    }
}