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

## Ejercicio 06

La siguiente clase permite definir e imprirmir lo que se pide en el ejercicio:
~~~
class Ecuacion2
{
    private double a;
    private double b;
    private double c;
    public Ecuacion2(double a, double b, double c)
    {
        this.a = a;
        this.b = b;
        this.c = c;
    }
    public double GetDiscriminante()
    {
        return ((Math.Pow(this.b, 2)) - (4 * this.a * this.c));
    }
    public int GetCantidadDeRaices()
    {
        return GetDiscriminante() > 0 ? 2 : GetDiscriminante() == 0 ? 1 : 0;
    }
    public void ImprimirRaices()
    {
        if (GetCantidadDeRaices() == 2)
        {
            double r1 = (-this.b + Math.Sqrt(GetDiscriminante())) / (2 * this.a);
            double r2 = (-this.b - Math.Sqrt(GetDiscriminante())) / (2 * this.a);
            Console.WriteLine("Raices: {0} y {1}", r1, r2);
        }
        else if (GetCantidadDeRaices() == 1)
        {
            double r = (-this.b) / (2 * this.a);
            Console.WriteLine("Raiz: {0}", r);
        }
        else
        {
            Console.WriteLine("La función no tiene raices");
        }
    }
}
~~~

Aquí se definen un ejemplo para cada caso:
~~~
static void Main(string[] args)
{
    Ecuacion2[] e = { new Ecuacion2(1, -2, -3), new Ecuacion2(1, -12, 36), new Ecuacion2(1, -6, 25) };
    for (int i = 0; i < e.Length; i++)
    {
        Console.WriteLine();
        Console.WriteLine("Discrimiante: {0}", e[i].GetDiscriminante());
        Console.WriteLine("Cant. de raices: {0}", e[i].GetCantidadDeRaices());
        e[i].ImprimirRaices();
    }
}
~~~

## Ejercicio 07

Se definio la clase Nodo, dentro de la cual se utilizó una clase `Elemento` para poder trabajar de una forma más ordenada, las propiedades tam (cantidad de elementos del arbol) y altura (cantidad de niveles del arbol), se definieron para mantener datos internos y las mismas se actualizan al realizar nuevas inserciones.
~~~
class Nodo
{
    // Los valores mayores al nodo se guardan a la derecha, los menores, a la izquierda
    Elemento raiz = null;
    int tam = 0;
    int altura = 0;
    public Nodo(int d)
    {
        Insertar(d);
    }
    public void Insertar(int d)
    {
        int nivel = 0;
        Elemento n = new Elemento(d);
        if (raiz == null)
        {
            raiz = n;
            tam++;
            altura = 0;
        }
        else
        {
            Elemento anterior = null, actual;
            actual = raiz;
            while (actual != null)
            {
                anterior = actual;
                if (d < actual.Dato)
                {
                    actual = actual.Izq;
                    nivel++;
                }
                else if (d > actual.Dato)
                {
                    actual = actual.Der;
                    nivel++;
                }
                else
                {
                    Console.WriteLine("{0} es un dato reetido", d);
                    return;
                }
            }
            if (d < anterior.Dato)
            {
                anterior.Izq = n;
                tam++;
            }
            else
            {
                anterior.Der = n;
                tam++;
            }
        }
        if (nivel > altura)
            altura = nivel;
    }
    public void GetInOrder(Elemento n, ref int[] array, ref int i)
    {
        if (n != null)
        {
            GetInOrder(n.Izq, ref array, ref i);
            array[i] = n.Dato;
            i++;
            GetInOrder(n.Der, ref array, ref i);
        }
    }
    public int[] GetInOrder()
    {
        int i = 0;
        int[] array = new int[tam];
        GetInOrder(raiz, ref array, ref i);
        return array;
    }
    public int GetValorMinimo()
    {
        if (raiz == null)
            return 0;
        Elemento trabajo = raiz;
        int minimo = trabajo.Dato;
        while (trabajo.Izq != null)
        {
            trabajo = trabajo.Izq;
            minimo = trabajo.Dato;
        }
        return minimo;
    }
    public int GetValorMaximo()
    {
        if (raiz == null)
            return 0;
        Elemento trabajo = raiz;
        int maximo = trabajo.Dato;
        while (trabajo.Der != null)
        {
            trabajo = trabajo.Der;
            maximo = trabajo.Dato;
        }
        return maximo;
    }
    public int GetAltura()
    {
        return altura;
    }
    public int GetCantNodos()
    {
        return tam;
    }
}
class Elemento
{
    private int dato;
    private Elemento izq;
    private Elemento der;
    public Elemento(int d)
    {
        dato = d;
        izq = der = null;
    }
    // Defino getters y setters
    public int Dato { get => dato; set => dato = value; }
    internal Elemento Izq { get => izq; set => izq = value; }
    internal Elemento Der { get => der; set => der = value; }
}
~~~

 
## Ejercicio 08

