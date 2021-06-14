using System;
using System.Collections;
using System.IO;

namespace practica7
{
    class Program
    {
        /*
        * ==================
        * Ejercicio  01 y 02  
        * ==================
        
          static void Main(string[] args)
        {
            
            Auto auto = new Auto();
            Libro libro = new Libro();
            Persona persona = new Persona();
            Perro perro = new Perro();
            Pelicula pelicula = new Pelicula();
            Procesador.Alquilar(pelicula, persona);
            Procesador.Alquilar(libro, persona);
            Procesador.Atender(persona);
            Procesador.Atender(perro);
            Procesador.Devolver(pelicula, persona);
            Procesador.Devolver(libro, persona);
            Procesador.Lavar(auto);
            Procesador.Reciclar(libro);
            Procesador.Reciclar(auto);
            Procesador.Secar(auto);
            Procesador.Vender(auto, persona);
            Procesador.Vender(perro, persona);
            Procesador.Lavar(perro);
            Procesador.Secar(perro);
            PeliculaClasica peliculaClasica = new PeliculaClasica();
            Procesador.Alquilar(peliculaClasica, persona);
            Procesador.Devolver(peliculaClasica, persona);
            Procesador.Vender(peliculaClasica, persona);
            
            Console.Read();
        }

        // Procesador
        static class Procesador
        {
            public static void Alquilar(IAlquilable x, Persona p) => x.SeAlquilaA(p);
            public static void Atender(IAtendible x) => x.SeAtiende();
            public static void Devolver(IAlquilable x, Persona p) => x.SeDevuelve(p);
            public static void Lavar(ILavable l) => l.SeLava();
            public static void Reciclar(IReciclable r) => r.SeRecicla();
            public static void Secar(ILavable l) => l.SeSeca();
            public static void Vender(IVendible v, Persona p) => v.SeVende(p);
        }

        // Interfaces
        public interface IAlquilable
        {
            void SeAlquilaA(Persona p);
            void SeDevuelve(Persona p);
        }

        public interface IVendible
        {
            void SeVende(Persona p);
        }

        public interface ILavable
        {
            void SeLava();
            void SeSeca();
        }

        public interface IReciclable
        {
            void SeRecicla();
        }

        public interface IAtendible
        {
            void SeAtiende();
        }

        // Clases
        public class Auto : IReciclable, IVendible, ILavable
        {
            public void SeRecicla() => Console.WriteLine("Reciclando auto");
            public void SeVende(Persona p) => Console.WriteLine("Vendiendo auto a persona");
            public void SeLava() => Console.WriteLine("Lavando auto");
            public void SeSeca() => Console.WriteLine("Secando auto");
        }

        public class Persona : IAtendible
        {
            public void SeAtiende() => Console.WriteLine("Atendiendo a persona");
        }

        public class Perro : IAtendible, IVendible, ILavable
        {
            public void SeAtiende() => Console.WriteLine("Atendiendo a perro");
            public void SeVende(Persona p) => Console.WriteLine("Vendiendo perro a persona");
            public void SeLava() => Console.WriteLine("Lavando perro");
            public void SeSeca() => Console.WriteLine("Secando perro");
        }

        public class Libro : IAlquilable, IReciclable
        {
            public void SeAlquilaA(Persona p) => Console.WriteLine("Alquilando libro a persona");
            public void SeDevuelve(Persona p) => Console.WriteLine("Libro devuelto por persona");
            public void SeRecicla() => Console.WriteLine("Reciclando libro");
        }

        public class Pelicula : IAlquilable
        {
            public virtual void SeAlquilaA(Persona p) => Console.WriteLine("Alquilando pelicula a persona");
            public virtual void SeDevuelve(Persona p) => Console.WriteLine("Pelicula devuelta por persona");
        }

        public class PeliculaClasica : Pelicula, IVendible
        {
            public override void SeAlquilaA(Persona p) => Console.WriteLine("Alquilando pelicula clásica a persona");
            public override void SeDevuelve(Persona p) => Console.WriteLine("Pelicula clásica devuelta por persona");
            public void SeVende(Persona p) => Console.WriteLine("Vendiendo pélicula clásica a persona");
        }
        */

