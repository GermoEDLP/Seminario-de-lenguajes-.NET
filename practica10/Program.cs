using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace practica10
{
    class Program
    {
        /*
        * ==================
        * Ejercicio       01
        * ==================
        
          private delegate void Imprimidor();
        static void Main(string[] args)
        {
            // Task tarea = new Task(Saludar);
            // tarea.Start();
            // tarea.Wait();

            // Task tarea = Task.Run(Saludar);
            // tarea.Wait();

            // Task tarea = Task.Run(()=>Console.WriteLine("Hola Mundo!"));
            // tarea.Wait();

            Imprimidor saludo = new Imprimidor(Saludar);
            Task tarea = Task.Run(()=>saludo());
            tarea.Wait();
            Console.Read();
        }
        static void Saludar()
        {
            Console.WriteLine("Hola mundo!");
        }
        */

        /*
        * ==================
        * Ejercicio       02
        * ==================
        
          static void Main(string[] args)
        {
            Task[] tareas = new Task[100];
            for (int i = 0; i < 100; i++)
            {
                tareas[i] = Task.Run(Imprimir);
            }
            Task.WaitAll(tareas);
            Console.Read();
        }
        static void Imprimir()
        {
            int idTrhead = System.Threading.Thread.CurrentThread.ManagedThreadId;
            int? idTarea = Task.CurrentId;
            Console.WriteLine($"Tarea: {idTarea} Thread: {idTrhead}");
        }
        */

        /*
        * ==================
        * Ejercicio       03
        * ==================

           static void Main(string[] args)
         {
             DateTime inicio = DateTime.Now;
             Task t1 = Task.Run(Procesar);
             Task t2 = Task.Run(Procesar);
             Task t3 = Task.Run(Procesar);
             Task t4 = Task.Run(Procesar);
             Task.WaitAll(t1, t2, t3, t4);

             // Procesar();
             // Procesar();
             // Procesar();
             // Procesar();
             double mlseg = (DateTime.Now - inicio).TotalMilliseconds;
             Console.Write($"\n Tiempo transcurrido: {mlseg} \n");
             Console.Read();
         }

         static void Procesar()
         {
             for (int i = 0; i < 100_000_000; i++)
             {
                 string st = i.ToString();
             }
             Console.WriteLine("Fin del procesamiento");
         }
        */

        /*
        * ==================
        * Ejercicio       04
        * ==================
        
          static void Main(string[] args)
        {
            Task[] tareas = new Task[1000];
            for (int i = 0; i < 1000; i++)
            {
                tareas[i] = new Task((o) => Imprimir(o), i);
                tareas[i].Start();
            }
            Task.WaitAll(tareas);
            Console.Read();
        }
        static void Imprimir(object o)
        {
            Console.Write($"{o} - ");
        }
        */

        /*
        * ==================
        * Ejercicio       05
        * ==================
        
             static void Main(string[] args)
        {
            Task[] tareas = new Task[1000];
            for (int i = 0; i < 1000; i++)
            {
                tareas[i] = Task.Factory.StartNew(Imprimir, i);
            }
            Task.WaitAll(tareas);
            Console.Read();
        }

        static void Imprimir(object o)
        {
            Console.Write($"{o} - ");
        }
        */

        /*
        * ==================
        * Ejercicio       06
        * ==================
        
           static void Main(string[] args)
        {
            Task[] tareas = new Task[1000];
            for (int i = 0; i < 1000; i++)
            {
                tareas[i] = new Task((o) => {Console.Write($"{o} - ");}, i);
                tareas[i].Start();
            }
            Task.WaitAll(tareas);
            Console.Read();
        }
        */

        /*
        * ==================
        * Ejercicio       07
        * ==================

           static void Main(string[] args)
         {
             List<Task> tareas = new List<Task>();
             for (int n = 1; n <= 10; n++)
             {
                 tareas.Add(Task.Factory.StartNew((o)=>Sumatoria((int)o), n));
             }
             Task.WaitAll(tareas.ToArray());
             Console.Read();
         }

         static void Sumatoria(int n)
         {
             int total = 0;
             for (int i = 1; i <= n; i++)
             {
                 total += i;
             }
             Console.WriteLine($"La sumatoria de 1 a {n} es: {total}");
         }
        */

        /*
        * ==================
        * Ejercicio       08
        * ==================

          static void Main(string[] args)
         {
             List<Task> tareas = new List<Task>();
             for (int a = 1; a <= 3; a++)
             {
                 for (int b = a + 2; b <= a + 4; b++)
                 {
                     int[] parametros = {a,b};
                     tareas.Add(Task.Factory.StartNew((p)=>Sumatoria((int[])p), parametros));
                 }
             }
             Task.WaitAll(tareas.ToArray());
             Console.Read();
         }

         static void Sumatoria(int[] p)
          {
              int total = 0;
              for (int i = p[0]; i <= p[1]; i++)
              {
                  total += i;
              }
              Console.WriteLine($"La sumatoria de {p[0]} a {p[1]} es: {total}");
          } 
        */

        /*
        * ==================
        * Ejercicio       09
        * ==================
        
          static void Main(string[] args)
        {
            List<Task<int>> tareas = new List<Task<int>>();
            for (int n = 1; n <= 10; n++)
            {
                // tareas.Add(new Task<int>((o)=>Sumatoria((int)o), n));
                // tareas[n-1].Start();
                
                tareas.Add(Task<int>.Factory.StartNew((o)=>Sumatoria((int)o), n));
            }
            // Imprimir el resultado devuelto por cada tarea
            Task.WaitAll(tareas.ToArray());
            foreach (var tarea in tareas)
            {
                Console.WriteLine(tarea.Result);
            }
            Console.Read();
        }

        static int Sumatoria(int n)
        {
            int suma = 0;
            for (int i = 1; i <= n; i++)
            {
                suma += i;
            }
            return suma;
        }
        */
        /*
        * ==================
        * Ejercicio       10
        * ==================
        
         private static readonly object control = new object();
        static string leyenda = "Valores procesados: ";
        public static void Main()
        {
            List<Task> tareas = new List<Task>();
            for (int n = 1; n <= 10; n++)
            {
                Task t = new Task((o) => Procesar(o), n);
                tareas.Add(t);
                t.Start();
            }
            Task.WaitAll(tareas.ToArray());
            Console.WriteLine(leyenda);
            Console.Read();
        }
        static void Procesar(object obj)
        {
            // hace algún trabajo y accede a una variable compartida;
            lock(control){
                leyenda += obj + " ";
            }
        } 
        */

        /*
        * ==================
        * Ejercicio       11
        * ==================
        
          static void Main(string[] args)
        {
            List<Task> tareas = new List<Task>();
            for (int a = 1; a <= 3; a++)
            {
                for (int b = a + 2; b <= a + 4; b++)
                {
                    tareas.Add(SumatoriaAsync(a, b));
                }
            }
            Task.WaitAll(tareas.ToArray());
            Console.Read();
        }

        static async Task SumatoriaAsync(int a, int b)
        {
            int[] parametros = { a, b };
            Task tarea = new Task((p) =>
            {
                int[] pArray = (int[])p;
                int total = 0;
                for (int i = pArray[0]; i <= pArray[1]; i++)
                {
                    total += i;
                }
                Console.WriteLine($"La sumatoria de {pArray[0]} a {pArray[1]} es: {total}");
            }, parametros);
            tarea.Start();
            await tarea;
        }
        */

        /*
        * ==================
        * Ejercicio       12
        * ==================
        
          static void Main(string[] args)
        {
            List<Task<int>> tareas = new List<Task<int>>();
            for (int n = 1; n <= 10; n++)
            {
                // tareas.Add(new Task<int>((o)=>Sumatoria((int)o), n));
                // tareas[n-1].Start();

                tareas.Add(SumatoriaAsync(n));
            }
            // Imprimir el resultado devuelto por cada tarea
            Task.WaitAll(tareas.ToArray());
            foreach (var tarea in tareas)
            {
                Console.WriteLine(tarea.Result);
            }
            Console.Read();
        }

        static async Task<int> SumatoriaAsync(int n)
        {
            int suma = 0;
            Task tarea = new Task((o) =>
            {
                int oInt = (int)o;
                for (int i = 1; i <= oInt; i++)
                {
                    suma += i;
                }
            }, n);
            tarea.Start();
            await tarea;
            return suma;
        }
        */

        /*
        * ==================
        * Ejercicio       13
        * ==================
        
          static void Main(string[] args)
        {
            //Solicito el nombre del archivo
            Console.WriteLine("Ingrese nombre del archivo:");
            String archivo = Console.ReadLine();
            try
            {
                // Iniciar la tarea asincrona
                Task<string> tarea = LeerArchivoAsync(archivo);
                Console.WriteLine("Leyendo archivo...");
                //Esperar por la tarea
                tarea.Wait();
                Console.WriteLine("Archivo leido:");
                // Imprimir el resultado
                Console.WriteLine(tarea.Result);
                Console.Read();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        private static async Task<string> LeerArchivoAsync(string archivo)
        {
            // Creo el lector de archivo
            StreamReader sr = null;
            // Creo una cadena vacía para almacenar lo leido
            string texto = "";
            try
            {
                Task tarea = new Task(() =>
                {
                    // Leo el archivo por lineas y las concateno la variable texto
                    sr = new StreamReader(archivo);
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        texto += linea + " ";
                    }
                });
                // Inicializo la tarea y le cedo el control al padre
                tarea.Start();
                await tarea;
                // Retorno el texto leido
                return texto;

            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                if (sr != null) sr.Dispose();
            }
        }
        */

        /*
        * ==================
        * Ejercicio       14
        * ==================
        
          static void Main(string[] args)
        {
            //Solicito el nombre del archivo
            Console.WriteLine("Ingrese nombre del archivo:");
            String archivo = Console.ReadLine();
            try
            {
                // Iniciar la tarea asincrona
                Task<int> tarea = LeerArchivoYContarPalabrasAsync(archivo);
                Console.WriteLine("Leyendo archivo...");
                //Esperar por la tarea
                tarea.Wait();
                Console.WriteLine("Archivo leido:");
                // Imprimir el resultado
                Console.WriteLine($"Cantidad de palabras: {tarea.Result}");
                Console.Read();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        private static async Task<int> LeerArchivoYContarPalabrasAsync(string archivo)
        {
            // Creo el lector de archivo
            StreamReader sr = null;
            // Creo una cadena vacía para almacenar lo leido
            int palabras = 0;
            try
            {
                Task tarea = new Task(() =>
                {
                    // Leo el archivo por lineas, separo
                    sr = new StreamReader(archivo);
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        // Separo la liena en palabras y las cuento
                        string[] palabrasArray = linea.Split(" ");
                        palabras+=palabrasArray.Length;
                    }
                });
                // Inicializo la tarea y le cedo el control al padre
                tarea.Start();
                await tarea;
                // Retorno la cantidad de palabras contadas
                return palabras;

            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                if (sr != null) sr.Dispose();
            }
        }
        */

        /*
        * ==================
        * Ejercicio       15
        * ==================
        
          static void Main(string[] args)
        {
            //Solicito el nombre del archivo
            List<string> archivos = new List<string>();
            Console.WriteLine("Ingrese, de a uno, el nombre de los archivos ('fin' termina):");
            String archivo = Console.ReadLine();
            while (archivo != "fin")
            {
                archivos.Add(archivo);
                Console.WriteLine("Ingrese, de a uno, el nombre de los archivos ('fin' termina):");
                archivo = Console.ReadLine();
            }
            if (archivos.Count != 0)
            {
                try
                {
                    // Iniciar la tarea asincrona
                    Task<int[]> tarea = LeerArchivoYContarPalabrasDeVariosArchivosAsync(archivos);
                    Console.WriteLine("Leyendo archivos...");
                    //Esperar por la tarea
                    tarea.Wait();
                    Console.WriteLine("Archivos leidos:");
                    // Imprimir el resultado
                    foreach (var item in tarea.Result)
                    {
                        Console.WriteLine($"Cantidad de palabras: {item}");
                    }
                    Console.Read();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
            else
            {
                Console.WriteLine("No se ingreso ningún archivo...");
            }
            Console.Read();

        }

        private static async Task<int[]> LeerArchivoYContarPalabrasDeVariosArchivosAsync(List<string> archivos)
        {
            List<Task<int>> tareas = new List<Task<int>>();
            List<int> palabras = new List<int>();
            try
            {
                foreach (var archivo in archivos)
                {
                    tareas.Add(LeerArchivoYContarPalabrasAsync(archivo));
                }
                await Task.WhenAll(tareas.ToArray());
                foreach (var tarea in tareas)
                {
                    palabras.Add(tarea.Result);
                }
                return palabras.ToArray();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private static async Task<int> LeerArchivoYContarPalabrasAsync(string archivo)
        {
            // Creo el lector de archivo
            StreamReader sr = null;
            // Creo una cadena vacía para almacenar lo leido
            int palabras = 0;
            try
            {
                Task tarea = new Task(() =>
                {
                    // Leo el archivo por lineas, separo
                    sr = new StreamReader(archivo);
                    string linea;
                    while ((linea = sr.ReadLine()) != null)
                    {
                        // Separo la liena en palabras y las cuento
                        string[] palabrasArray = linea.Split(" ");
                        palabras += palabrasArray.Length;
                    }
                });
                // Inicializo la tarea y le cedo el control al padre
                tarea.Start();
                await tarea;
                // Retorno la cantidad de palabras contadas
                return palabras;

            }
            catch (System.Exception)
            {
                throw;
            }
            finally
            {
                if (sr != null) sr.Dispose();
            }
        }
        */
    }
}
