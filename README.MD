# Figuras Geometricas en C#

Trabajo practico de **Algoritmos y Programacion I** desarrollado en **C#** con **Windows Forms**.

El proyecto muestra como aplicar **programacion orientada a objetos**, **herencia**, **metodos virtuales** y **polimorfismo** a traves de una aplicacion grafica que dibuja distintas figuras geometricas en pantalla.

---

## Integrantes

| Integrante | Usuario |
| --- | --- |
| Tomas Marcos | `fsdsfd` |
| David Veron | `Mishardo` |
| RenggliMoney | `RenggliMoney` |

---

## Objetivo

El objetivo del trabajo es demostrar como una clase base puede definir un comportamiento general y como las clases derivadas pueden personalizar ese comportamiento.

Para eso se utiliza una clase principal llamada `Figura`, que define el metodo virtual `Dibujar`. Luego, cada figura especifica hereda de esa clase y sobrescribe el metodo para dibujarse de una forma distinta.

Gracias a esto, el formulario puede recorrer un arreglo de objetos `Figura` y llamar siempre al mismo metodo `Dibujar`, sin importar si el objeto real es un circulo, un cuadrado, un rectangulo o un triangulo.

---

## Tecnologias utilizadas

| Tecnologia | Uso |
| --- | --- |
| C# | Lenguaje principal del proyecto |
| Windows Forms | Interfaz grafica de escritorio |
| .NET Framework 4.0 | Framework objetivo del proyecto |
| System.Drawing | Dibujo de figuras en pantalla |
| System.Windows.Forms | Controles y eventos del formulario |

---

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
- Dibujo con `Graphics`.
- Uso de `Pen`, `Color` y `Point`.

---

## Estructura del proyecto

| Archivo | Descripcion |
| --- | --- |
| `Program.cs` | Punto de entrada de la aplicacion. Inicia Windows Forms y abre `Form1`. |
| `Form1.cs` | Contiene la logica principal del formulario, el arreglo de figuras y el evento del boton. |
| `Form1.Designer.cs` | Define visualmente los controles del formulario, como el boton y el `PictureBox`. |
| `Figura.cs` | Contiene la clase base `Figura` y las clases derivadas de figuras geometricas. |
| `Form1.resx` | Archivo de recursos asociado al formulario. |
| `ExMetodosVirtuales.csproj` | Archivo de configuracion del proyecto C#. |

---

## Clases principales

### `Figura`

Clase base del proyecto. Define el metodo virtual `Dibujar`, que sirve como comportamiento comun para todas las figuras.

```csharp
public virtual void Dibujar(Pen pen, Graphics graphics, int x, int y)
{
}
```

Por si sola no dibuja nada, pero permite que todas las figuras tengan una misma estructura.

### `Circulo`

Representa un circulo. Recibe un radio en el constructor y se dibuja con `DrawEllipse`.

```csharp
graphics.DrawEllipse(pen, x, y, radio, radio);
```

### `Rectangulo`

Representa un rectangulo. Recibe ancho y alto en el constructor. Para dibujarse arma un arreglo de cuatro puntos y utiliza `DrawPolygon`.

### `Cuadrado`

Representa un cuadrado. Hereda de `Rectangulo`, porque un cuadrado es un rectangulo con ancho y alto iguales.

Su constructor recibe un solo valor, el lado, y lo envia dos veces al constructor de `Rectangulo`.

### `TrianguloEquilatero`

Representa un triangulo equilatero. Recibe el lado en el constructor y calcula la altura con la formula:

```csharp
altura = (Math.Sqrt(3) / 2) * lado;
```

Luego dibuja el triangulo usando tres puntos.

### `TrianguloIsosceles`

Representa un triangulo isosceles. Recibe la base y la altura en el constructor. Con esos valores calcula los tres puntos necesarios para dibujarlo.

---

## Funcionamiento

1. Se inicia la aplicacion.
2. `Program.cs` ejecuta el formulario principal `Form1`.
3. El constructor de `Form1` llama a `InitializeComponent()`.
4. Se crea un arreglo con cinco figuras geometricas.
5. El usuario presiona el boton **Dibujar**.
6. El programa obtiene el area de dibujo del `PictureBox`.
7. Se genera un color aleatorio para cada figura.
8. Se recorre el arreglo con un ciclo `for`.
9. Cada figura ejecuta su propia version del metodo `Dibujar`.
10. Las figuras aparecen dibujadas dentro del `PictureBox`.

---

## Arreglo de figuras

En `Form1.cs` se declara un arreglo de tipo `Figura`:

```csharp
Figura[] figuras;
```

Luego se inicializa con distintos objetos:

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

Aunque todos se guardan dentro de un arreglo de tipo `Figura`, cada objeto conserva su comportamiento propio.

---

## Polimorfismo

El polimorfismo aparece cuando se recorre el arreglo y se llama al metodo `Dibujar`:

```csharp
figuras[i].Dibujar(pen, gr, i * 80, 50);
```

En esa linea, C# decide automaticamente que version del metodo ejecutar segun el tipo real del objeto:

| Objeto real | Metodo ejecutado |
| --- | --- |
| `Circulo` | `Circulo.Dibujar()` |
| `Cuadrado` | Metodo heredado desde `Rectangulo` |
| `TrianguloEquilatero` | `TrianguloEquilatero.Dibujar()` |
| `TrianguloIsosceles` | `TrianguloIsosceles.Dibujar()` |
| `Rectangulo` | `Rectangulo.Dibujar()` |

Esto permite trabajar con figuras diferentes usando una misma llamada.

---

## Interfaz grafica

La interfaz esta compuesta por dos elementos principales:

| Control | Funcion |
| --- | --- |
| Boton **Dibujar** | Ejecuta el evento que dibuja las figuras. |
| `PictureBox` | Funciona como superficie donde se muestran las figuras. |

El evento del boton esta conectado en `Form1.Designer.cs`:

```csharp
this.dibujarButton.Click += new System.EventHandler(this.button1_Click);
```

---

## Requisitos

Para compilar y ejecutar el proyecto se necesita:

- Visual Studio o un entorno compatible con Windows Forms.
- .NET Framework 4.0 Developer Pack.

El proyecto apunta a la version 4.0 de .NET Framework:

```xml
<TargetFrameworkVersion>v4.0</TargetFrameworkVersion>
```

---

## Como ejecutar

1. Abrir el proyecto en Visual Studio.
2. Verificar que este instalado **.NET Framework 4.0 Developer Pack**.
3. Compilar la solucion.
4. Ejecutar la aplicacion.
5. Presionar el boton **Dibujar**.

---

## Posible error de compilacion

Si aparece un error como este:

```text
No se encuentran los ensamblados de referencia para .NETFramework,Version=v4.0
```

significa que falta instalar el paquete de desarrollo de **.NET Framework 4.0** o que el proyecto debe ser redestinado a una version instalada del framework.

---

## Conclusion

Este proyecto demuestra de forma practica el uso de herencia, metodos virtuales y polimorfismo en C#.

Todas las figuras comparten una clase base, pero cada una implementa su propia forma de dibujarse. Gracias a eso, el formulario puede tratar a todos los objetos como `Figura` y dejar que cada clase resuelva internamente como debe dibujarse.