        /*
        * ==================
        * Ejercicio       03
        * ==================
        
          static void Main(string[] args)
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList() {
                new Persona(),
                new Auto()
            };
            foreach (IComercial c in lista)
            {
                c.Importa();
            }
            foreach (IImportante i in lista)
            {
                i.Importa();
            }
            (lista[0] as Persona).Importa();
            (lista[1] as Auto).Importa();

            Console.Read();
        }

        // Procesador
        static class Procesador
        {
            public static void Alquilar(IAlquilable x, Persona p) => x.SeAlquilaA(p);
            public static void Atender(IAtendible x) => x.SeAtiende();
            public static void Devolver(IAlquilable x, Persona p) => x.SeDevuelve(p);
            public static void Lavar(ILavable l) => l.SeLava();
            public static void Reciclar(IReciclable r) => r.SeRecicla();
            public static void Secar(ILavable l) => l.SeSeca();
            public static void Vender(IVendible v, Persona p) => v.SeVende(p);
        }

        // Interfaces
        public interface IAlquilable
        {
            void SeAlquilaA(Persona p);
            void SeDevuelve(Persona p);
        }

        public interface IVendible
        {
            void SeVende(Persona p);
        }

        public interface ILavable
        {
            void SeLava();
            void SeSeca();
        }

        public interface IReciclable
        {
            void SeRecicla();
        }

        public interface IAtendible
        {
            void SeAtiende();
        }

        public interface IComercial
        {
            void Importa();
        }

        public interface IImportante
        {
            void Importa();
        }

        // Clases
        public class Auto : IReciclable, IVendible, ILavable, IComercial, IImportante
        {
            public void SeRecicla() => Console.WriteLine("Reciclando auto");
            public void SeVende(Persona p) => Console.WriteLine("Vendiendo auto a persona");
            public void SeLava() => Console.WriteLine("Lavando auto");
            public void SeSeca() => Console.WriteLine("Secando auto");
            void IComercial.Importa() => Console.WriteLine("Auto que se vende al exterior");
            void IImportante.Importa() => Console.WriteLine("Auto importante");
            public void Importa() => Console.WriteLine("Método Importar() de la clase Auto");
        }

        public class Persona : IAtendible, IComercial, IImportante
        {
            public void SeAtiende() => Console.WriteLine("Atendiendo a persona");
            void IComercial.Importa() => Console.WriteLine("Persona vendiendo al exterior");
            void IImportante.Importa() => Console.WriteLine("Persona importante");
            public void Importa() => Console.WriteLine("Método Importar() de la clase Persona");
        }

        public class Perro : IAtendible, IVendible, ILavable
        {
            public void SeAtiende() => Console.WriteLine("Atendiendo a perro");
            public void SeVende(Persona p) => Console.WriteLine("Vendiendo perro a persona");
            public void SeLava() => Console.WriteLine("Lavando perro");
            public void SeSeca() => Console.WriteLine("Secando perro");
        }

        public class Libro : IAlquilable, IReciclable
        {
            public void SeAlquilaA(Persona p) => Console.WriteLine("Alquilando libro a persona");
            public void SeDevuelve(Persona p) => Console.WriteLine("Libro devuelto por persona");
            public void SeRecicla() => Console.WriteLine("Reciclando libro");
        }

        public class Pelicula : IAlquilable
        {
            public virtual void SeAlquilaA(Persona p) => Console.WriteLine("Alquilando pelicula a persona");
            public virtual void SeDevuelve(Persona p) => Console.WriteLine("Pelicula devuelta por persona");
        }

        public class PeliculaClasica : Pelicula, IVendible
        {
            public override void SeAlquilaA(Persona p) => Console.WriteLine("Alquilando pelicula clásica a persona");
            public override void SeDevuelve(Persona p) => Console.WriteLine("Pelicula clásica devuelta por persona");
            public void SeVende(Persona p) => Console.WriteLine("Vendiendo pélicula clásica a persona");
        }
        
*/
        /*
        * ==================
        * Ejercicio       04
        * ==================
        
        static void Main(string[] args)
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList() {
                new Persona() {Nombre="Zulema"},
                new Perro() {Nombre="Sultán"},
                new Persona() {Nombre="Claudia"},
                new Persona() {Nombre="Carlos"},
                new Perro() {Nombre="Chopper"},
            };
            lista.Sort(); //debe ordenar por Nombre alfabéticamente
            foreach (INombrable n in lista)
            {
                Console.WriteLine($"{n.Nombre}: {n}");
            }

            Console.Read();
        }

        // Procesador
        static class Procesador
        {
            public static void Alquilar(IAlquilable x, Persona p) => x.SeAlquilaA(p);
            public static void Atender(IAtendible x) => x.SeAtiende();
            public static void Devolver(IAlquilable x, Persona p) => x.SeDevuelve(p);
            public static void Lavar(ILavable l) => l.SeLava();
            public static void Reciclar(IReciclable r) => r.SeRecicla();
            public static void Secar(ILavable l) => l.SeSeca();
            public static void Vender(IVendible v, Persona p) => v.SeVende(p);
        }

        // Interfaces
        public interface IAlquilable
        {
            void SeAlquilaA(Persona p);
            void SeDevuelve(Persona p);
        }

        public interface IVendible
        {
            void SeVende(Persona p);
        }

        public interface ILavable
        {
            void SeLava();
            void SeSeca();
        }

        public interface IReciclable
        {
            void SeRecicla();
        }

        public interface IAtendible
        {
            void SeAtiende();
        }

        public interface IComercial
        {
            void Importa();
        }

        public interface IImportante
        {
            void Importa();
        }

        public interface INombrable
        {
            public string Nombre { get; set; }
        }

        // Clases
        public class Auto : IReciclable, IVendible, ILavable, IComercial, IImportante
        {
            public void SeRecicla() => Console.WriteLine("Reciclando auto");
            public void SeVende(Persona p) => Console.WriteLine("Vendiendo auto a persona");
            public void SeLava() => Console.WriteLine("Lavando auto");
            public void SeSeca() => Console.WriteLine("Secando auto");
            void IComercial.Importa() => Console.WriteLine("Auto que se vende al exterior");
            void IImportante.Importa() => Console.WriteLine("Auto importante");
            public void Importa() => Console.WriteLine("Método Importar() de la clase Auto");
        }

        public class Persona : IAtendible, IComercial, IImportante, INombrable, IComparable
        {
            public string Nombre { get; set; }
            public void SeAtiende() => Console.WriteLine("Atendiendo a persona");
            void IComercial.Importa() => Console.WriteLine("Persona vendiendo al exterior");
            void IImportante.Importa() => Console.WriteLine("Persona importante");
            public void Importa() => Console.WriteLine("Método Importar() de la clase Persona");
            public int CompareTo(object obj){
                string st1 = this.Nombre;
                string st2 = (obj as INombrable).Nombre;
                return st1.CompareTo(st2);
            }
            public override string ToString(){
                return this.Nombre + " es una persona";
            }
        }

        public class Perro : IAtendible, IVendible, ILavable, INombrable, IComparable
        {
            public string Nombre { get; set; }
            public void SeAtiende() => Console.WriteLine("Atendiendo a perro");
            public void SeVende(Persona p) => Console.WriteLine("Vendiendo perro a persona");
            public void SeLava() => Console.WriteLine("Lavando perro");
            public void SeSeca() => Console.WriteLine("Secando perro");
            public int CompareTo(object obj){
                string st1 = this.Nombre;
                string st2 = (obj as INombrable).Nombre;
                return st1.CompareTo(st2);
            }
            public override string ToString(){
                return this.Nombre + " es un perro";
            }
        }

        public class Libro : IAlquilable, IReciclable
        {
            public void SeAlquilaA(Persona p) => Console.WriteLine("Alquilando libro a persona");
            public void SeDevuelve(Persona p) => Console.WriteLine("Libro devuelto por persona");
            public void SeRecicla() => Console.WriteLine("Reciclando libro");
        }

        public class Pelicula : IAlquilable
        {
            public virtual void SeAlquilaA(Persona p) => Console.WriteLine("Alquilando pelicula a persona");
            public virtual void SeDevuelve(Persona p) => Console.WriteLine("Pelicula devuelta por persona");
        }

        public class PeliculaClasica : Pelicula, IVendible
        {
            public override void SeAlquilaA(Persona p) => Console.WriteLine("Alquilando pelicula clásica a persona");
            public override void SeDevuelve(Persona p) => Console.WriteLine("Pelicula clásica devuelta por persona");
            public void SeVende(Persona p) => Console.WriteLine("Vendiendo pélicula clásica a persona");
        }          
        
*/
        /*
        * ==================
        * Ejercicio       05
        * ==================
        
          static void Main(string[] args)
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList() {
                new Persona() {Nombre="Zulema"},
                new Perro() {Nombre="Sultán"},
                new Persona() {Nombre="Claudia"},
                new Persona() {Nombre="Carlos"},
                new Perro() {Nombre="Chopper"},
            };
            lista.Sort(); //debe ordenar por Nombre alfabéticamente
            foreach (INombrable n in lista)
            {
                Console.WriteLine($"{n.Nombre}: {n}");
            }

            Console.Read();
        }

        // Procesador
        static class Procesador
        {
            public static void Alquilar(IAlquilable x, Persona p) => x.SeAlquilaA(p);
            public static void Atender(IAtendible x) => x.SeAtiende();
            public static void Devolver(IAlquilable x, Persona p) => x.SeDevuelve(p);
            public static void Lavar(ILavable l) => l.SeLava();
            public static void Reciclar(IReciclable r) => r.SeRecicla();
            public static void Secar(ILavable l) => l.SeSeca();
            public static void Vender(IVendible v, Persona p) => v.SeVende(p);
        }

        // Interfaces
        public interface IAlquilable
        {
            void SeAlquilaA(Persona p);
            void SeDevuelve(Persona p);
        }

        public interface IVendible
        {
            void SeVende(Persona p);
        }

        public interface ILavable
        {
            void SeLava();
            void SeSeca();
        }

        public interface IReciclable
        {
            void SeRecicla();
        }

        public interface IAtendible
        {
            void SeAtiende();
        }

        public interface IComercial
        {
            void Importa();
        }

        public interface IImportante
        {
            void Importa();
        }

        public interface INombrable
        {
            public string Nombre { get; set; }
        }

        // Clases
        public class Auto : IReciclable, IVendible, ILavable, IComercial, IImportante
        {
            public void SeRecicla() => Console.WriteLine("Reciclando auto");
            public void SeVende(Persona p) => Console.WriteLine("Vendiendo auto a persona");
            public void SeLava() => Console.WriteLine("Lavando auto");
            public void SeSeca() => Console.WriteLine("Secando auto");
            void IComercial.Importa() => Console.WriteLine("Auto que se vende al exterior");
            void IImportante.Importa() => Console.WriteLine("Auto importante");
            public void Importa() => Console.WriteLine("Método Importar() de la clase Auto");
        }

        public class Persona : IAtendible, IComercial, IImportante, INombrable, IComparable
        {
            public string Nombre { get; set; }
            public void SeAtiende() => Console.WriteLine("Atendiendo a persona");
            void IComercial.Importa() => Console.WriteLine("Persona vendiendo al exterior");
            void IImportante.Importa() => Console.WriteLine("Persona importante");
            public void Importa() => Console.WriteLine("Método Importar() de la clase Persona");
            public int CompareTo(object obj){
                string st1 = this.Nombre;
                string st2 = (obj as INombrable).Nombre;
                return st1.CompareTo(st2);
            }
            public override string ToString(){
                return this.Nombre + " es una persona";
            }
        }

        public class Perro : IAtendible, IVendible, ILavable, INombrable, IComparable
        {
            public string Nombre { get; set; }
            public void SeAtiende() => Console.WriteLine("Atendiendo a perro");
            public void SeVende(Persona p) => Console.WriteLine("Vendiendo perro a persona");
            public void SeLava() => Console.WriteLine("Lavando perro");
            public void SeSeca() => Console.WriteLine("Secando perro");
            public int CompareTo(object obj){
                if(obj is Persona) return 1;
                string st1 = this.Nombre;
                string st2 = (obj as INombrable).Nombre;
                return st1.CompareTo(st2);
            }
            public override string ToString(){
                return this.Nombre + " es un perro";
            }
        }

        public class Libro : IAlquilable, IReciclable
        {
            public void SeAlquilaA(Persona p) => Console.WriteLine("Alquilando libro a persona");
            public void SeDevuelve(Persona p) => Console.WriteLine("Libro devuelto por persona");
            public void SeRecicla() => Console.WriteLine("Reciclando libro");
        }

        public class Pelicula : IAlquilable
        {
            public virtual void SeAlquilaA(Persona p) => Console.WriteLine("Alquilando pelicula a persona");
            public virtual void SeDevuelve(Persona p) => Console.WriteLine("Pelicula devuelta por persona");
        }

        public class PeliculaClasica : Pelicula, IVendible
        {
            public override void SeAlquilaA(Persona p) => Console.WriteLine("Alquilando pelicula clásica a persona");
            public override void SeDevuelve(Persona p) => Console.WriteLine("Pelicula clásica devuelta por persona");
            public void SeVende(Persona p) => Console.WriteLine("Vendiendo pélicula clásica a persona");
        }
        */