Se agregarón algunos `try` y `catch` para manejar los errores que puedan producirse por el dimensionamientos de las matrices:
~~~
static void Main(string[] args)
{
    Matriz A = new Matriz(2, 3);
    for (int i = 0; i < 6; i++) A.SetElemento(i / 3, i % 3, (i + 1) / 3.0);
    Console.WriteLine("Impresión de la matriz A");
    A.Imprimir("0.000");
    double[,] aux = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 1, 2, 3 } };
    Matriz B = new Matriz(aux);
    Console.WriteLine("\nImpresión de la matriz B");
    B.Imprimir();
    Console.WriteLine("\nAcceso al elemento B[1,2]={0}", B.GetElemento(1, 2));
    Console.Write("\nfila 1 de A: ");
    foreach (double d in A.GetFila(1)) Console.Write("{0:0.0} ", d);
    Console.Write("\n\nColumna 0 de B: ");
    foreach (double d in B.GetColumna(0)) Console.Write("{0} ", d);
    Console.Write("\n\nDiagonal principal de B: ");
    try { foreach (double d in B.GetDiagonalPrincipal()) Console.Write("{0} ", d); catch (Exception e) { Console.WriteLine(e.Message); }
    Console.Write("\n\nDiagonal secundaria de B: ");
    try { foreach (double d in B.GetDiagonalSecundaria()) Console.Write("{0} ", d); catch (Exception e) { Console.WriteLine(e.Message); }
    Console.WriteLine();
    try
    {
        A.MultiplicarPor(B);
        Console.WriteLine("\n\nA multiplicado por B");
        A.Imprimir();
    }
    catch (Exception e) { Console.WriteLine(e.Message); }
}
~~~

Despues se creo la clase que se pedia en el enunciado junto con los métodos:
~~~
class Matriz
{
    private double[,] matriz;
    public Matriz(int fila, int col)
    {
        matriz = new double[fila, col];
    }
    public Matriz(double[,] matriz)
    {
        this.matriz = matriz;
    }
    public void SetElemento(int fila, int columna, double elemento)
    {
        matriz[fila, columna] = elemento;
    }
    public double GetElemento(int fila, int columna)
    {
        return matriz[fila, columna];
    }
    public void Imprimir()
    {
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                Console.Write("{0,-7}", matriz[i, j]);
            }
            Console.WriteLine();
        }
    }
    public void Imprimir(string formatString)
    {
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                Console.Write("{0,-7}", matriz[i, j].ToString(formatString));
            }
            Console.WriteLine();
        }
    }
    public double[] GetFila(int fila)
    {
        double[] f = new double[matriz.GetLength(1)];
        for (int i = 0; i < matriz.GetLength(1); i++)
        {
            f[i] = GetElemento(fila, i);
        }
        return f;
    }
    public double[] GetColumna(int columna)
    {
        double[] c = new double[matriz.GetLength(0)];
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            c[i] = GetElemento(i, columna);
        }
        return c;
    }
    public double[] GetDiagonalPrincipal()
    {
        checkSquare(matriz);
        double[] diag = new double[matriz.GetLength(0)];
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            diag[i] = matriz[i, i];
        }
        return diag;
    }
    public double[] GetDiagonalSecundaria()
    {
        checkSquare(matriz);
        int dimension = matriz.GetLength(0);
        double[] diag = new double[dimension];
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            diag[i] = matriz[i, dimension - i - 1];
        }
        return diag;
    }
    public double[][] GetArregloDeArreglo()
    {
        double[][] newMat = new double[matriz.GetLength(1)][];
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            newMat[i] = new double[matriz.GetLength(0)];
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                newMat[i][j] = matriz[i, j];
            }
        }
        return newMat;
    }
    public void Sumarle(Matriz m)
    {
        try
        {
            calcular(m, true);
        }
        catch
        {
            throw;
        }
    }
    public void Restarle(Matriz m)
    {
        try
        {
            calcular(m, false);
        }
        catch
        {
            throw;
        }
    }
    private double[,] calcular(Matriz m, bool suma)
    {
        if (checkearTamaños(m.matriz))
        {
            double[,] operacion = new double[matriz.GetLength(0), matriz.GetLength(1)];
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    operacion[i, j] = suma ? matriz[i, j] + m.matriz[i, j] : matriz[i, j] - m.matriz[i, j];
                }
            }
            return operacion;
        }
        throw new Exception("Las matrices deben tener las mismas");
    }
    public void MultiplicarPor(Matriz m)
    {
        try
        {
            checkearTamañosMultiplicacion(m);
            double[,] matrizMult = new double[matriz.GetLength(0), m.matriz.GetLength(1)];
            int c1 = matriz.GetLength(1), f1 = matriz.GetLength(0);
            int c2 = m.matriz.GetLength(1), f2 = matriz.GetLength(0);
            for (int i = 0; i < f1; i++)
            {
                for (int j = 0; j < c2; j++)
                {
                    matrizMult[i, j] = 0;
                    for (int z = 0; z < c1; z++)
                    {
                        matrizMult[i, j] = matriz[i, z] * m.matriz[z, j] + matrizMult[i, j];
                    }
                }
            }
            matriz = matrizMult;
        }
        catch
        {
            throw;
        }
    }
    static void checkSquare(double[,] matriz)
    {
        if (matriz.GetLength(0) != matriz.GetLength(1))
        {
            throw new ArgumentException("La matriz no es cuadrada");
        }
        return;
    }
    private bool checkearTamaños(double[,] m)
    {
        return (matriz.GetLength(0) != m.GetLength(0) || matriz.GetLength(1) != m.GetLength(1)) ? false : true;
    }
    private void checkearTamañosMultiplicacion(Matriz m)
    {
        if (matriz.GetLength(1) != m.matriz.GetLength(0))
        {
            throw new Exception("Las filas de B deben ser iguales a las columnas A.");
        }
    }
}    
~~~

