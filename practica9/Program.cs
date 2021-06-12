using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace practica9
{
    class Program
    {
        /*
        * ==================
        * Ejercicio       01
        * ==================

           static void Main(string[] args)
         {
             ArrayList lista = new ArrayList() { "hola", 7, 'A' };
             string st = Get<string>(lista, 0);
             int i = Get<int>(lista, 1);
             char c = Get<char>(lista, 2);
             Console.WriteLine($"{st} {i} {c}");
         }
         public static T Get<T>(ArrayList array, int value){
             return (T)array[value];
         }
        */

        /*
        * ==================
        * Ejercicio       02
        * ==================
        static void Main(string[] args)
        {
            int[] vector1 = new int[] { 1, 2, 3 };
            bool[] vector2 = new bool[] { true, true, true };
            string[] vector3 = new string[] { "uno", "dos", "tres" };
            Set<int>(vector1, 110, 2);
            Set<bool>(vector2, false, 1);
            Set<string>(vector3, "Hola Mundo!", 0);
            Imprimir(vector1);
            Imprimir(vector2);
            Imprimir(vector3);
            Console.Read();
        }

        public static void Set<T>(T[] array, T value, int pos)
        {
            array[pos] = value;
        }

        public static void Imprimir<T>(T[] value)
        {
            Console.WriteLine($"{value[0]} {value[1]} {value[2]}");
        }
          
        */
        /*
        * ==================
        * Ejercicio       03
        * ==================
        
          static void Main(string[] args)
        {
            string[] vector1 = CrearArreglo<string>("uno", "dos");
            foreach (string st in vector1) Console.Write(st + " - ");
            Console.WriteLine();
            double[] vector2 = CrearArreglo<double>(1, 2.3, 4.1, 6.7);
            foreach (double valor in vector2) Console.Write(valor + " - ");
            Console.WriteLine();
            ArrayList lista = new ArrayList();
            Stack pila = new Stack();
            var a = CrearObjetoDelMismoTipo(lista);
            var b = CrearObjetoDelMismoTipo(12);
            var c = CrearObjetoDelMismoTipo('A');
            var d = CrearObjetoDelMismoTipo(pila);
            Console.WriteLine(a.GetType());
            Console.WriteLine(b.GetType());
            Console.WriteLine(c.GetType());
            Console.WriteLine(d.GetType());
            Console.Read();
        }

        public static T[] CrearArreglo<T>(params T[] lista){
            return lista;
        }
        public static T CrearObjetoDelMismoTipo<T>(T value) where T: new(){
            return new T();
        }
        */

        /*
        * ==================
        * Ejercicio       04
        * ==================
        
          static void Main(string[] args)
        {
            ListaGenerica<int> lista = new ListaGenerica<int>();
            lista.AgregarAdelante(3);
            lista.AgregarAdelante(100);
            lista.AgregarAtras(10);
            lista.AgregarAtras(11);
            lista.AgregarAdelante(0);
            IEnumerator<int> enumerador = lista.GetEnumerator();
            while (enumerador.MoveNext())
            {
                int i = enumerador.Current;
                Console.Write(i + " ");
            }
            Console.Read();
        }

        class ListaGenerica<T>
        {
            private Nodo<T> _inicio = null;
            public void AgregarAdelante(T value)
            {
                if(_inicio == null){
                     _inicio = new Nodo<T>(value);
                     return;
                }
                else{
                    Nodo<T> nodoAuxiliar = _inicio;
                    _inicio = new Nodo<T>(value);
                    _inicio.Proximo = nodoAuxiliar;
                }
            }
            public void AgregarAtras(T value)
            {
                if(_inicio == null){
                     _inicio = new Nodo<T>(value);
                     return;
                }
                else{
                    Nodo<T> nodoAuxiliar = _inicio;
                    while(nodoAuxiliar.Proximo != null){
                        nodoAuxiliar = nodoAuxiliar.Proximo;
                    }
                    nodoAuxiliar.Proximo = new Nodo<T>(value);
                }
            }

            public IEnumerator<T> GetEnumerator(){
                Nodo<T> nodoAuxiliar = _inicio;
                List<T> lista = new List<T>();
                while(nodoAuxiliar.Proximo!=null){
                    lista.Add(nodoAuxiliar.Valor);
                    nodoAuxiliar = nodoAuxiliar.Proximo;
                }
                lista.Add(nodoAuxiliar.Valor);
                return lista.GetEnumerator();
            }

        }

        class Nodo<T>
        {
            public T Valor { get; private set; }
            public Nodo<T> Proximo { get; set; } = null;
            public Nodo(T valor) => Valor = valor;
        }
        */

        /*
        * ==================
        * Ejercicio       05
        * ==================
        
                  static void Main(string[] args)
        {
            Nodo<int> n = new Nodo<int>(7);
            n.Insertar(3);
            n.Insertar(1);
            n.Insertar(5);
            n.Insertar(12);
            foreach (int elem in n.InOrder)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Altura: {n.Altura}");
            Console.WriteLine($"Cantidad: {n.CantNodos}");
            Console.WriteLine($"Mínimo: {n.ValorMinimo}");
            Console.WriteLine($"Máximo: {n.ValorMaximo}");
            Nodo<string> n2 = new Nodo<string>("hola");
            n2.Insertar("Mundo");
            n2.Insertar("XYZ");
            n2.Insertar("ABC");
            foreach (string elem in n2.InOrder)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();
            Console.WriteLine($"Altura: {n2.Altura}");
            Console.WriteLine($"Cantidad: {n2.CantNodos}");
            Console.WriteLine($"Mínimo: {n2.ValorMinimo}");
            Console.WriteLine($"Máximo: {n2.ValorMaximo}");
            Console.Read();
        }

        class Nodo<T> where T : IComparable<T>
        {
            // Los valores mayores al nodo se guardan a la derecha, los menores, a la izquierda
            private T valor;
            private Nodo<T> hd = null;
            private Nodo<T> hi = null;

            public Nodo(T d)
            {
                valor = d;
            }
            public bool Insertar(T d)
            {
                if (d.CompareTo(valor) == 0)
                {
                    Console.WriteLine("El valor ingresado ya existe");
                    return false;
                }
                if (d.CompareTo(valor) > 0)
                {
                    if (hd != null)
                    {
                        return hd.Insertar(d);
                    }
                    hd = new Nodo<T>(d);
                    return true;
                }
                else
                {
                    if (hi != null)
                    {
                        return hi.Insertar(d);
                    }
                    hi = new Nodo<T>(d);
                    return true;
                }
            }
            public IEnumerable<T> InOrder
            {
                get
                {
                    List<T> lista = new List<T>();
                    GetInOrden(ref lista);
                    return lista;
                }
            }
            public void GetInOrden(ref List<T> lista)
            {
                if (hi != null) hi.GetInOrden(ref lista);
                lista.Add(valor);
                if (hd != null) hd.GetInOrden(ref lista);
            }
            public T ValorMinimo
            {
                get
                {
                    if (hi != null) return hi.ValorMinimo;
                    return valor;
                }
            }

            public T ValorMaximo
            {
                get
                {
                    if (hd != null) return hd.ValorMaximo;
                    return valor;
                }
            }

             public int Altura
            {
                get
                {
                    int x = 0;
                    GetAltura(ref x, 0);
                    return x;
                }
            }
            private void GetAltura(ref int n, int k)
            {
                if (n < k) n = k;
                if (hi != null) hi.GetAltura(ref n, k+1);
                if (hd != null) hd.GetAltura(ref n, k+1);
            }
            public int CantNodos
            {
                get
                {
                    int x = 0;
                    GetNodos(ref x);
                    return x;
                }
            }
            private void GetNodos(ref int n)
            {
                if (hi != null) hi.GetNodos(ref n);
                n++;
                if (hd != null) hd.GetNodos(ref n);
            }

        }
        */
        /*
        * ==================
        * Ejercicio       08
        * ==================
        
          static void Main(string[] args)
        {
            Console.WriteLine("Ingrese nombre del archivo");
            String archivo;
            archivo = Console.ReadLine();

            // Creo el lector de archivos
            StreamReader sw = null;
            try
            {
                //Leo el archivo
                sw = new StreamReader(archivo);
                //Genero el diccionario ordenado donde guaradar las palabras y sus ocurrencias (entero alojado como elemento de la llave palabra)
                SortedDictionary<string, int> Diccionario = new SortedDictionary<string, int>();
                //Leo mientras haya información
                while ((archivo = sw.ReadLine()) != null)
                {
                    //Divido el texto en palabras, usando como divisor el espacio
                    string[] arrayPalabras = archivo.Split(' ');
                    foreach (string palabra in arrayPalabras)
                    {
                        if (palabra != "")
                        {
                            //Si la palabra no está, la agrego con una aparicion, sino le sumo un valor
                            if (!Diccionario.ContainsKey(palabra))
                            {
                                Diccionario.Add(palabra, 1);
                            }
                            else
                            {
                                Diccionario[palabra]++;
                            }
                        }
                    }
                }
                //Imprimo las palabras junto con el valor de apariciones
                foreach (KeyValuePair<string, int> palabra in Diccionario)
                {
                    Console.WriteLine($"{palabra.Key} : {palabra.Value}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                //Cierro el archivo
                if (sw != null)
                {
                    sw.Dispose();
                }
            }
            Console.ReadLine();
        }
        */

        /*
        * ==================
        * Ejercicio       09
        * ==================
        
          static void Main(string[] args)
        {
            //SOlicito los nombres de los archivos a cotejar
            Console.WriteLine("Ingrese nombre del archivo 1:");
            String archivo1;
            archivo1 = Console.ReadLine();
            Console.WriteLine("Ingrese nombre del archivo 2:");
            String archivo2;
            archivo2 = Console.ReadLine();

            // Creo los lectores de archivos
            StreamReader sw1 = null;
            StreamReader sw2 = null;
            try
            {
                //Leo los archivos
                sw1 = new StreamReader(archivo1);
                sw2 = new StreamReader(archivo2);
                
                //Obtengo las listas ordenadas
                List<string> lista1 = listaOrdenada(sw1);
                List<string> lista2 = listaOrdenada(sw2);

                //Me retorna la intersección de las listas
                IEnumerable<string> listaCruzada = lista1.Intersect(lista2);

                //Las imprimo
                foreach (string palabra in listaCruzada)
                {
                    Console.Write($"{palabra} - ");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                //Cierro archivos
                if (sw1 != null) sw1.Dispose();
                if (sw2 != null) sw2.Dispose();

            }
            Console.ReadLine();
        }

        public static List<string> listaOrdenada(StreamReader sw)
        {
            List<string> lista = new List<string>();
            string archivo;
            while ((archivo = sw.ReadLine()) != null)
            {
                //Divido el texto en palabras, usando como divisor el espacio
                string[] arrayPalabras = archivo.Split(' ');
                foreach (string palabra in arrayPalabras)
                {
                    lista.Add(palabra);
                }
            }
            lista.Sort();
            return lista;
        }
        */
        static void Main(string[] args)
        {
            //SOlicito los nombres de los archivos a cotejar
            Console.WriteLine("Ingrese nombre del archivo 1:");
            String archivo1;
            archivo1 = Console.ReadLine();
            Console.WriteLine("Ingrese nombre del archivo 2:");
            String archivo2;
            archivo2 = Console.ReadLine();
            // String archivo1 = "texto.txt";
            // String archivo2 = "texto1.txt";

            StreamReader sw1 = null;
            StreamReader sw2 = null;
            try
            {
                //Leo los archivos
                sw1 = new StreamReader(archivo1);
                sw2 = new StreamReader(archivo2);

                //Obtengo las listas ordenadas
                List<string> lista1 = listaOrdenada(sw1);
                List<string> lista2 = listaOrdenada(sw2);

                //Me retorna la intersección de las listas
                IEnumerable<string> listaCruzada = lista1.Intersect(lista2);
                List<string> listaCruzadaL = listaCruzada.ToList();

                List<ListaConPosiciones> listaConPosiciones = contarPosicones(listaCruzadaL, archivo1, archivo2);

                foreach (ListaConPosiciones item in listaConPosiciones)
                {
                    Console.WriteLine($"Palabra: \"{item.Palabra}\"");
                    Console.Write("|--Posiciones en Texto1:-->");
                    foreach (int pos in item.getPosArch(1))
                    {
                        Console.Write($" {pos} ");
                    }
                    Console.WriteLine("");
                    Console.Write("|--Posiciones en Texto2:-->");
                    foreach (int pos in item.getPosArch(2))
                    {
                        Console.Write($" {pos} ");
                    }
                    Console.WriteLine("");
                    Console.WriteLine("");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                //Cierro archivos
                if (sw1 != null) sw1.Dispose();
                if (sw2 != null) sw2.Dispose();

            }
            Console.ReadLine();
        }

        public class ListaConPosiciones
        {
            private List<int> PosArch1 = new List<int>();
            private List<int> PosArch2 = new List<int>();

            public string Palabra;

            public void addArch(int i, int dato)
            {
                if (i == 1)
                {
                    PosArch1.Add(dato);
                }
                else
                {
                    PosArch2.Add(dato);
                }
            }

            public List<int> getPosArch(int i)
            {
                if (i == 1)
                {
                    return PosArch1;
                }
                else
                {
                    return PosArch2;
                }
            }
        }

        public static List<ListaConPosiciones> contarPosicones(List<string> lista, string archivo1, string archivo2)
        {

            List<ListaConPosiciones> listaConPosiciones = new List<ListaConPosiciones>();
            string archivo;
            foreach (string palabraLista in lista)
            {
                StreamReader sw1 = new StreamReader(archivo1);
                StreamReader sw2 = new StreamReader(archivo2);
                ListaConPosiciones palabra = new ListaConPosiciones();
                palabra.Palabra = palabraLista;

                int largo = 0;
                while ((archivo = sw1.ReadLine()) != null)
                {
                    int largoSub = 0;
                    int largoInterno = archivo.Length;
                    while (archivo.IndexOf(palabraLista) != -1 && archivo.IndexOf(palabraLista) != 0)
                    {
                        palabra.addArch(1, archivo.IndexOf(palabraLista) + largo + largoSub);
                        archivo = archivo.Substring(archivo.IndexOf(palabraLista) + palabraLista.Length);
                        largoSub = largoInterno - archivo.Length;
                    }
                    largo += largoInterno;
                }

                largo = 0;
                while ((archivo = sw2.ReadLine()) != null)
                {
                    int largoSub = 0;
                    int largoInterno = archivo.Length;
                    while (archivo.IndexOf(palabraLista) != -1 && archivo.IndexOf(palabraLista) != 0)
                    {
                        palabra.addArch(2, archivo.IndexOf(palabraLista) + largo + largoSub);
                        archivo = archivo.Substring(archivo.IndexOf(palabraLista) + palabraLista.Length);
                        largoSub = largoInterno - archivo.Length;
                    }
                    largo += largoInterno;
                }
                listaConPosiciones.Add(palabra);
            }
            return listaConPosiciones;
        }

        public static List<string> listaOrdenada(StreamReader sw)
        {
            List<string> lista = new List<string>();
            string archivo;
            while ((archivo = sw.ReadLine()) != null)
            {
                //Divido el texto en palabras, usando como divisor el espacio
                string[] arrayPalabras = archivo.Split(' ');
                foreach (string palabra in arrayPalabras)
                {
                    lista.Add(palabra);
                }
            }
            lista.Sort();
            return lista;
        }
    }
}
