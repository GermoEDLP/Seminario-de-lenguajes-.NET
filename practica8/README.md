# Trabajo Práctico N°8

## Ejercicio 01

Se definen los delegados:
~~~
delegate void Del1(int x);
delegate void Del2(int[] x);
delegate int Del3(int x);
delegate bool Del4(string st);
~~~

## Ejercicio 02

Defino el tipo delegate y la variable a1 como una función lambda:
~~~
AccionInt a1 = (ref int i) => i = i * 2;
~~~

Luego esta función se suma a sí misma unas tres veces, por lo que:
* La primera vez resulta en dos funciónes encadenadas
* La segunda vez en 4 funciones encadenadas
* La tercera vez en 8 funciones encadenadas.

Al final, la variable i se setea en 1 y se pasa como argumento de las funciones encadenadas. EL valor de i se acumula por que es pasada como variable de referencia.
El resultado es 256.

## Ejercicio 03

La función recibe la referencia de la variable ya que al cambiar su contenido, la función imprime lo que esta alojado en la varibale y no una copia.

## Ejercicio 04

La impresión del código son valores 10 repetidos unas 10 veces. Esto ocurre porque si bien guardo una función de impresión de consola en cada lugar de la lista, la variable que usa para imprimir es i y la misma es definida y aumentada hasta el valor 10 en el ciclo for, por lo que cuando se ejecutan las funciones delegadas, el valor de i es 10 para todas.

## Ejercicio 05

En base a las funciones usadas en el método main, definimos los métodos de la clase ListaDeEnteros:
~~~
 class ListaDeEnteros : IEnumerable
{
    ArrayList lista = new ArrayList();
    public void Agregar(int i) => lista.Add(i);
    public int Cantidad => lista.Count;
    public IEnumerator GetEnumerator()
    {
        return lista.GetEnumerator();
    }
    public ListaDeEnteros Seleccionar(FuncSelect f)
    {
        IEnumerator l = lista.GetEnumerator();
        ListaDeEnteros lista_nueva = new ListaDeEnteros();
        while (l.MoveNext())
        {
            if (f.Invoke((int)(l.Current)))
            {
                lista_nueva.Agregar((int)l.Current);
            }
        }
        return lista_nueva;
    }
    public ListaDeEnteros Aplicar(FuncAplicar f)
    {
        IEnumerator l = lista.GetEnumerator();
        ListaDeEnteros lista_nueva = new ListaDeEnteros();
        while (l.MoveNext())
        {
            lista_nueva.Agregar(f.Invoke((int)l.Current));
        }
        return lista_nueva;
    }
    public static ListaDeEnteros Combinar(ListaDeEnteros l1, ListaDeEnteros l2, FuncCombinar f)
    {
        IEnumerator l1e = l1.GetEnumerator();
        IEnumerator l2e = l2.GetEnumerator();
        ListaDeEnteros ll;
        ListaDeEnteros lc;
        string listaLarga;
        if (l1.Cantidad > l2.Cantidad)
        {
            listaLarga = "l1";
            ll = l1;
            lc = l2;
        }
        else
        {
            listaLarga = "l2";
            ll = l2;
            lc = l1;
        }
        ListaDeEnteros lista_nueva = new ListaDeEnteros();
        for (int i = 0; i < lc.Cantidad; i++)
        {
            l1e.MoveNext();
            l2e.MoveNext();
            lista_nueva.Agregar(f.Invoke((int)l1e.Current, (int)l2e.Current));
        }
        for (int i = 0; i < ll.Cantidad - lc.Cantidad; i++)
        {
            if (listaLarga == "l1")
            {
                l1e.MoveNext();
                lista_nueva.Agregar((int)l1e.Current);
            }
            else
            {
                l2e.MoveNext();
                lista_nueva.Agregar((int)l2e.Current);
            }
        }
        return lista_nueva;
    }
    public void Imprimir()
    {
        IEnumerator l = lista.GetEnumerator();
        while (l.MoveNext())
        {
            Console.Write(l.Current + ", ");
        }
        Console.WriteLine("");
    }
}
~~~

Para esto, debemos definir los delegados correspondientes (en base a lo que retornaría la función y sus parametros de entrada)
~~~
delegate bool FuncSelect(int i);
delegate int FuncAplicar(int i);
delegate int FuncCombinar(int i, int j);
~~~

## Ejercicio 06

* __b)__ La salida por consola es la siguiente:
~~~
Se inició el trabajo
Trabajo concluido
~~~
* __c1)__ La situación arroja un error en tiempo de ejecución de tipo NullReferenceException ya que no definimos el manejador de eventos y, cuando el evento ocurre, el código no sabe como proceder.
* __c2)__ Para evitar esta excepció podemos condicionar la ejecución del manejador, si este es null, es decir, si este no está definido:
~~~
public void Trabajar()
{
    if (Trabajando != null)
    {
        Trabajando(this, EventArgs.Empty);
        //realiza algún trabajo
        Console.WriteLine("Trabajo concluido");
    }
}
~~~
* __d)__ El método Main quedá así:
~~~
static void Main(string[] args)
{
    Trabajador t1 = new Trabajador();
    t1.Trabajando = (object sender, EventArgs e) => Console.WriteLine("Se inició el trabajo");
    t1.Trabajar();
}
~~~
* __e)__ La clase Trabajador quedá así:
~~~
 class Trabajador
{
    public event EventHandler Trabajando;
    public void Trabajar()
    {
        if (Trabajando != null)
        {
            Trabajando(this, EventArgs.Empty);
            //realiza algún trabajo
            Console.WriteLine("Trabajo concluido");
        }
    }
}
~~~
En el método Main, al asignar el evento, debemos usar +=.
* __f)__ La clase Trabajador quedá así:
~~~
class Trabajador
{
    public EventHandler Trabajando = (object sender, EventArgs e) => Console.WriteLine("Se inició el trabajo");
    public void Trabajar()
    {
        if (Trabajando != null)
        {
            Trabajando(this, EventArgs.Empty);
            //realiza algún trabajo
            Console.WriteLine("Trabajo concluido");
        }
    }
}
~~~