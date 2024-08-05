using System;

namespace caracteristicasAutos{
    public class Caracteristicas{
        private string marca;
        private string modelo;
        private int velocidadMaxima;
        private int aceleracion;
        private int potencia;
        private int maniobrabilidad;
        private int velocidadPromedioDeCarrera;
        public Caracteristicas(){
            velocidadMaxima  = GenerarAleatorio(90,240);
            aceleracion = GenerarAleatorio(9,25);
            potencia = GenerarAleatorio(80, 175);
            maniobrabilidad = GenerarAleatorio(1,10);
            velocidadPromedioDeCarrera = CalcularVelPromedio(velocidadMaxima,aceleracion,potencia,maniobrabilidad);
        }
        public int CalcularVelPromedio(int velMax, int acel, int pot, int manio){
            return (velMax*acel*pot*manio/1000);
        }
        public int GenerarAleatorio(int min, int max){
            return new Random().Next(min,max);
        }
    }
}