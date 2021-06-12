# Trabajo Práctico 9

## Ejercicio 01

~~~
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
~~~

## Ejercicio 02
La mecánica es la siguiente: Hay tres vectores que contienen valores del mismo tipo, el método Set() tiene tres parametros, el primer parametro es vector a modificar, el segundo parametro es el valor a insertar en la posición que indica el tercer parametro.
~~~
public static void Set<T>(T[] array, T value, int pos)
{
    array[pos] = value;
}
public static void Imprimir<T>(T[] value)
{
    Console.WriteLine($"{value[0]} {value[1]} {value[2]}");
}
~~~

## Ejercicio 03

~~~
public static T[] CrearArreglo<T>(params T[] lista){
    return lista;
}
public static T CrearObjetoDelMismoTipo<T>(T value) where T: new(){
    return new T();
}
~~~


## Ejercicio 04

~~~
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
~~~

## Ejercicio 05 

~~~
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
~~~

## Ejercicio 07

Defino la clase Persona con su constructor:
~~~
public class Persona<T1, T2>
{
    public T1 Nombre { get; set; }
    public T2 Edad { get; set; }
    public Persona(T1 nombre, T2 edad){
        Nombre = nombre;
        Edad = edad;
    }
}
~~~

Defino la clase Par como en la teoria:
~~~
 public class Par<T1, T2>
{
    public T1 A { get; private set; }
    public T2 B { get; private set; }
    public Par(T1 a, T2 b)
    {
        this.A = a;
        this.B = b;
    }
}
~~~

Para poder haver la converción necesitamos un metodo que reciba los elementos de la Lista y devuelva los nuevos elementos:
~~~
 public static Par<T1, T2> convertirPersonasAPares<T1, T2>(Persona<T1, T2> p)
{
    return new Par<T1, T2>(p.Nombre, p.Edad);
}
~~~

Ahora definimos una lista de prueba y la convertimos:
~~~
static void Main(string[] args)
{
    List<Persona<string, int>> personas = new List<Persona<string, int>>(){new Persona<string, int>("Juan", 29), new Persona<string, int>("Ana", 31)};
    List<Par<string, int>> personasPares = personas.ConvertAll<Par<string, int>>(convertirPersonasAPares<string, int>);
    personasPares.ForEach(par => Console.WriteLine($"Nombre: {par.A}, Edad: {par.B}"));
    Console.Read();
}
~~~

## Ejericio 08

~~~
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
~~~

## Ejercicio 09

~~~
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
~~~

## Ejercicio 10

En el archivo...