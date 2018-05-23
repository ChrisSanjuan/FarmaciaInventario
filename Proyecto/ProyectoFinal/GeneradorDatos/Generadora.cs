using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneradorDatos
{
    public class Generadora
    {
        public Generadora()
        {
            Puntos = new List<Punto>();
        }
        public List<Punto> Puntos { get; set; }
        public List<Punto> GenerarDatos(double limiteInferior, double limiteSuperior, double incremento, int[] valor)
        {
            int i = 0;
            Puntos = new List<Punto>();
            for (double x = limiteInferior; x <= limiteSuperior; x += incremento)
            {
                Puntos.Add(new Punto(x, Evaluar(valor[i])));
                i = i + 1;
            }
            return Puntos;
        }
        public double Evaluar(int valor)
        {
            return valor;
        }
    }
}
