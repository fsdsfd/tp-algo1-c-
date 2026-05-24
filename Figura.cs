using System;
using System.Drawing;

namespace Figuras
{
    public class Figura
    {
        public virtual void Dibujar(Pen pen, Graphics graphics, int x, int y)
        { 
            
        }
    }


    public class Rectangulo : Figura
    {
        protected int alto;
        protected int ancho;
        
        // Constructor
        public Rectangulo(int ancho, int alto) 
        {
            this.ancho = ancho;
            this.alto = alto;
        }

        public override void Dibujar(Pen pen, Graphics graphics, int x, int y)
        {
            Point[] points = new Point[4]
            { 
                new Point(x,y), 
                new Point(x+ancho,y), 
                new Point(x+ancho,y+alto), 
                new Point(x,y+alto) 
            };
            // DrawPolygon dibuja un poligono dado un conjunto de puntos y un lapiz
            graphics.DrawPolygon(pen, points);
        }
    }

    public class Cuadrado : Rectangulo
    {
        // Constructor. Un cuadrado es un rectangulo con ancho = alto
        public Cuadrado(int lado) : base(lado,lado)
        {
        }
    }


    public class Circulo : Figura
    {
        private int radio;

        // Constructor
        public Circulo(int radio)
        {
            this.radio= radio;
        }

        public override void Dibujar(Pen pen, Graphics graphics, int x, int y)
        {
            graphics.DrawEllipse(pen,x,y, radio, radio);
        }
    }
    public class TrianguloIsosceles : Figura
{
    private int baseTri;
    private int altura;

    public TrianguloIsosceles(int baseTri, int altura)
    {
        this.baseTri = baseTri;
        this.altura = altura;
    }

    public override void Dibujar(Pen pen, Graphics graphics, int x, int y)
    {
        Point[] puntos = new Point[3]
        {
            new Point(x, y + altura),                  // izquierda
            new Point(x + baseTri, y + altura),        // derecha
            new Point(x + baseTri / 2, y)              // arriba
        };

        graphics.DrawPolygon(pen, puntos);
    }
}
public class TrianguloEquilatero : Figura
{
    private int lado;

    public TrianguloEquilatero(int lado)
    {
        this.lado = lado;
    }

    public override void Dibujar(Pen pen, Graphics graphics, int x, int y)
    {
        double altura = (Math.Sqrt(3) / 2) * lado;

        Point[] puntos = new Point[3]
        {
            new Point(x, y + (int)altura),
            new Point(x + lado, y + (int)altura),
            new Point(x + lado / 2, y)
        };

        graphics.DrawPolygon(pen, puntos);
    }
}
}
