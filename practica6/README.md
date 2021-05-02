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

* __6.1:__ No se puede definir una clase como *override* para sobreescribirla, si la clase a sobreescribir en el padre no es **virtual**, **abstract** u **override**
* __6.2:__ Si, al menos un método es abstracto, la clase debe ser abstracta. No es el caso de la clase `A`, que posee el método `M1()` de tipo abstracto y la clase no lo es.
* __6.3:__ Las clases abstractas no tienen declaración, sino que se declaran en las clases que se extienden de la clase donde son nombradas.
* __6.4:__ Para declarar un método como *override*, la clase debe derivar de otra que posea un método de tipo **virtual**, **abstract** u **override**. Este no es el caso, ya que la clase `A` no deriva de ninguna otra.
* __6.5:__ Un método sobreescrito (*override*) no puede cambiar el tipo de acceso que posee el método al que esta sobreescribiendo. El método `M1()` original es publico, por lo que el derivado no puede ser protegido.
* __6.6:__ Los miembros estáticos no pueden ser **virtual**, **abstract** u **override**.
* __6.7:__ Los métodos **virtual** o **abstract** no pueden ser privados, ya que su función es la de ser manejados de forma externa a la clase que los crea.
* __6.8:__ Al definir un constructor en `A`, el compilador ya no define el constructor vacio por defecto, por lo que debemos definirlo si lo queremos utilizar. En este caso, al `B` derivar de `A`, necesitamos definir el constructor vacio en `A` o pasarle, a traves del constructor de `B`, el parametro `i`
* __6.9:__ La variable `_id` es inaccesible desde la clase `B`, porque esta definida en `A` y es privada.
* __6.10:__ El método `get` no puede tener más acceso que la Propiedad que opera. `Prop` tiene acceso privado y el método `get`, es publico.
* __6.11:__ La propiedad `Prop` es creada de manera abstracta en la clase `A`, por lo que la clase `B` (que deriva de `A`) debe implementarla a la fuerza y completa. En B solo se implementa el método `get` de la misma, lo que causa un error.
* __6.12:__ Para declarar una Propiedad como *override*, la clase debe derivar de otra que posea un método de tipo **virtual**, **abstract** u **override** con el mismo nombre. La propiedad `Prop` no lo hace.

## Ejercicio 07
Para hacer más eficiente el código dado utilizando polimorfismo, podemos implementar varios caminos, aqui se usarán 2:
* **Crear una clase Principal:** Usando una clase abstracta Principal, se define una un método abstarcto de impresión y se coloca a todas las clases adicionales, como derivadas de esta clase princiapal. Además, se cambia el método de las demas clases para que se corresponda con el método abstracto de la clase padre Principal. Por útlimo, se modifica el foreach del método estatico Imprimidor para adecuarlo a la nueva configuración.
~~~
abstract class Principal
{
    public abstract void Imprimir();
}
class A: Principal
{
    public override void Imprimir() => Console.WriteLine("Soy una instancia A");
}
class B: Principal
{
    public override void Imprimir() => Console.WriteLine("Soy una instancia B");
}
class C: Principal
{
    public override void Imprimir() => Console.WriteLine("Soy una instancia C");
}
class D: Principal
{
    public override void Imprimir() => Console.WriteLine("Soy una instancia D");
}
static class Imprimidor
{
    public static void Imprimir(params object[] vector)
    {
        foreach (Principal o in vector)
        {
           o.Imprimir();
        }
    }
}
~~~ 
* **Usar la clase A como principal:** La otra forma es utilizar la clase `A` como padre y derivar las demas de ella. Tener en cuenta que el método `Imprimir()` de esta clase debe ser *virtual* para poder sobreescribirse en las demas clases.
~~~
class A
{
    public virtual void Imprimir() => Console.WriteLine("Soy una instancia A");
}
class B: A
{
    public override void Imprimir() => Console.WriteLine("Soy una instancia B");
}
class C: A
{
    public override void Imprimir() => Console.WriteLine("Soy una instancia C");
}
class D: A
{
    public override void Imprimir() => Console.WriteLine("Soy una instancia D");
}
static class Imprimidor
{
    public static void Imprimir(params object[] vector)
    {
        foreach (A o in vector)
        {
           o.Imprimir();
        }
    }
}
~~~

