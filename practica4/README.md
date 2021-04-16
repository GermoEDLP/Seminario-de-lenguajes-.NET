# Trabajo Práctico N°4

## Ejercicio 01

Se leyó el archivo ubicado en `data/dataEj1.txt` para mostrar la información:
~~~
static void Main(string[] args)
{
    StreamReader sr = new System.IO.StreamReader("data/dataEj1.txt");
    Persona p = new Persona();
    string line;
    int cont = 1;
    Console.WriteLine("{0}) {1,-8} {2,5} {3,10}", "Nro", "Nombre", "Edad", "DNI");
    while ((line = sr.ReadLine()) != null)
    {
        string[] terminos = line.Split(",");
        p.Nombre = terminos[0];
        p.Edad = Int32.Parse(terminos[1]);
        p.DNI = terminos[2];
        Console.WriteLine("{0}) {1,-8} {2,5} {3,15}", cont, p.Nombre, p.Edad, p.DNI);
        cont++;
    }
}
class Persona
{
    public string Nombre;
    public int Edad;
    public string DNI;
}
~~~

## Ejercicio 02

Primero se realizó el ejercicio pidiendole al usuario que ingrese las personas por consola, las mismas son generadas y almacanadas en un arreglo y cuando se finaliza el ingreso, se muestran en pantalla.

~~~
static void Main(string[] args)
{
    Persona[] personas = new Persona[100];
    Console.WriteLine("Ingrese una persona con el formato 'Nombre,Documento,Edad<ENTER>' (fin finaliza");
    string line = Console.ReadLine();
    int cont = 0;
    while (line != "fin")
    {
        string[] terminos = line.Split(",");
        personas[cont] = new Persona(terminos[0], Int32.Parse(terminos[1]), terminos[2]);
        cont++;
        Console.WriteLine("Ingrese una persona con el formato 'Nombre,Documento,Edad<ENTER>' (fin finaliza)");
        line = Console.ReadLine();
    }
    Console.WriteLine("{Nro}) {Nombre,-8} {Edad,5} {DNI,10}");
    for (int i = 0; i < personas.Length; i++)
    {
        if (personas[i] != null)
            personas[i].imprimir(i + 1);
    }
}
class Persona
{
    public string Nombre;
    public int Edad;
    public string DNI;
    public Persona(string Nombre, int Edad, string DNI)
    {
        this.Nombre = Nombre;
        this.Edad = Edad;
        this.DNI = DNI;
    }
    public Persona()
    {
    }
    public void imprimir(int pos)
    {
        Console.WriteLine("{0}) {1,-8} {2,5} {3,10}", pos, Nombre, Edad, DNI);
    }
}
~~~

Luego se reprodujo el mismo ejercicio pero utilizando valores aportados por un archivo de texto ubicado en `data/dataEj1.txt`

~~~
static void Main(string[] args)
{
    StreamReader sr = new System.IO.StreamReader("data/dataEj1.txt");
    string line;
    int cont = 1;
    Console.WriteLine("{Nro}) {Nombre,-8} {Edad,5} {DNI,10}");
    while ((line = sr.ReadLine()) != null)
    {
        string[] terminos = line.Split(",");
        Persona p = new Persona(terminos[0], Int32.Parse(terminos[1]), terminos[2]);
        p.imprimir(cont);
        cont++;
    }
}
class Persona
{
    public string Nombre;
    public int Edad;
    public string DNI;
    public Persona(string Nombre, int Edad, string DNI){
        this.Nombre = Nombre;
        this.Edad = Edad;
        this.DNI = DNI;
    }
    public void imprimir(int pos)
    {
        Console.WriteLine("{0}) {1,-8} {2,5} {3,10}", pos, Nombre, Edad, DNI);
    }
}
~~~

## Ejercicio 03

~~~
static void Main(string[] args)
{
    StreamReader sr = new System.IO.StreamReader("data/dataEj1.txt");
    string line;
    int cont = 1;
    // Definir una persona con una edad muy alta para poder comparar
    Persona joven = new Persona("", 999, "");
    while ((line = sr.ReadLine()) != null)
    {
        string[] terminos = line.Split(",");
        Persona p = new Persona(terminos[0], Int32.Parse(terminos[1]), terminos[2]);
        // Comparo que la persona que esta en joven, sea mayor que la que se ingreso.
        if(joven.EsMayorQue(p)) joven = p;
        cont++;
    }
    Console.WriteLine("La persona mas joven de la lista es: ");
    joven.imprimir();
}
class Persona
{
    private string Nombre;
    private int Edad;
    private string DNI;
    public Persona(string Nombre, int Edad, string DNI){
        this.Nombre = Nombre;
        this.Edad = Edad;
        this.DNI = DNI;
    }
    public void imprimir()
    {
        Console.WriteLine("{0,-8} {1,5} {2,10}", Nombre, Edad, DNI);
    }
    public bool EsMayorQue(Persona p){
        return this.Edad>p.Edad;
    }
}
~~~

## Ejercicio 04

La definición de la siguiente clase permite definir e imprirmir lo que se pide en el ejercicio:
~~~
class Hora
{
    private int horas;
    private int minutos;
    private int segundos;
    public Hora(int horas, int minutos, int segundos)
    {
        this.horas = horas;
        this.minutos = minutos;
        this.segundos = segundos;
    }
    public void imprimir(){
        Console.WriteLine("{0} horas, {1} minutos y {2} segundos", horas, minutos, segundos);
    }
}
~~~

## Ejercicio 05

La definición de la siguiente clase permite definir e imprirmir lo que se pide en el ejercicio:
~~~
class Hora
{
    private int horas;
    private int minutos;
    private int segundos;
    private double segundosD;

    public Hora(int horas, int minutos, int segundos)
    {
        this.horas = horas;
        this.minutos = minutos;
        this.segundos = segundos;
    }

    public Hora(double hora)
    {
        // Al castear obtengo la parte entera del double
        this.horas = (int)hora;
        // Si le resto la parte entera al double, tengo los decimales, luego estos 
        // multiplicados por 60 me dan los minutos que representan.
        // Otra vez casteando, obtengo la parte entera
        this.minutos = (int)((hora - this.horas) * 60);
        // Mismo procedimiento que con los minutos. Creo una nueva variable tipo double
        // Para poder guardar el numero resultante con decimales incluidos
        this.segundosD = ((((hora - this.horas) * 60) - this.minutos) * 60);

        // Cuando los segundos deberían llegar a 60, ocurre que el numero es en verdad
        // 59,9999999999999277, entonces aparece como que hay 60 segundos pero no suma 
        // un nuevo minuto, entonces este condicional corrige ese pequeño problema que deriva
        // de la precisión de la representación de los valores.
        if (Math.Round(this.segundosD) == 60)
        {
            this.minutos++;
            this.segundosD = 0;
        }
    }
    public void imprimir()
    {
        if (segundos != 0)
        {
            Console.WriteLine("{0} horas, {1} minutos y {2} segundos", horas, minutos, segundos);
        }
        else
        {
            Console.WriteLine("{0} horas, {1} minutos y {2:0.000} segundos", horas, minutos, segundosD);
        }
    }
}
~~~
