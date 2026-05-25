# Trabajo Practico C#

Proyecto realizado para la materia **Algoritmos y Programacion I**.

La aplicacion esta desarrollada en **C#** con **Windows Forms**. El objetivo principal del trabajo es aplicar conceptos de programacion orientada a objetos mediante una jerarquia de figuras geometricas que se dibujan en pantalla usando metodos virtuales y polimorfismo.

## Integrantes

- fsdsfd (Tomas Marcos)
- Mishardo (David Veron)
- RenggliMoney (Tomas Renggli)

## Objetivo del trabajo

El programa busca demostrar como una clase base puede definir un comportamiento general y como las clases derivadas pueden modificar ese comportamiento segun sus propias caracteristicas.

Para eso se utiliza una clase principal llamada `Figura`, que contiene el metodo virtual `Dibujar`. Cada figura especifica hereda de esa clase y sobrescribe el metodo para dibujarse de una manera distinta.

De esta forma, el formulario puede recorrer un arreglo de objetos `Figura` y llamar al mismo metodo `Dibujar`, sin necesitar saber exactamente si el objeto es un circulo, un cuadrado, un rectangulo o un triangulo.

## Tecnologias utilizadas

- Lenguaje: C#
- Tipo de aplicacion: Windows Forms
- Framework: .NET Framework 4.0
- Librerias principales:
  - `System`
  - `System.Drawing`
  - `System.Windows.Forms`

## Conceptos aplicados

- Programacion orientada a objetos.
- Clases y objetos.
- Herencia.
- Metodos virtuales.
- Sobrescritura de metodos.
- Polimorfismo.
- Constructores.
- Arreglos de objetos.
- Eventos en Windows Forms.
- Dibujo en pantalla con `Graphics`.
- Uso de `Pen`, `Color` y `Point`.

## Estructura del proyecto

### `Program.cs`

Contiene el punto de entrada principal de la aplicacion. Desde este archivo se inicia Windows Forms y se abre el formulario principal:

```csharp
Application.Run(new Form1());
```

### `Form1.cs`

Contiene la logica principal del formulario.

En este archivo se declara un arreglo de figuras:

```csharp
Figura[] figuras;
```

Luego, dentro del constructor de `Form1`, se inicializa el arreglo con distintos objetos:

```csharp
figuras = new Figura[5]
{
    new Circulo(40),
    new Cuadrado(60),
    new TrianguloEquilatero(70),
    new TrianguloIsosceles(80, 60),
    new Rectangulo(50, 70)
};
```

Cuando el usuario presiona el boton **Dibujar**, se ejecuta el evento `button1_Click`. En ese metodo se obtiene el objeto `Graphics` del `PictureBox`, se genera un color aleatorio para cada figura y se llama al metodo `Dibujar` de cada objeto.

### `Form1.Designer.cs`

Contiene la configuracion visual del formulario generada por Windows Forms Designer.

En este archivo se definen los controles de la interfaz, principalmente:

- El boton **Dibujar**.
- El `PictureBox` donde se muestran las figuras.

Tambien se conecta el evento del boton con el metodo:

```csharp
this.dibujarButton.Click += new System.EventHandler(this.button1_Click);
```

### `Figura.cs`

Contiene la clase base `Figura` y las clases derivadas que representan las figuras geometricas.

La clase base define el metodo virtual:

```csharp
public virtual void Dibujar(Pen pen, Graphics graphics, int x, int y)
{
}
```

Las clases derivadas sobrescriben ese metodo para dibujar cada figura de forma especifica.

## Clases del proyecto

### `Figura`

Es la clase base del proyecto. Define el comportamiento general de una figura mediante el metodo virtual `Dibujar`.

No dibuja nada por si sola, pero permite que todas las figuras compartan una misma interfaz.

### `Circulo`

Representa un circulo. Recibe un radio en el constructor y utiliza `DrawEllipse` para dibujarse.

```csharp
graphics.DrawEllipse(pen, x, y, radio, radio);
```