## Ejercicio 08

Primero se definio una clase abstracta llamada EMpleado, que contenga toda la información en común entre los dos tipos de empleados:
~~~
abstract class Empleado
{
public string Nombre
{
    protected set;
    get;
}
public int DNI
{
    protected set;
    get;
}
public DateTime FechaIngreso
{
    protected set;
    get;
}
public double SalarioBase
{
    protected set;
    get;
}
public abstract double Salario
{
    get;
}
public int Antiguedad
{
    get
    {
        DateTime hoy = DateTime.Parse("26/4/2020");
        int ant = hoy.Year - FechaIngreso.Year - 1;
        if (hoy.Month > FechaIngreso.Month)
        {
            ant++;
        }
        else if (hoy.Month == FechaIngreso.Month)
        {
            if (hoy.Day >= FechaIngreso.Day)
            {
                ant++;
            }
        }
        return ant;
    }
}

            public abstract void AumentarSalario();

            public Empleado(string nombre, int dni, DateTime fecha, double salarioBase)
            {
                Nombre = nombre;
                DNI = dni;
                FechaIngreso = fecha;
                SalarioBase = salarioBase;
            }

            public override string ToString()
            {
                return "Nombre " + Nombre + ", DNI: " + DNI + " Antiguedad: " + Antiguedad + "\nSalario Base: " + SalarioBase;
            }

        }
~~~
En ella definimos tambien, la propiedad Salario y el método AumentarSalario() como abstarctos para forzarlos en las clases derivadas. Además, definimos el constructor que utilizaremos en las clases derivadas.

Luego, definiremos las clases de Administrativo y Vendedor, como clases deriadas de Empleado y que ademas implementan los elementos abstarctos que se definen en la clase padre.
~~~
class Administrativo : Empleado
{
    public override double Salario
    {
        get
        {
            return SalarioBase + Premio;
        }
    }
    public double Premio
    {
        get;
        set;
    }
    public override void AumentarSalario()
    {
        SalarioBase = SalarioBase * (1 + (0.01 * Antiguedad));
    }
    public Administrativo(string nombre, int dni, DateTime fecha, double salarioBase) : base(nombre, dni, fecha, salarioBase){}
    public override string ToString()
    {
        return "Administrativo " + base.ToString() + ", Salario: " + Salario + "\n------------";
    }
}
class Vendedor : Empleado
{
    public override double Salario
    {
        get
        {
            return SalarioBase + Comision;
        }
    }
    public double Comision
    {
        get;
        set;
    }
    public override void AumentarSalario()
    {
        SalarioBase = (Antiguedad < 10) ? SalarioBase * 1.05 : SalarioBase * 1.1;
    }
    public Vendedor(string nombre, int dni, DateTime fecha, double salarioBase) : base(nombre, dni, fecha, salarioBase){}
    public override string ToString()
    {
        return "Vendedor " + base.ToString() + ", Salario: " + Salario + "\n------------";
    }
}
~~~
En estas clases:
* Utilizamos el constructor de la clase padre al pasarle todos los parametros de ingreso al constructor de las clases hijas.
* Definimos la Propiedad salario (obligatoria al ser abstracta en el padre), como la suma del salario base y los bonus.
* Definimos el método AumentarSalario() (obligatorio al ser abstracto en el padre), siguiendo los patrones establecidos.
* Definimos (sobreescribiendo) el método ToString() de cada clase para que, con la ayuda del método sobreescrito en el padre, podamos visulaizar la información de una manera más ordenada.