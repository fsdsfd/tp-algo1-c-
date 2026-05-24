using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Figuras
{
    public partial class Form1 : Form
    {
        Figura[] figuras;

        public Form1()
        {
            InitializeComponent();
figuras = new Figura[5] 
{
    new Circulo(40),
    new Cuadrado(60),
    new TrianguloEquilatero(70),
    new TrianguloIsosceles(80,60),
    new Rectangulo(50,70)

};

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics gr = pictureBox1.CreateGraphics();
Random rnd = new Random();

for (int i = 0; i < figuras.Length; i++)
{
Color colorRandom = Color.FromArgb(
    rnd.Next(0, 200),
    rnd.Next(0, 200),
    rnd.Next(0, 200)
);

    Pen pen = new Pen(colorRandom);
    figuras[i].Dibujar(pen, gr, i * 80, 50);
}

        }
    }
}