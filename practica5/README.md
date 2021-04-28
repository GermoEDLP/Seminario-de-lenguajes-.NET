# Trabajo Práctico N°5

## Ejercicio 01

Tener en cuenta que se utilizaron Propiedades autoimplementadas en vez de campos privados y que algunos setters se utilizan para administrar otras Propiedades. 
~~~
class Cuenta
{
    public double Monto{get;set;}
    public static int Id{get;set;}
    public static int Denegada{get;set;}
    public static int Extracciones{get;set;}
    public static int Depositos{get;set;}
    private static double _extracciones_monto;
    private static double _depositos_monto;
    public static double Extracciones_monto
    {
        get{
            return _extracciones_monto;
            }
        set{
            _extracciones_monto=value;
            Extracciones++;
            }
    }
    public static double Depositos_monto
    {
        get{
            return _depositos_monto;
            }
        set{
            _depositos_monto=value;
            Depositos++;
            }
    }
    public int Id_cuenta{get;set;}
    public Cuenta()
    {
        Id++;
        Id_cuenta = Id;
        Console.WriteLine("Se creo la cuenta Id={0}", Id_cuenta);
    }
    public Cuenta Depositar(double monto)
    {
        Monto += monto;
        Depositos_monto+=monto;
        Console.WriteLine("Se depositó {0} en la cuenta {1} (Saldo={2})", monto, Id_cuenta, Monto);
        return this;
    }
    public Cuenta Extraer(double monto)
    {
        if (monto <= Monto)
        {
            Monto -= monto;
            Extracciones_monto+=monto;
            Console.WriteLine("Se extrajo {0} en la cuenta {1} (Saldo={2})", monto, Id_cuenta, Monto);
        }
        else{
            Console.WriteLine("Operación denegada - Saldo insuficiente");
            Denegada++;
        }
        return this;
    }
    public static void ImprimirDetalle(){
        Console.WriteLine("CUENTAS CREADAS: {0}", Id);
        Console.Write("DEPOSITOS: {0,6} ", Depositos);
        Console.WriteLine("- Total depositado: {0,5}", Depositos_monto);
        Console.Write("EXTRACCIONES: {0,3} ", Extracciones);
        Console.WriteLine("- Total extraido: {0,7}", Extracciones_monto);
        Console.WriteLine($"{"",17} - Saldo: {(Depositos_monto-Extracciones_monto),16}");
        Console.WriteLine(" * Se denegaron {0} extracciones por falta de fondos", Denegada);
    }
}
~~~

## Ejercicio 02

Primero creamos una Propiedad de lectura y escritura estatica que contenga una ArrayList:
~~~
public static ArrayList Lista{
                get;
                set;
            } = new ArrayList();
~~~

Luego implementamos la forma de que se llene ese ArrayList en el constructor, es decir, cuando se crea cada instancia:
~~~
public Cuenta()
{
    Id++;
    Id_cuenta = Id;
    Lista.Add(this);
    Console.WriteLine("Se creo la cuenta Id={0}", Id_cuenta);
}
~~~
Por ultimo definimos el método estático que nos retornará el ArrayList para trabajar. Tener en cuenta qu debemos retornar un ArrayList nuevo para romper la relación referencial del objeto `List` y así no afectar al mismo:
~~~
public static ArrayList GetCuentas(){
    ArrayList resp = new ArrayList();
    foreach ( Object obj in Lista )
        resp.Add(obj);
    return resp;
}
~~~

## Ejercicio 03

Creamos la Propiedad estatica de solo lectura:
~~~
public static ArrayList GetCuentas{
    get{
        ArrayList resp = new ArrayList();
        foreach ( Object obj in Lista )
            resp.Add(obj);
        return resp;
    }
}
~~~
Y cambiamos el llamado del método `GetCuentas()` en el Main por un llamado a una Propiedad:
~~~
ArrayList cuentas = Cuenta.GetCuentas;
~~~

## Ejercicio 04