        /*
        * ==================
        * Ejercicio       06
        * ==================
    
          static void Main(string[] args)
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList() {
                new Persona() {Nombre="Ana María"},
                new Perro() {Nombre="Sultán"},
                new Persona() {Nombre="Ana"},
                new Persona() {Nombre="José Carlos"},
                new Perro() {Nombre="Chopper"}
            };
            lista.Sort(new ComparadorLongitudNombre()); //debe ordenar por Nombre alfabéticamente
            foreach (INombrable n in lista)
            {
                Console.WriteLine($"{n.Nombre.Length}: {n.Nombre}");
            }

            Console.Read();
        }

        // Procesador
        static class Procesador
        {
            public static void Alquilar(IAlquilable x, Persona p) => x.SeAlquilaA(p);
            public static void Atender(IAtendible x) => x.SeAtiende();
            public static void Devolver(IAlquilable x, Persona p) => x.SeDevuelve(p);
            public static void Lavar(ILavable l) => l.SeLava();
            public static void Reciclar(IReciclable r) => r.SeRecicla();
            public static void Secar(ILavable l) => l.SeSeca();
            public static void Vender(IVendible v, Persona p) => v.SeVende(p);
        }

        // Interfaces
        public interface IAlquilable
        {
            void SeAlquilaA(Persona p);
            void SeDevuelve(Persona p);
        }

        public interface IVendible
        {
            void SeVende(Persona p);
        }

        public interface ILavable
        {
            void SeLava();
            void SeSeca();
        }

        public interface IReciclable
        {
            void SeRecicla();
        }

        public interface IAtendible
        {
            void SeAtiende();
        }

        public interface IComercial
        {
            void Importa();
        }

        public interface IImportante
        {
            void Importa();
        }

        public interface INombrable
        {
            public string Nombre { get; set; }
        }

        // Clases
        public class Auto : IReciclable, IVendible, ILavable, IComercial, IImportante
        {
            public void SeRecicla() => Console.WriteLine("Reciclando auto");
            public void SeVende(Persona p) => Console.WriteLine("Vendiendo auto a persona");
            public void SeLava() => Console.WriteLine("Lavando auto");
            public void SeSeca() => Console.WriteLine("Secando auto");
            void IComercial.Importa() => Console.WriteLine("Auto que se vende al exterior");
            void IImportante.Importa() => Console.WriteLine("Auto importante");
            public void Importa() => Console.WriteLine("Método Importar() de la clase Auto");
        }

        public class Persona : IAtendible, IComercial, IImportante, INombrable, IComparable
        {
            public string Nombre { get; set; }
            public void SeAtiende() => Console.WriteLine("Atendiendo a persona");
            void IComercial.Importa() => Console.WriteLine("Persona vendiendo al exterior");
            void IImportante.Importa() => Console.WriteLine("Persona importante");
            public void Importa() => Console.WriteLine("Método Importar() de la clase Persona");
            public int CompareTo(object obj)
            {
                string st1 = this.Nombre;
                string st2 = (obj as INombrable).Nombre;
                return st1.CompareTo(st2);
            }
            public override string ToString()
            {
                return this.Nombre + " es una persona";
            }
        }

        public class Perro : IAtendible, IVendible, ILavable, INombrable, IComparable
        {
            public string Nombre { get; set; }
            public void SeAtiende() => Console.WriteLine("Atendiendo a perro");
            public void SeVende(Persona p) => Console.WriteLine("Vendiendo perro a persona");
            public void SeLava() => Console.WriteLine("Lavando perro");
            public void SeSeca() => Console.WriteLine("Secando perro");
            public int CompareTo(object obj)
            {
                if (obj is Persona) return 1;
                string st1 = this.Nombre;
                string st2 = (obj as INombrable).Nombre;
                return st1.CompareTo(st2);
            }
            public override string ToString()
            {
                return this.Nombre + " es un perro";
            }
        }

        public class Libro : IAlquilable, IReciclable
        {
            public void SeAlquilaA(Persona p) => Console.WriteLine("Alquilando libro a persona");
            public void SeDevuelve(Persona p) => Console.WriteLine("Libro devuelto por persona");
            public void SeRecicla() => Console.WriteLine("Reciclando libro");
        }

        public class Pelicula : IAlquilable
        {
            public virtual void SeAlquilaA(Persona p) => Console.WriteLine("Alquilando pelicula a persona");
            public virtual void SeDevuelve(Persona p) => Console.WriteLine("Pelicula devuelta por persona");
        }

        public class PeliculaClasica : Pelicula, IVendible
        {
            public override void SeAlquilaA(Persona p) => Console.WriteLine("Alquilando pelicula clásica a persona");
            public override void SeDevuelve(Persona p) => Console.WriteLine("Pelicula clásica devuelta por persona");
            public void SeVende(Persona p) => Console.WriteLine("Vendiendo pélicula clásica a persona");
        }

        class ComparadorLongitudNombre : IComparer
        {
            public int Compare(object x, object y)
            {
                INombrable n1 = x as INombrable;
                INombrable n2 = y as INombrable;
                return n1.Nombre.Length.CompareTo(n2.Nombre.Length);
            }
        }
        
*/
        /*
        * ==================
        * Ejercicio       07
        * ==================
        
          static void Main(string[] args)
        {
            System.Collections.ArrayList lista = new System.Collections.ArrayList() {
                new Persona() {Nombre="Ana María"},
                new Perro() {Nombre="Sultán"},
                new Persona() {Nombre="Ana"},
                new Persona() {Nombre="José Carlos"},
                new Perro() {Nombre="Chopper"}
            };
            lista.Sort(new ComparadorRandom());
            foreach (INombrable n in lista)
            {
                Console.WriteLine($"{n.Nombre.Length}: {n.Nombre}");
            }
            Console.Read();
        }

        // Procesador
        static class Procesador
        {
            public static void Alquilar(IAlquilable x, Persona p) => x.SeAlquilaA(p);
            public static void Atender(IAtendible x) => x.SeAtiende();
            public static void Devolver(IAlquilable x, Persona p) => x.SeDevuelve(p);
            public static void Lavar(ILavable l) => l.SeLava();
            public static void Reciclar(IReciclable r) => r.SeRecicla();
            public static void Secar(ILavable l) => l.SeSeca();
            public static void Vender(IVendible v, Persona p) => v.SeVende(p);
        }

        // Interfaces
        public interface IAlquilable
        {
            void SeAlquilaA(Persona p);
            void SeDevuelve(Persona p);
        }

        public interface IVendible
        {
            void SeVende(Persona p);
        }

        public interface ILavable
        {
            void SeLava();
            void SeSeca();
        }

        public interface IReciclable
        {
            void SeRecicla();
        }

        public interface IAtendible
        {
            void SeAtiende();
        }

        public interface IComercial
        {
            void Importa();
        }

        public interface IImportante
        {
            void Importa();
        }

        public interface INombrable
        {
            public string Nombre { get; set; }
        }

        // Clases
        public class Auto : IReciclable, IVendible, ILavable, IComercial, IImportante
        {
            public void SeRecicla() => Console.WriteLine("Reciclando auto");
            public void SeVende(Persona p) => Console.WriteLine("Vendiendo auto a persona");
            public void SeLava() => Console.WriteLine("Lavando auto");
            public void SeSeca() => Console.WriteLine("Secando auto");
            void IComercial.Importa() => Console.WriteLine("Auto que se vende al exterior");
            void IImportante.Importa() => Console.WriteLine("Auto importante");
            public void Importa() => Console.WriteLine("Método Importar() de la clase Auto");
        }

        public class Persona : IAtendible, IComercial, IImportante, INombrable, IComparable
        {
            public string Nombre { get; set; }
            public void SeAtiende() => Console.WriteLine("Atendiendo a persona");
            void IComercial.Importa() => Console.WriteLine("Persona vendiendo al exterior");
            void IImportante.Importa() => Console.WriteLine("Persona importante");
            public void Importa() => Console.WriteLine("Método Importar() de la clase Persona");
            public int CompareTo(object obj)
            {
                string st1 = this.Nombre;
                string st2 = (obj as INombrable).Nombre;
                return st1.CompareTo(st2);
            }
            public override string ToString()
            {
                return this.Nombre + " es una persona";
            }
        }

        public class Perro : IAtendible, IVendible, ILavable, INombrable, IComparable
        {
            public string Nombre { get; set; }
            public void SeAtiende() => Console.WriteLine("Atendiendo a perro");
            public void SeVende(Persona p) => Console.WriteLine("Vendiendo perro a persona");
            public void SeLava() => Console.WriteLine("Lavando perro");
            public void SeSeca() => Console.WriteLine("Secando perro");
            public int CompareTo(object obj)
            {
                if (obj is Persona) return 1;
                string st1 = this.Nombre;
                string st2 = (obj as INombrable).Nombre;
                return st1.CompareTo(st2);
            }
            public override string ToString()
            {
                return this.Nombre + " es un perro";
            }
        }

        public class Libro : IAlquilable, IReciclable
        {
            public void SeAlquilaA(Persona p) => Console.WriteLine("Alquilando libro a persona");
            public void SeDevuelve(Persona p) => Console.WriteLine("Libro devuelto por persona");
            public void SeRecicla() => Console.WriteLine("Reciclando libro");
        }

        public class Pelicula : IAlquilable
        {
            public virtual void SeAlquilaA(Persona p) => Console.WriteLine("Alquilando pelicula a persona");
            public virtual void SeDevuelve(Persona p) => Console.WriteLine("Pelicula devuelta por persona");
        }

        public class PeliculaClasica : Pelicula, IVendible
        {
            public override void SeAlquilaA(Persona p) => Console.WriteLine("Alquilando pelicula clásica a persona");
            public override void SeDevuelve(Persona p) => Console.WriteLine("Pelicula clásica devuelta por persona");
            public void SeVende(Persona p) => Console.WriteLine("Vendiendo pélicula clásica a persona");
        }

        class ComparadorLongitudNombre : IComparer
        {
            public int Compare(object x, object y)
            {
                INombrable n1 = x as INombrable;
                INombrable n2 = y as INombrable;
                return n1.Nombre.Length.CompareTo(n2.Nombre.Length);
            }
        }

        class ComparadorRandom: IComparer{
            public int Compare(object x, object y){
                return new Random().Next(-2,2);
            }
        }
        */

