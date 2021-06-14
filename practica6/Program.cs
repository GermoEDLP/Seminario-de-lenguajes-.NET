using System;
using System.Text;

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

        /*
        EJERCICIO 08
        ============
        
                static void Main(string[] args)
        {
            Empleado[] empleados = new Empleado[] {
                new Administrativo("Ana", 20000000, DateTime.Parse("26/4/2018"), 10000) {Premio=1000},
                new Vendedor("Diego", 30000000, DateTime.Parse("2/4/2010"), 10000) {Comision=2000},
                new Vendedor("Luis", 33333333, DateTime.Parse("30/12/2011"), 10000) {Comision=2000}
            };
            foreach (Empleado e in empleados)
            {
                Console.WriteLine(e);
                e.AumentarSalario();
                Console.WriteLine(e);
            }
            Console.Read();
        }

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
            public Administrativo(string nombre, int dni, DateTime fecha, double salarioBase) : base(nombre, dni, fecha, salarioBase)
            {

            }
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
            public Vendedor(string nombre, int dni, DateTime fecha, double salarioBase) : base(nombre, dni, fecha, salarioBase)
            {

            }
            public override string ToString()
            {
                return "Vendedor " + base.ToString() + ", Salario: " + Salario + "\n------------";
            }
        }
        
*/


    }
}
