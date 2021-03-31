# Trabajo Práctico N°3

## Ejercicio 01

~~~
 static void Main(string[] args)
{
    Console.CursorVisible = false;
    ConsoleKeyInfo k = Console.ReadKey(true);
    while (k.Key != ConsoleKey.End)
    {
        Console.Clear();
        Console.Write($"{k.Modifiers}-{k.Key}-{k.KeyChar}");
        k = Console.ReadKey(true);
    }
}
~~~

Este programa nos permite obtener información del evento de presión de una tecla por parte del usuario. Podemos ver que tecla fue presionada en solitario o de manera combinada.
Analicemos el código línea a línea: 
* Primero se desabilita el cursor que titila en la pantalla impidiendo ver lo que se ingresa para que no dificulte la visión del evento. 
* Luego defino una variable de tipo *ConsoleKeyInfo* donde se albergará la información de la/s tecla/s precionadas. 
* A continuación se ingresa a un Loop evaluando que la propiedad *Key* de la variable generada por el evento, no coincida con el valor arrojado por la tecla **end**.
    * Dentro del loop se limpia la consola.
    * Se imprimen: Los modificadores (Shift, Crtl, Alt, etc) si son presionados, la tecla presionada (su identificador) y el carácter que representa (solo si la tecla imprime carácteres como numeros, simbolos o letras).
    * Para permancer o salir del loop se espera otro evento.


## Ejercicio 02

~~~
static void Main(string[] args)
{
    double[,] mat = new double[4, 4];
    for (int i = 0; i <= 15; i++)
    {
        mat[i / 4, i % 4] = i;
    }
    ImprimirMatriz(mat);
}
static void ImprimirMatriz(double[,] matriz)
{
    for (int i = 0; i < matriz.GetLength(0); i++)
    {
        for (int j = 0; j < matriz.GetLength(1); j++)
        {
            Console.Write($"{matriz[i,j], 3}");
        }
        Console.WriteLine();
    }
}
~~~

Se agrego la interpolación para obtener una visión más limpia de la tabla.


## Ejercicio 03

~~~
static void Main(string[] args)
{
    double[,] mat = new double[4, 4];
    string format = "0.0";
    for (int i = 0; i <= 15; i++)
    {
        mat[i / 4, i % 4] = i;
    }
    ImprimirMatriz(mat, format);
}
static void ImprimirMatriz(double[,] matriz, string formatString)
{
    for (int i = 0; i < matriz.GetLength(0); i++)
    {
        for (int j = 0; j < matriz.GetLength(1); j++)
        {
            Console.Write($"{matriz[i, j].ToString(formatString),5}");
        }
        Console.WriteLine();
    }
}
~~~
Utilizo el metodo .ToString() al momento de imprimir para darle el formato deseado. Tener en cuenta que dentro de la interpolación podemos ejecutar código.
