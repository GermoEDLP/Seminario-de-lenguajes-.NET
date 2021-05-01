using System;

namespace practica6
{
    class Program
    {
        /*
        EJERCICIO 01 y 02
        =================

        static void Main(string[] args)
        {
            
        }
        class A
        {
            protected int _id;
            public A(int id) => _id = id;
            public virtual void Imprimir() => Console.WriteLine($"A_{_id}");
        }
        class B : A
        {
            public B(int id) : base(id) { }
            public override void Imprimir()
            {
                Console.Write($"B_{_id} --> ");
                base.Imprimir();
            }
        }
        class C : B
        {
            public C(int id) : base(id) { }
            public override void Imprimir()
            {
                Console.Write($"C_{_id} --> ");
                base.Imprimir();
            }
        }
        class D : C
        {
            public D(int id) : base(id) { }
            public override void Imprimir()
            {
                Console.Write($"D_{_id} --> ");
                base.Imprimir();
            }
        }
        
        */
        /*
        EJERCICIO 03
        ============
        
        static void Main(string[] args)
        {

        }
        class Auto
        {
            protected double velocidad;
            public virtual void Acelerar()
            => Console.WriteLine("Velocidad = {0}", velocidad += 10);
        }
        class Taxi : Auto
        {
            public override void Acelerar()
            => Console.WriteLine("Velocidad = {0}", velocidad += 5);
        }
        */

        /*
        EJERCICIO 04
        ============
        
        static void Main(string[] args)
        {
            Taxi t = new Taxi(3);
            Console.WriteLine($"Un {t.Marca} con {t.Pasajeros} pasajeros");
        }

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
        */

        

        
    }
}
