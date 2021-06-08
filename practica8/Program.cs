using System;
using System.Collections;

namespace practica8
{
    class Program
    {
        /*
        * ==================
        * Ejercicio       01
        * ==================
        
          delegate void Del1(int x);
        delegate void Del2(int[] x);
        delegate int Del3(int x);
        delegate bool Del4(string st);
        static void Main(string[] args)
        {
            Del1 d1 = delegate (int x) { Console.WriteLine(x); };
            d1(10);
            Del2 d2 = x => Console.WriteLine(x.Length);
            d2(new int[] { 2, 4, 6, 8 });
            Del3 d3 = x =>
            {
                int sum = 0;
                for (int i = 1; i <= x; i++)
                {
                    sum += i;
                }
                return sum;
            };
            Console.WriteLine(d3(10));
            Del4 d4 = new Del4(LongitudPar);
            Console.WriteLine(d4("hola mundo"));
            Console.Read();
        }
        public static bool LongitudPar(string st)
        {
            return st.Length % 2 == 0;
        }
        */
        /*
        * ==================
        * Ejercicio       02
        * ==================
        
          delegate void AccionInt(ref int i);
        static void Main(string[] args)
        {
            AccionInt a1 = (ref int i) => i = i * 2;
            a1 += a1;
            a1 += a1;
            a1 += a1;
            int i = 1;
            a1(ref i);
            Console.WriteLine();
            Console.Read();
            // Responder respecto de este punto en el programa
        }
        */

        /*
        * ==================
        * Ejercicio       03
        * ==================
        
          static void Main(string[] args)
        {
            int i = 10;
            Action a = delegate ()
            {
                Console.WriteLine(i);
            };
            a.Invoke();
            i = 20;
            a.Invoke();
            Console.Read();
        }
        */

        /*
        * ==================
        * Ejercicio       04
        * ==================

           static void Main(string[] args)
         {
             Action[] acciones = new Action[10];
             for (int i = 0; i < 10; i++)
             {
                 acciones[i] = () => Console.WriteLine(i + " ");
             }
             foreach (var a in acciones)
             {
                 a.Invoke();
             }
             Console.Read();
         }
        */
        /*
        * ==================
        * Ejercicio       05
        * ==================

           static void Main(string[] args)
         {
             ListaDeEnteros lista1 = new ListaDeEnteros();
             for (int i = 1; i <= 10; i++)
             {
                 lista1.Agregar(i);
             }
             foreach (int i in lista1)
             {
                 Console.Write(i + "-");
             }
             Console.WriteLine();
             ListaDeEnteros lista2 = lista1.Seleccionar(n => n % 2 == 0);
             ListaDeEnteros lista3 = lista2.Aplicar(n => n * 5);
             ListaDeEnteros lista4 = lista1.Seleccionar(n => n > 7).Aplicar(n => n + 10);
             ListaDeEnteros lista5 = ListaDeEnteros.Combinar(lista3, lista4, (x, y) => x + y);
             lista1.Imprimir();
             lista2.Imprimir();
             lista3.Imprimir();
             lista4.Imprimir();
             lista5.Imprimir();
             ListaDeEnteros.Combinar(lista5, lista3, (x, y) => x + 2 * y).Imprimir();
             Console.Read();
         }

         delegate bool FuncSelect(int i);
         delegate int FuncAplicar(int i);
         delegate int FuncCombinar(int i, int j);
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
        */

        static void Main(string[] args)
        {
            Trabajador t1 = new Trabajador();
            t1.Trabajando += (object sender, EventArgs e) => Console.WriteLine("Se inició el trabajo");
            t1.Trabajar();
        }
    }
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
}