## Ejercicio 09

* __a)__ En este caso, nos encontramos con una excepción en tiempo de ejecución de tipo *NullReferenceException* que responde a no haber inicializado la variable `a`, solo se le indica al compilador el tipado de la misma anteponiendo el nombre de la clase (`Auto`). El error es en tiempo de ejecución porque el compilador no tiene forma de saber si la variable fue inicializada en otro método, o en otra clase, por lo que llega a ejecutar el código y se encuentra con que la variable no posee una referencia guardada, es decir, alberga el valor `null`, lo que desata la *NullReferenceException*. Para eliminar ese problema, solo debemos inicializar la variable por medio del `new` utilizando el constructor por defecto. Si se realiza de esa manera, la propiedad `a.Velocidad` quedará definida en 0 al instanciar el objeto.
~~~
static Auto a = new Auto();
~~~

* __b)__ En el segundo caso, nos encontramos con un error en tiempo de compilación por la misma cuestión, es decir, que la variable `a` no esta inicializada. En este caso, el error se dispara en tiempo de compilación y no de ejecución porque la definición de la variable `a` (`Auto a;`) se haya en el mismo *scope* que la utilkzación de la misma, por lo que el compilador puede saber que la variable `a` no esta inicializada. La solución es la misma que en el ejercicio anterior:
~~~
Auto a = new Auto();
~~~

## Ejercicio 10

