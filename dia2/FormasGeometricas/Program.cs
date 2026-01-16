using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormasGeometricas
{
    class Program
    {
        static void Main(string[] args)
        {

            Circulo circle = new Circulo(30);
            Retangulo retangle = new Retangulo(10,20);
            Quadrado square = new Quadrado(10);

            circle.ImprimirValores();
            retangle.ImprimirValores();
            square.ImprimirValores();
        }

    }
    public abstract class FormaGeometrica
        {
            public abstract double CalcularArea();
            public abstract double CalcularPerimetro();
            public void ImprimirValores(){

            var formaGeometrica = TypeDescriptor.GetClassName(this);
            Console.WriteLine("classe " + formaGeometrica +  "Area: " + this.CalcularArea() + " Perímetro: " + this.CalcularPerimetro());
        }


        }

    public class Retangulo : FormaGeometrica
        {

            double baseRetangulo;
            double alturaRetangulo;

            public Retangulo(double _base, double _altura)
            {
                this.baseRetangulo = _base;
                this.alturaRetangulo = _altura;
            }

            public override double CalcularArea()
            {
      
                return this.baseRetangulo*this.alturaRetangulo;
            }

            public override double CalcularPerimetro()
            {

                return 2*(this.baseRetangulo + this.alturaRetangulo);
            }


    }

        public class Circulo : FormaGeometrica
        {

            double raio;

            public Circulo(double _raio)
            {
                this.raio = _raio;
            }

            public override double CalcularArea()
            {

                return Math.PI*Math.Pow(this.raio,2);
            }

            public override double CalcularPerimetro()
            {

                return 2 * (Math.PI * this.raio);
            }
    }
    

    public class Quadrado : FormaGeometrica
    {

        double lado;

        public Quadrado(double lado)
        {
            this.lado = lado;
        }

        public override double CalcularArea()
        {

            return Math.Pow(this.lado, 2);
        }

        public override double CalcularPerimetro()
        {

            return 4 *this.lado;
        }

    }

}