* __a)__ La definición es correcta. 
* __b)__ La definición es incorrecta. Los constructores estaticos no deben ser públicos ya que no existe necesidad de llamarlos una vez que el programa ha sido compilado. Recordemos que las variables estáticas son variables de la clase y se crean al compilar el código y no al instanciar esa clase. Por lo que la idea de un constructor estático con acceso publico no tiene sentido. Los constructores estáticos son creados a fin de configurar el entorno al momento de la compilación.
* __c)__ La definición es incorrecta. Un constructor estático no debe poseer parametros, ya que es imposible pasarle información porque se ejecuta en tiempo de compilación y no de ejecución.
* __d)__ La definición es incompleta. El código no arroja ningún error, pero al momento de querer instanciar un objeto de la clase ***A***, nos encontramos con el problema de no poseer un constructor público. El constructor:
~~~
A(int a){
    s_a = a;
    this.a = a;
}
~~~
es un constructor privado ya que no se le asigna ningún *modificador de acceso*, por lo que el compilador le asiga por defecto el **private**. Como creamos ese constructor, la creación del constructor público por defecto no ocurre, dejandonos sin la posibilidad de instanciar objetos de esa clase.
* __e)__ La definición es incorrecta. No podemos interactuar con una variable de clase por medio de un método estático. El método estático se ejecuta en la compilación, y las variables de clase se crean en la instanciación, por lo que estamos haciendo en el método `static A(){a=30;}` es incorrecto. También tenemos el mismo problema que en el punto anterior, ya que no poseemos un constructor público. 
* __f)__ La definición es correcta. Sigo sin tener un constructor publico, pero tengo el método `GetInstancia()` que utiliza el método privado (lo puede hacer porque estan encapsulados juntos) para instanciar una clase y retornarla. De esta manera podemos crear un objeto y visualizarlo: 
~~~
A obj = A.GetInstancia();
Console.WriteLine(obj.a);
~~~
Tener en cuenta que para que este código sea correcto, debemos convertir la variable de clase `a` en pública.
* __g)__ La definición es correcta. Porque ambas asiganciones son en timpo de compilador, por lo que la información de ambas se da en la misma etapa (a lo sumo, el compilador realiza dos pasadas).
* __h)__ La definición es incorrecta. La definición de una constante (`const`) no puede contener una variable. No siquiera una variable estática que se asigna en tiempo de compilación.
* __i)__ La definición es correcta. La variable estática de solo lectura `_lista` es inicializada donde corresponde, en este caso, dentro del constructor estático.
* __j)__ La definición es incorrecta. Las variable de tipo `readonly` solo pueden ser inicializadas en su declaración o dentro de un constructor (en este caso es una variable de tipo estatica, por lo que debe ser dentro del constructor estático). Y, como se está definiendo dentro del método `P()`, entonces no es correcta.
* __k)__ La definición es correcta. Y nos permite acceder al array `vector` creado como variable de clase por medio de una sintaxis similar a si accedieriamos a un ArrayList:
~~~
A a = new A();
for (int i = 0; i < 3; i++)
{
    Console.WriteLine(a[i]);
}
// 1
// 2
// 3
~~~
* __l)__ La definición es incorrecta, ya que los indizadores son de instancia por lo que no pueden definirse inidizadores estáticos.

## Ejercicio 05
Empezemos suponiendo que los profesores se equivocaron y la primera línea del método `metodo2()` es la siguiente:
~~~
new A().c = 'a';
~~~
Ahora podemos analizar el resto:
* La linea `c = 'B';` causa un error, ya que se quiere acceder a una variable de instancia desde dentro de un método estatico, por lo que no se puede. Pensemos que se quiere modificar un objeto desde la clase misma, pero no se tiene ese objeto.
* La linea ` new A().st = "otro string";` tambien causa un error, ya que se quiere acceder a modificar una variable de la clase (variable `st` que es estática) desde una instancia de la clase, por lo que no se puede. No se puede directamente, pero si lo podríamos hacer desde dentro de la misma instancia.

## Ejercicio 06
Primero se definen las propiedades de solo lectura (solo defino el `get`) `DiagonalPrincipal` y `DiagonalSecundaria`:
~~~
public double[] DiagonalPrincipal
{
    get
    {
        double[] diag = new double[matriz.GetLength(0)];
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            diag[i] = matriz[i, i];
        }
        return diag;
    }
}