En este caso particular, la sobrecarga del método `Metodo()` es correctamente aplicada en los dos primeros ejemplos ya que no poseen los mismos parametros, pero la tercera definición del método es incorrecta por que no se diferencia en los paramtros con la segunda. Al realizar una sobrecarga de métodos, debemos asegurarnos que los parametros sean diferentes en tipo o posición, y no basta con que el retorno de los métodos sea diferente.


## Ejercicio 11

Para analizar este ejercicio, debemos recordar, que la resolución de la sobrecarga (es decir, que método se ejecuta de los que hayamos definido con el mismo nombre dependiendo de los parametros que le pasemos) se realiza en tiempo de compilación, es decir, que al compilar el programa, se identifica que tipado poseen los parametros y se decide que método a ejecutar, luego solo se ejecuta el código completo. 
Tambien debemos recordar que existe un caso particular que no obedece a lo descripto anteriormente y es cuando el argumento que se envía a procesar es de tipo *dynamic*. En este caso, la resolución de la sobrecarga se produce en tiempo de ejecución, brindandole al método, no un tipo *dynamic*, sino lo que el compilador considere que el dato representa. En este caso, al castear el objeto `o` como *dynamic*, sabiendo que contiene un objeto con un entero, al método `Procesar()` le llega un entero. 

* __a)__ Aqui, el compilador entiende que el primer parametro no es un entero, entonces ejecuta el segundo método que puede recibir parametros de cualquier tipo.
~~~
Procesar(o, o); // dynamic d1: 5 dynamic d2: 5
~~~
* __b)__ Aqui, el casteo como *dynamic* del primer parametro lo convierte (en ejecución) en un entero, entonces se ejecuta el primer método.
~~~
Procesar((dynamic)o, o); //entero: 5 objeto:5 
~~~
* __c)__ Aqui nuevamente, el casteo como *dynamic* del primer parametro lo convierte (en ejecución) en un entero y aunque el segundo parametro tambien es pasado como un entero, el método `Procesar()` lo recibe como un objeto, ya que esta esperando un *object* como segundo parametro.
~~~
Procesar((dynamic)o, (dynamic)o); //entero: 5 objeto:5 
~~~
* __d)__ En este caso, el segundo parametro es pasado como entero, pero el método espera un objeto, por lo que lo convierte en tipo *object*. EL primer parametro es pasado sin castear, por lo que se recibe como tipo *object*, definiendo al compilador por ejecutar el segundo método.
~~~
Procesar(o, (dynamic)o); // dynamic d1: 5 dynamic d2: 5
~~~
* __e)__ Por último, este caso es el más simple. Al pasar como parametro dos enteros literales, el primero es tomado como *int* y el segundo como *object* por el primer método.
~~~
Procesar(5, 5); //entero: 5 objeto:5
~~~

## Ejercicio 12
El siguiente código genera la respuesta que solicita el enunciado:
~~~
class Cuenta
{
    private string _nombre;
    private int? _dni;
    private double _monto;
    public Cuenta()
    {
        _nombre = null;
        _dni = null;
    }
    public Cuenta(string nombre) : this()
    {
        _nombre = nombre;
    }
    public Cuenta(int dni) : this()
    {
        _dni = dni;
    }
    public Cuenta(string nombre, int dni)
    {
        _nombre = nombre;
        _dni = dni;
    }
    public void Imprimir()
    {
        string texto = "No especificado";
        string dni = (_dni ?? 0).ToString();
        Console.WriteLine("Nombre: {0}, DNI: {1}, Monto: {2}", _nombre?? texto, dni!="0"?_dni:texto, _monto);
    }
    public void Depositar(double monto)
    {
        _monto += monto;
    }
    public void Extraer(double monto)
    {
        if (_monto > monto)
        {
            _monto -= monto;
        }
        else
        {
            Console.WriteLine("Operación cancelada, monto insuficiente");
        }
    }
}
~~~

## Ejercicio 13

Las siguientes lineas de código reemplazan al código dado en el ejercicio:
~~~
static void Main(string[] args)
{
    st = st1 ?? (st = st2 ?? st3);
    st4 = null ?? "Valor por defecto";
}
~~~