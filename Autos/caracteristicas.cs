using System;

namespace caracteristicasAutos{
    public class Caracteristicas{
        private string marca;
        private string modelo;
        private int velocidadMaxima;
        private int aceleracion;
        private int potencia;
        private int velocidadPromedioDeCarrera;

        public int GenerarAleatorio(int min, int max){
            return new Random().Next(min,max);
        }
    }
}