public double[] DiagonalSecundaria
{
    get
    {
        int dimension = matriz.GetLength(0);
        double[] diag = new double[dimension];
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            diag[i] = matriz[i, dimension - i - 1];
        }
        return diag;
    }
}
~~~
Despues defino los indizadores set y get para la clase:
~~~
public double this[int a, int b]
{
    set{
        matriz[a,b] = value;
    }
    get{
        return matriz[a,b];
    }
}
~~~
Y por ultimo cambio las lineas correspondientes del código para que funcione con los arreglos realizados:
~~~
// ESTAS LINEAS
for (int i = 0; i < 6; i++) A.SetElemento(i / 3, i % 3, (i + 1) / 3.0);
Console.WriteLine("\nAcceso al elemento B[1,2]={0}", B.GetElemento(1, 2));
try { foreach (double d in B.GetDiagonalPrincipal()) Console.Write("{0} ", d); } catch (Exception e) { Console.WriteLine(e.Message); }
try { foreach (double d in B.GetDiagonalSecundaria()) Console.Write("{0} ", d); } catch (Exception e) { Console.WriteLine(e.Message); }

// POR ESTAS LINEAS
for (int i = 0; i < 6; i++) A[i / 3, i % 3]=((i + 1) / 3.0);
Console.WriteLine("\nAcceso al elemento B[1,2]={0}", B[1, 2]);
try { foreach (double d in B.DiagonalPrincipal) Console.Write("{0} ", d); } catch (Exception e) { Console.WriteLine(e.Message); }
try { foreach (double d in B.DiagonalSecundaria) Console.Write("{0} ", d); } catch (Exception e) { Console.WriteLine(e.Message); }
~~~
Tener cuidado que las lineas cambiadas no son sucesivas sino que estan en otro orden con el código completo.

## Ejercicio 07
Primero definimos la clase junto con sus Propiedades y sus indezadores:
~~~
class Persona
{
    public string Nombre{get;set;}
    public char Sexo{get;set;}
    public int DNI{get;set;}
    public DateTime FechaNacimiento{get;set;}
    public int Edad
    {
        get{
            DateTime hoy = DateTime.Now;
            int edad = hoy.Year-FechaNacimiento.Year-1;
            if(hoy.Month>FechaNacimiento.Month){
                edad++;
            }else if(hoy.Month==FechaNacimiento.Month){
                if(hoy.Day>=FechaNacimiento.Day){
                    edad++;
                }
            }
            return edad;
        }
    }
    public object this[int i]
    {
        get
        {
            switch (i)
            {
                case 0:
                    return Nombre;
                case 1:
                    return Sexo;
                case 2:
                    return DNI;
                case 3:
                    return FechaNacimiento;
                case 4:
                    return Edad;
                default:
                    return null;
            }
        }
        set
        {
            switch (i)
            {
                case 0:
                    Nombre = (string)value;
                    break;
                case 1:
                    Sexo = (char)value;
                    break;
                case 2:
                    DNI = (int)value;
                    break;
                case 3:
                    FechaNacimiento = (DateTime)value;
                    break;
                default:
                    break;
            }
        }
    }
}
~~~
Despues definimos un método Main para probar que funcione correctamente:
~~~
 static void Main(string[] args)
{
    Persona p = new Persona();
    p[0] = "Juan Perez";
    p[1] = 'M';
    p[2] = 42123456;
    p[3] = new DateTime(2000,1,1);

    Console.WriteLine($"Nombre: {p[0]}");
    Console.WriteLine("Sexo: {0}", p[1].Equals('M')?"Masculino":"Femenino");
    Console.WriteLine($"DNI: {p[2]}");
    Console.WriteLine($"Fecha de nacimiento: {p[3]:dd/MM/yyyy}");
    Console.WriteLine($"Edad: {p[4]}");
}
~~~