        /*
        * ==================
        * Ejercicio       08
        * ==================
        */
           static void Main(string[] args)
        {
            IEnumerable rango = Rango(6, 30, 3);
            IEnumerable potencias = Potencias(2, 10);
            IEnumerable divisibles = DivisiblesPor(rango, 6);
            foreach (int i in rango)
            {
                Console.Write(i + " ");
            }
                Console.WriteLine();
            foreach (int i in potencias)
            {
                Console.Write(i + " ");
            }
                Console.WriteLine();
            foreach (int i in divisibles)
            {
                Console.Write(i + " ");
            }
            Console.Read();
        }

        static IEnumerable Rango(int i, int f, int p)
        {
            int aux = i;
            while (aux <= f)
            {
                yield return aux;
                aux += p;
            }
        }
        static IEnumerable Potencias(int b, int p)
        {
            int aux = 1;
           while(aux<=p){
               int pot = 1;
               for (int i = 0; i < aux; i++)
               {
                   pot = pot*b;
               }
               yield return pot;
               aux++;
           }
        }

        static IEnumerable DivisiblesPor(IEnumerable e, int m)
        {
            foreach (int i in e)
            {
                if(i%m==0){
                    yield return i;
                }
            }
        }
        
        /*
        * ==================
        * Ejercicio      09a 
        * ==================
        
          static void Main(string[] args)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("texto.txt"))
                {
                    string st = Console.ReadLine();
                    while (st != "")
                    {
                        sw.WriteLine(st);
                        st = Console.ReadLine();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        */

