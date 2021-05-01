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