## Ejercicio 08
La clase `ListaDePersonas` queda así:
~~~
class ListaDePersonas
{
    private Hashtable ht = new Hashtable();
    public void Agregar(Persona p)
    {
        ht[p.DNI] = p;
    }
    public Persona this[int dni]
    {
        get
        {
            return (Persona)ht[dni];
        }
    }
    public ArrayList this[char c]
    {
        get
        {
            ArrayList list = new ArrayList();
            foreach (DictionaryEntry p in ht)
            {
                if(((Persona)p.Value).Nombre[0]==c) list.Add(p.Value);
            }
            return list;
        }
    }
}
~~~
Y se plantearon algunos ejemplos para verificar su funcionamiento:
~~~
static void Main(string[] args)
{
    ListaDePersonas lista = new ListaDePersonas();
    Persona p1 = new Persona();
    p1[0] = "Juan Perez";
    p1[1] = 'M';
    p1[2] = 42123456;
    p1[3] = new DateTime(2000, 1, 1);
    lista.Agregar(p1);
    Persona p2 = new Persona();
    p2[0] = "Julian Gimenez";
    p2[1] = 'M';
    p2[2] = 41654987;
    p2[3] = new DateTime(2000, 1, 1);
    lista.Agregar(p2);
    Persona p3 = new Persona();
    p3[0] = "Virginia Flores";
    p3[1] = 'F';
    p3[2] = 38456123;
    p3[3] = new DateTime(2000, 1, 1);
    lista.Agregar(p3);
  
    // Mostramos el nombre de la persona con el DNI = 38456123
    Console.WriteLine("Persona con DNI = 38456123");
    Console.WriteLine(lista[38456123].Nombre);
    // Mostramos los nombres de las personas que empiezan con la letra J
    Console.WriteLine("\nPersonas con Nombre comenzado en 'J':");
    ArrayList listaPersonas = lista['J'];
    foreach (Persona persona in listaPersonas)
    {
        Console.WriteLine($"Nombre: {persona.Nombre}");
    }
}
~~~

## Ejercicio 09
El problema radica en la definición del método `set` de la Propiedad __Marca__. En ese caso, se esta igualando el valor de ingreso (*value*) con la misma propiedad en vez de con la variable provada de clase.
Se pueden plantear dos soluciones posibles:
* __a)__ Corregir la asignación por la variable correcta y colocarle un guion bajo al inicio del nombre para diferenciarla:
~~~
class Auto
{
    private string _marca;
    public string Marca
    {
        set
        {
            _marca = value;
        }
        get
        {
            return _marca;
        }
    }
}
~~~
* __b)__ Eliminar la linea que define la variable de instancia privada y utilizar la auto-implementación de la Propiedad:
~~~
class Auto
{
    public string Marca
    {
        set;
        get;
    }
}
~~~

## Ejercicio 10
Se puede chequear este punto y el siguiente mediante esta herramienta: [TryRosLyn](https://sharplab.io/#K4Zwlgdg5gBAygTxAFwKYFsDcAoADsAIwBswBjGUogQxBBgGEYBvbGNmfYsmANwHswAExgBZABQBKZq3YBfbLKAA)

* `private static int a;` : Variable de clase (estatica) que contiene un entero.
* `private static readonly int b;` : Variable de clase (estática) de solo lectura (solo puede definirse en su implementación o en un constructor, en este caso en un constructor estático)
* `A() { }` : Constructor privado.
* `public A(int i) : this() { }` : Constructor publico, que recibe un entero al instanciar la clase, e implementa el constructor privado antes descripto (implementa un constructor sin parametros). 
* `static A() => b = 2;` : Constructor estático, se ejecuta en tiempo de compilación.
* `int c;` : Variable privada entera.
* `public static void A1() => a = 1;` : Método publico estático que no retorna nada, solo coloca un valor.
* `public int A1(int a) => A.a + a;` : Método publico de clase que retorna un entero.
* `public static int A2;` : Variable de clase (estática) pública que aloja un entero;
* `static int A3 => 3;` : Propiedad auto-implementada de lectura que siempre retorna 3.;
* `private int A4() => 4;` : Método privado que retorna un entero. En este caso, retorna siempre 4.
* `public int A5 { get => 5; }` : Propiedad de solo lectura auto-implementada que aloja un entero. Retorna simepre un 5. Es analogo al `static int A3 => 3;` evaluado mas arriba.
* `int A6 { set => c = value; }` : Propiedad privada de solo escritura que aloja un entero. Implementa la variable privada de clase **c**.
* `public int A7 { get; set; }` : Propiedad publica auto-implementada de lectura y escritura que aloja un entero.
* `public int A8 { get; } = 8;` : Propiedad pública de lectura auto-implementada que aloja un entero. Inicializada en 8.
* `public int this[int i] => i;` : Indizador que retorna el valor entero pasado por parametro.

## Ejercicio 11

* __a)__ Es la creación de una variable de clase pública que aloja un entero y es inicializada con el valor 3.
* __b)__ Es una Propiedad de solo lectura publica que retorna simepre un 3. El código analogo es el siguiente:
~~~
public int X
{
    get
    {
        return 3;
    }
}
~~~
