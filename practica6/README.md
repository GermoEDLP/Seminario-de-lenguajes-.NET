# Trabajo Práctico N°6

## Ejercicio 01
Analicemos el funcionamiento de la clase base `A`:
* Tiene una variable protegida (*protected*) `_id` a la que prodremos acceder en todas sus derivaciones por ser heredada junto con su control.
* Tenemos un constructor que recibe un parametro de entrada `id` y lo aloja en la variable protegida.
* Tenemos un método `Imprimir()`, que, al colocarle la palabra *virtual* se nos permite sobreescribirlo en clases derivadas de esta, y que imprime el valor del id registrado.

A partir del analisis antes realizado, se ve que podemos aprovechar todas estas caracteristicas para no realizar código adicional en las clases heredadas.

Propongo completar la clase B de la siguinente manera:
~~~
class B : A
{
    public B(int id) : base(id){}
    public override void Imprimir()
    {
        Console.Write($"B_{_id} --> ");
        base.Imprimir();
    }
}
~~~
De esta manera, hacemos uso, no solo del constructor de la clase base al externder el constructor de esa manera, sino tambien usamos la sobre escritura (`override`) del método `Imprimir()` y utilizamos este mismo método, pero del padre (colocando la palabra *base* delante), para imprimir la ultima parte.
Entonces la metodología es:
* Utiliza la extensión del método constructor del padre, pasandole el parametro.
* Sobreescribe el método de `Imprimir()` para poder heredarlo.
* Utiliza el método `Imprimir()` del padre para imprimir todo lo que tengo por encima.

Podemos replicar esta misma metodología pero con las otras clases:
~~~
class C : B
{
    public C(int id) : base(id){}
    public override void Imprimir()
    {
        Console.Write($"C_{_id} --> ");
        base.Imprimir();
    }
}
class D : C
{
    public D(int id): base(id){}
    public override void Imprimir()
    {
        Console.Write($"D_{_id} --> ");
        base.Imprimir();
    }
}
~~~
De esta manera realizamos lo pedido por el ejercicio sin modificar lo que se dió y manteniendo al minimo la escritura de código.

## Ejercicio 02

* __a)__ Imprimir los objetos cuyo tipo exacto sea B usando el operador `is`:
~~~
static void Main(string[] args)
{
    A[] vector = new A[] { new C(1), new D(2), new B(3), new D(4), new B(5) };
    foreach (A a in vector)
    {
        if(a is B && a is not C && a is not D){
            a.Imprimir();
        }
    }
}
~~~
EN este caso, debo preguntar, tanto si el tipo es **B**, como si no es **C** y no es **D**, ya que los tipos heredados conservan el tipado de herencia, haciendo que **C** y que **D**, tambien sean tipo **B**.
* __b)__ Imprimir los objetos cuyo tipo exacto sea B usando el método `GetType()` y el operador `typeof`:
~~~
static void Main(string[] args)
{
    A[] vector = new A[] { new C(1), new D(2), new B(3), new D(4), new B(5) };
    foreach (A a in vector)
    {
        Type t = a.GetType();
        if(t.Equals(typeof(B))){
            a.Imprimir();
        }
    }
}
~~~
En este caso, por medio del método `GetType()`, obtenemos el tipo de variable **a** y lo podemos comparar utilizando el método `Equals()` junto al operador `typeof()`.

## Ejercicio 03
EL código no funciona porque la variable **velocidad** definida en el padre, no posee un modificador de acceso especifico, por lo que el compilador le coloca un `private` por defecto, lo que impide que la clase derivada *Taxi*, pueda acceder a el.
La forma rápida de solucionar el problema es agregarle a la variable **velocidad**, el modificador de acceso `protected`, lo cual permite que clases derivadas accedan a variables de la clase padre.
~~~
class Auto
{
    protected double velocidad;
    public virtual void Acelerar()
    => Console.WriteLine("Velocidad = {0}", velocidad += 10);
}
~~~

## Ejercicio 04

En primer momento, no es necesario agregar la extensión del constructor de la clase padre, ya que se toma el constructor por defecto del padre y la marca se inicializa por defecto con la cadena "Ford". Pero si quisieramos introducir nuestra propia marca, deberiamos modificar el constructor de la clase derivada.

Ahora modificamos la clase `Auto`, eliminando el segundo constructor y modificamos la clase `Taxi`, para que el constructor incluya la llamada al constructor del padre. Ademas le pasamos otra marca para que utilice esa como asiganción:
~~~
class Auto
{
    public string Marca { get; private set; } = "Ford";
    public Auto(string marca) => this.Marca = marca;
}
class Taxi : Auto
{
    public int Pasajeros { get; private set; }
    public Taxi(int pasajeros) : base("Peugeot") => this.Pasajeros = pasajeros;
}
~~~ 

## Ejercicio 05
Las lineas que provocan errores son aquellas que involucran el manejo externo o interno de variables pertenecientes a la clase `Persona` por la clase `Auto`:
~~~
public Persona GetPrimerDueño() => _dueño1;
protected Persona SegundoDueño
{
    set => _dueño2 = value;
}
~~~
Y los errores surgen a partir de que las clases poseen dos tipos de accesos diferentes, una es publica y la otra privada. No esta permitido que las clases de mayor acceso intercedan en la creación, modificación o eliminación de variables o Propiedades pertenecientes a clases de menor acceso.

## Ejercicio 06

* __6.1:__ 
* __6.2:__ 
* __6.3:__ 
* __6.4:__ 
* __6.5:__ 
* __6.6:__ 
* __6.7:__ 
* __6.8:__ 
* __6.9:__ 
* __6.10:__ 
* __6.11:__ 
* __6.12:__ 