        /*
        * ==================
        * Ejercicio      09b 
        * ==================
        static void Main(string[] args)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter("texto.txt");
                string st = Console.ReadLine();
                while (st != "")
                {
                    sw.WriteLine(st);
                    st = Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sw != null) sw.Dispose();
            }

        }
          
        */

        /*
        * ==================
        * Ejercicio       10
        * ==================
        
          
        
        static void Main(string[] args)
        {
            ArrayList autos = new ArrayList();
            char opc;
            do
            {
                opc = Menu();
                switch (opc)
                {
                    case '1':
                        Ingresar(autos);
                        break;
                    case '2':
                        Cargar(autos);
                        break;
                    case '3':
                        Guardar(autos);
                        break;
                    case '4':
                        Listar(autos);
                        break;
                }
            } while (opc != '5');
        }

        static char Menu()
        {
            Console.WriteLine("Menú de opciones");
            Console.WriteLine("================");
            Console.WriteLine("");
            Console.WriteLine("1. Ingresar autos desde la consola");
            Console.WriteLine("2. Cargar lista de autos desde el disco");
            Console.WriteLine("3. Guardar lista de autos en el disco");
            Console.WriteLine("4. Listar por consola");
            Console.WriteLine("5. Salir");
            Console.WriteLine("");
            Console.Write("Ingrese su opción: ");
            ConsoleKeyInfo opc = Console.ReadKey(true);
            Console.WriteLine(opc.KeyChar);
            return opc.KeyChar;
        }

        static void Ingresar(ArrayList a)
        {
            Console.WriteLine("Marca: ");
            string st = Console.ReadLine();
            while (st != "")
            {
                Auto auto = new Auto();
                auto.Marca = st;
                Console.WriteLine("Modelo: ");
                auto.Modelo = Console.ReadLine();
                a.Add(auto);
                Console.WriteLine("Marca: ");
                st = Console.ReadLine();
            }
        }
        static void Cargar(ArrayList a)
        {
            StreamReader sr = new StreamReader("autosCargar.txt");
            try
            {
                while(!sr.EndOfStream){
                    Auto auto = new Auto();
                    auto.Marca = sr.ReadLine();
                    auto.Modelo = sr.ReadLine();
                    a.Add(auto);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (sr != null) sr.Dispose();
            }

        }
        static void Guardar(ArrayList a)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("autosGuardar.txt"))
                {
                    IEnumerator autos = a.GetEnumerator();
                    while (autos.MoveNext())
                    {
                        Auto autoActual = (Auto)autos.Current;
                        sw.WriteLine(autoActual.Marca);
                        sw.WriteLine(autoActual.Modelo);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Listar(ArrayList a)
        {
             IEnumerator autos = a.GetEnumerator();
             Console.WriteLine("");
            while (autos.MoveNext())
            {
                Auto auto = (Auto)autos.Current;
                Console.WriteLine($"Auto: {auto.Marca} ({auto.Modelo})");
            }
            Console.WriteLine("");
        }
        class Auto
        {
            public string Marca { get; set; }
            public string Modelo { get; set; }
        }
        */
    }
}