### `Rectangulo`

Representa un rectangulo. Recibe ancho y alto en el constructor. Para dibujarse arma un arreglo de cuatro puntos y utiliza `DrawPolygon`.

### `Cuadrado`

Representa un cuadrado. Hereda de `Rectangulo`, ya que un cuadrado es un rectangulo con el mismo ancho y alto.

Su constructor recibe un solo valor, el lado, y se lo pasa dos veces al constructor de `Rectangulo`.

### `TrianguloEquilatero`

Representa un triangulo equilatero. Recibe el lado en el constructor y calcula su altura usando la formula:

```csharp
altura = (Math.Sqrt(3) / 2) * lado;
```

Luego dibuja el triangulo usando tres puntos.

### `TrianguloIsosceles`

Representa un triangulo isosceles. Recibe la base y la altura en el constructor. Con esos valores calcula los tres puntos necesarios para dibujarlo.

## Funcionamiento del programa

1. Se ejecuta la aplicacion.
2. `Program.cs` abre el formulario principal `Form1`.
3. El constructor de `Form1` llama a `InitializeComponent()`.
4. Despues se crea un arreglo con cinco figuras geometricas.
5. El usuario presiona el boton **Dibujar**.
6. El programa obtiene el area de dibujo del `PictureBox`.
7. Se genera un color aleatorio para cada figura.
8. Se recorre el arreglo de figuras con un ciclo `for`.
9. Cada objeto ejecuta su propio metodo `Dibujar`.
10. Las figuras aparecen dibujadas dentro del `PictureBox`.

## Uso de polimorfismo

Una parte importante del trabajo es que el arreglo esta declarado como:

```csharp
Figura[] figuras;
```

Aunque el arreglo es de tipo `Figura`, dentro contiene objetos de distintas clases:

- `Circulo`
- `Cuadrado`
- `TrianguloEquilatero`
- `TrianguloIsosceles`
- `Rectangulo`

Cuando se ejecuta:

```csharp
figuras[i].Dibujar(pen, gr, i * 80, 50);
```

C# decide automaticamente que version del metodo `Dibujar` corresponde ejecutar segun el tipo real del objeto. Ese comportamiento es el polimorfismo.

## Interfaz grafica

La interfaz esta compuesta por:

- Un boton para ejecutar el dibujo.
- Un `PictureBox` que funciona como superficie de dibujo.

El evento del boton es el encargado de iniciar el recorrido del arreglo y dibujar todas las figuras.

## Requisitos para compilar

Para compilar correctamente el proyecto se necesita:

- Visual Studio con soporte para Windows Forms.
- .NET Framework 4.0 Developer Pack.

El archivo `.csproj` del proyecto apunta a:

```xml
<TargetFrameworkVersion>v4.0</TargetFrameworkVersion>
```

Por eso, si se intenta compilar en una computadora que no tenga instalado el paquete de desarrollo de .NET Framework 4.0, puede aparecer un error indicando que no se encuentran los ensamblados de referencia.

## Como ejecutar el proyecto

1. Abrir el proyecto en Visual Studio.
2. Verificar que este instalado .NET Framework 4.0 Developer Pack.
3. Compilar la solucion.
4. Ejecutar la aplicacion.
5. Presionar el boton **Dibujar** para ver las figuras en pantalla.

## Posible error de compilacion

Si aparece un error similar a:

```text
No se encuentran los ensamblados de referencia para .NETFramework,Version=v4.0
```

significa que falta instalar el paquete de desarrollo correspondiente a .NET Framework 4.0 o que el proyecto deberia ser redestinado a otra version instalada del framework.

## Conclusion

Este proyecto muestra de forma practica como usar herencia, metodos virtuales y polimorfismo en C#. Todas las figuras comparten una clase base, pero cada una implementa su propia forma de dibujarse. Esto permite que el formulario trabaje con objetos diferentes usando una misma llamada al metodo `Dibujar`.
