using System;
using System.IO;

namespace practica4
{
    class Program
    {
        /*
        EJERCICIO 01
        ============
        
        static void Main(string[] args)
        {
            StreamReader sr = new System.IO.StreamReader("data/dataEj1.txt");
            Persona p = new Persona();
            string line;
            int cont = 1;
            Console.WriteLine("{0}) {1,-8} {2,5} {3,10}", "Nro", "Nombre", "Edad", "DNI");
            while ((line = sr.ReadLine()) != null)
            {
                string[] terminos = line.Split(",");
                p.Nombre = terminos[0];
                p.Edad = Int32.Parse(terminos[1]);
                p.DNI = terminos[2];
                Console.WriteLine("{0}) {1,-8} {2,5} {3,15}", cont, p.Nombre, p.Edad, p.DNI);
                cont++;
            }
        }

        class Persona
        {
            public string Nombre;
            public int Edad;
            public string DNI;
        }
        */

        /*
        EJERCICIO 02
        ============
        
         static void Main(string[] args)
        {
            StreamReader sr = new System.IO.StreamReader("data/dataEj1.txt");
            string line;
            int cont = 1;
            while ((line = sr.ReadLine()) != null)
            {
                string[] terminos = line.Split(",");
                Persona p = new Persona(terminos[0], Int32.Parse(terminos[1]), terminos[2]);
                p.imprimir(cont);
                cont++;
            }
        }

        class Persona
        {
            public string Nombre;
            public int Edad;
            public string DNI;

            public Persona(string Nombre, int Edad, string DNI){
                this.Nombre = Nombre;
                this.Edad = Edad;
                this.DNI = DNI;
            }

            public void imprimir(int pos)
            {
                Console.WriteLine("{0}) {1,-8} {2,5} {3,10}", pos, Nombre, Edad, DNI);
            }
        }
        */
        /*
        EJERCICIO 03
        ============

        static void Main(string[] args)
       {
           StreamReader sr = new System.IO.StreamReader("data/dataEj1.txt");
           string line;
           int cont = 1;
           // Definir una persona con una edad muy alta para poder comparar
           Persona joven = new Persona("", 999, "");
           while ((line = sr.ReadLine()) != null)
           {
               string[] terminos = line.Split(",");
               Persona p = new Persona(terminos[0], Int32.Parse(terminos[1]), terminos[2]);
               // Comparo que la persona que esta en joven, sea mayor que la que se ingreso.
               if(joven.EsMayorQue(p)) joven = p;
               cont++;
           }
           Console.WriteLine("La persona mas joven de la lista es: ");
           joven.imprimir();
       }

       class Persona
       {
           private string Nombre;
           private int Edad;
           private string DNI;

           public Persona(string Nombre, int Edad, string DNI){
               this.Nombre = Nombre;
               this.Edad = Edad;
               this.DNI = DNI;
           }

           public void imprimir()
           {
               Console.WriteLine("{0,-8} {1,5} {2,10}", Nombre, Edad, DNI);
           }

           public bool EsMayorQue(Persona p){
               return this.Edad>p.Edad;
           }
       }
        */

        /*
        EJERCICIO 04
        ============
        
        static void Main(string[] args)
        {
            Hora h = new Hora(23, 30, 15);
            h.imprimir();
        }

        class Hora
        {
            private int horas;
            private int minutos;
            private int segundos;

            public Hora(int horas, int minutos, int segundos)
            {
                this.horas = horas;
                this.minutos = minutos;
                this.segundos = segundos;
            }

            public void imprimir(){
                Console.WriteLine("{0} horas, {1} minutos y {2} segundos", horas, minutos, segundos);
            }
        }
        */

        /*
        EJERCICIO 05
        ============
        
        static void Main(string[] args)
        {
            new Hora(23, 30, 15).imprimir();
            new Hora(14.43).imprimir();
            new Hora(14.45).imprimir();
            new Hora(14.45114).imprimir();
        }

        class Hora
        {
            private int horas;
            private int minutos;
            private int segundos;
            private double segundosD;

            public Hora(int horas, int minutos, int segundos)
            {
                this.horas = horas;
                this.minutos = minutos;
                this.segundos = segundos;
            }

            public Hora(double hora)
            {
                // Al castear obtengo la parte entera del double
                this.horas = (int)hora;
                // Si le resto la parte entera al double, tengo los decimales, luego estos 
                // multiplicados por 60 me dan los minutos que representan.
                // Otra vez casteando, obtengo la parte entera
                this.minutos = (int)((hora - this.horas) * 60);
                // Mismo procedimiento que con los minutos. Creo una nueva variable tipo double
                // Para poder guardar el numero resultante con decimales incluidos
                this.segundosD = ((((hora - this.horas) * 60) - this.minutos) * 60);

                // Cuando los segundos deberían llegar a 60, ocurre que el numero es en veradad
                // 59,9999999999999277, entonces aparece como que hay 60 segundos pero no suma 
                // un nuevo minuto, entonces este condicional corrige ese pequeño problema.
                if (Math.Round(this.segundosD) == 60)
                {
                    this.minutos++;
                    this.segundosD = 0;
                }
            }

            public void imprimir()
            {
                if (segundos != 0)
                {
                    Console.WriteLine("{0} horas, {1} minutos y {2} segundos", horas, minutos, segundos);
                }
                else
                {
                    Console.WriteLine("{0} horas, {1} minutos y {2:0.000} segundos", horas, minutos, segundosD);
                }
            }
        }
        */

        /*
        EJERCICIO 06
        ============
        
        static void Main(string[] args)
        {
            Ecuacion2[] e = { new Ecuacion2(1, -2, -3), new Ecuacion2(1, -12, 36), new Ecuacion2(1, -6, 25) };
            for (int i = 0; i < e.Length; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Discrimiante: {0}", e[i].GetDiscriminante());
                Console.WriteLine("Cant. de raices: {0}", e[i].GetCantidadDeRaices());
                e[i].ImprimirRaices();
            }
        }

        class Ecuacion2
        {
            private double a;
            private double b;
            private double c;

            public Ecuacion2(double a, double b, double c)
            {
                this.a = a;
                this.b = b;
                this.c = c;
            }

            public double GetDiscriminante()
            {
                return ((Math.Pow(this.b, 2)) - (4 * this.a * this.c));
            }

            public int GetCantidadDeRaices()
            {
                return GetDiscriminante() > 0 ? 2 : GetDiscriminante() == 0 ? 1 : 0;
            }

            public void ImprimirRaices()
            {
                if (GetCantidadDeRaices() == 2)
                {
                    double r1 = (-this.b + Math.Sqrt(GetDiscriminante())) / (2 * this.a);
                    double r2 = (-this.b - Math.Sqrt(GetDiscriminante())) / (2 * this.a);
                    Console.WriteLine("Raices: {0} y {1}", r1, r2);
                }
                else if (GetCantidadDeRaices() == 1)
                {
                    double r = (-this.b) / (2 * this.a);
                    Console.WriteLine("Raiz: {0}", r);
                }
                else
                {
                    Console.WriteLine("La funcón no tiene raices");
                }
            }

            public void ImprimirEcuacion()
            {
                Console.WriteLine("{0}X^2+({2})X+({3})", a, b, c);
            }


        }
        */

        /*
        EJERCICIO 07
        ============
        
        static void Main(string[] args)
        {
            Nodo n = new Nodo(7);
            n.Insertar(8);
            n.Insertar(10);
            n.Insertar(3);
            n.Insertar(1);
            n.Insertar(5);
            n.Insertar(14);
            foreach (int i in n.GetInOrder())
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.WriteLine(n.GetAltura());
            Console.WriteLine(n.GetCantNodos());
            Console.WriteLine(n.GetValorMaximo());
            Console.WriteLine(n.GetValorMinimo());
        }

        class Nodo
        {
            // Los valores mayores al nodo se guardan a la derecha, los menores, a la izquierda
            Elemento raiz = null;
            int tam = 0;
            int altura = 0;

            public Nodo(int d)
            {
                Insertar(d);
            }
            public void Insertar(int d)
            {
                int nivel = 0;
                Elemento n = new Elemento(d);
                if (raiz == null)
                {
                    raiz = n;
                    tam++;
                    altura = 0;
                }
                else
                {
                    Elemento anterior = null, actual;
                    actual = raiz;
                    while (actual != null)
                    {
                        anterior = actual;
                        if (d < actual.Dato)
                        {
                            actual = actual.Izq;
                            nivel++;
                        }
                        else if (d > actual.Dato)
                        {
                            actual = actual.Der;
                            nivel++;
                        }
                        else
                        {
                            Console.WriteLine("{0} es un dato reetido", d);
                            return;
                        }
                    }
                    if (d < anterior.Dato)
                    {
                        anterior.Izq = n;
                        tam++;
                    }
                    else
                    {
                        anterior.Der = n;
                        tam++;
                    }
                }
                if (nivel > altura)
                    altura = nivel;
            }
            public void GetInOrder(Elemento n, ref int[] array, ref int i)
            {
                if (n != null)
                {
                    GetInOrder(n.Izq, ref array, ref i);
                    array[i] = n.Dato;
                    i++;
                    GetInOrder(n.Der, ref array, ref i);
                }
            }
            public int[] GetInOrder()
            {
                int i = 0;
                int[] array = new int[tam];
                GetInOrder(raiz, ref array, ref i);
                return array;
            }
            public int GetValorMinimo()
            {
                if (raiz == null)
                    return 0;
                Elemento trabajo = raiz;
                int minimo = trabajo.Dato;
                while (trabajo.Izq != null)
                {
                    trabajo = trabajo.Izq;
                    minimo = trabajo.Dato;
                }
                return minimo;
            }
            public int GetValorMaximo()
            {
                if (raiz == null)
                    return 0;
                Elemento trabajo = raiz;
                int maximo = trabajo.Dato;
                while (trabajo.Der != null)
                {
                    trabajo = trabajo.Der;
                    maximo = trabajo.Dato;
                }
                return maximo;
            }
            public int GetAltura()
            {
                return altura;
            }
            public int GetCantNodos()
            {
                return tam;
            }

        }
        class Elemento
        {
            private int dato;
            private Elemento izq;
            private Elemento der;

            public Elemento(int d)
            {
                dato = d;
                izq = der = null;
            }

            // Defino getters y setters
            public int Dato { get => dato; set => dato = value; }
            internal Elemento Izq { get => izq; set => izq = value; }
            internal Elemento Der { get => der; set => der = value; }
        }
        */

        /*
        EJERCICIO 08
        ============
        
        static void Main(string[] args)
        {
            Matriz A = new Matriz(2, 3);
            for (int i = 0; i < 6; i++) A.SetElemento(i / 3, i % 3, (i + 1) / 3.0);
            Console.WriteLine("Impresión de la matriz A");
            A.Imprimir("0.000");
            double[,] aux = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 1, 2, 3 } };
            Matriz B = new Matriz(aux);
            Console.WriteLine("\nImpresión de la matriz B");
            B.Imprimir();
            Console.WriteLine("\nAcceso al elemento B[1,2]={0}", B.GetElemento(1, 2));
            Console.Write("\nfila 1 de A: ");
            foreach (double d in A.GetFila(1)) Console.Write("{0:0.0} ", d);
            Console.Write("\n\nColumna 0 de B: ");
            foreach (double d in B.GetColumna(0)) Console.Write("{0} ", d);
            Console.Write("\n\nDiagonal principal de B: ");
            try { foreach (double d in B.GetDiagonalPrincipal()) Console.Write("{0} ", d); } catch (Exception e) { Console.WriteLine(e.Message); }
            Console.Write("\n\nDiagonal secundaria de B: ");
            try { foreach (double d in B.GetDiagonalSecundaria()) Console.Write("{0} ", d); } catch (Exception e) { Console.WriteLine(e.Message); }
            Console.WriteLine();
            try
            {
                A.MultiplicarPor(B);
                Console.WriteLine("\n\nA multiplicado por B");
                A.Imprimir();
            }
            catch (Exception e) { Console.WriteLine(e.Message); }

        }

        class Matriz
        {
            private double[,] matriz;

            public Matriz(int fila, int col)
            {
                matriz = new double[fila, col];
            }
            public Matriz(double[,] matriz)
            {
                this.matriz = matriz;
            }
            public void SetElemento(int fila, int columna, double elemento)
            {
                matriz[fila, columna] = elemento;
            }
            public double GetElemento(int fila, int columna)
            {
                return matriz[fila, columna];
            }
            public void Imprimir()
            {
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        Console.Write("{0,-7}", matriz[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            public void Imprimir(string formatString)
            {
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        Console.Write("{0,-7}", matriz[i, j].ToString(formatString));
                    }
                    Console.WriteLine();
                }
            }
            public double[] GetFila(int fila)
            {
                double[] f = new double[matriz.GetLength(1)];
                for (int i = 0; i < matriz.GetLength(1); i++)
                {
                    f[i] = GetElemento(fila, i);
                }
                return f;
            }
            public double[] GetColumna(int columna)
            {
                double[] c = new double[matriz.GetLength(0)];
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    c[i] = GetElemento(i, columna);
                }
                return c;
            }
            public double[] GetDiagonalPrincipal()
            {
                checkSquare(matriz);
                double[] diag = new double[matriz.GetLength(0)];
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    diag[i] = matriz[i, i];
                }
                return diag;
            }
            public double[] GetDiagonalSecundaria()
            {
                checkSquare(matriz);
                int dimension = matriz.GetLength(0);
                double[] diag = new double[dimension];
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    diag[i] = matriz[i, dimension - i - 1];
                }
                return diag;

            }
            public double[][] GetArregloDeArreglo()
            {
                double[][] newMat = new double[matriz.GetLength(1)][];
                for (int i = 0; i < matriz.GetLength(0); i++)
                {
                    newMat[i] = new double[matriz.GetLength(0)];
                    for (int j = 0; j < matriz.GetLength(1); j++)
                    {
                        newMat[i][j] = matriz[i, j];
                    }
                }
                return newMat;
            }
            public void Sumarle(Matriz m)
            {
                try
                {
                    calcular(m, true);
                }
                catch
                {
                    throw;
                }
            }
            public void Restarle(Matriz m)
            {
                try
                {
                    calcular(m, false);
                }
                catch
                {
                    throw;
                }
            }

            private double[,] calcular(Matriz m, bool suma)
            {
                if (checkearTamaños(m.matriz))
                {
                    double[,] operacion = new double[matriz.GetLength(0), matriz.GetLength(1)];
                    for (int i = 0; i < matriz.GetLength(0); i++)
                    {
                        for (int j = 0; j < matriz.GetLength(1); j++)
                        {
                            operacion[i, j] = suma ? matriz[i, j] + m.matriz[i, j] : matriz[i, j] - m.matriz[i, j];
                        }
                    }
                    return operacion;
                }
                throw new Exception("Las matrices deben tener las mismas");
            }
            public void MultiplicarPor(Matriz m)
            {
                try
                {
                    checkearTamañosMultiplicacion(m);
                    double[,] matrizMult = new double[matriz.GetLength(0), m.matriz.GetLength(1)];
                    int c1 = matriz.GetLength(1), f1 = matriz.GetLength(0);
                    int c2 = m.matriz.GetLength(1), f2 = matriz.GetLength(0);

                    for (int i = 0; i < f1; i++)
                    {
                        for (int j = 0; j < c2; j++)
                        {
                            matrizMult[i, j] = 0;
                            for (int z = 0; z < c1; z++)
                            {
                                matrizMult[i, j] = matriz[i, z] * m.matriz[z, j] + matrizMult[i, j];
                            }
                        }
                    }
                    matriz = matrizMult;
                }
                catch
                {
                    throw;
                }

            }

            static void checkSquare(double[,] matriz)
            {
                if (matriz.GetLength(0) != matriz.GetLength(1))
                {
                    throw new ArgumentException("La matriz no es cuadrada");
                }
                return;
            }

            private bool checkearTamaños(double[,] m)
            {
                return (matriz.GetLength(0) != m.GetLength(0) || matriz.GetLength(1) != m.GetLength(1)) ? false : true;
            }

            private void checkearTamañosMultiplicacion(Matriz m)
            {
                if (matriz.GetLength(1) != m.matriz.GetLength(0))
                {
                    throw new Exception("Las filas de B deben ser iguales a las columnas A.");
                }
            }
        }
        */
        /*
        EJERCICIO 11
        ============
        
        static void Main()
        {
            object o = 5;
            Procesar(o, o);
            Procesar((dynamic)o, o);
            Procesar((dynamic)o, (dynamic)o);
            Procesar(o, (dynamic)o);
            Procesar(5, 5);
        }
        static void Procesar(int i, object o)
        {
            Console.WriteLine($"entero: {i} objeto:{o}");
        }
        static void Procesar(dynamic d1, dynamic d2)
        {
            Console.WriteLine($"dynamic d1: {d1} dynamic d2:{d2}");
        }
        */

        /*
        EJERCICIO 13
        ============
        
         static void Main(string[] args)
        {
            string st = null;
            string st1 = null;
            string st2 = null;
            string st3 = null;
            string st4 = null;

            
            st = st1 ?? (st = st2 ?? st3);
            st4 = null ?? "Valor por defecto";
        }

        */
        static void Main(string[] args)
        {
            Cuenta cuenta = new Cuenta();
            cuenta.Imprimir();
            cuenta = new Cuenta(30222111);
            cuenta.Imprimir();
            cuenta = new Cuenta("José Perez");
            cuenta.Imprimir();
            cuenta = new Cuenta("Maria Diaz", 20287544);
            cuenta.Imprimir();
            cuenta.Depositar(200);
            cuenta.Imprimir();
            cuenta.Extraer(150);
            cuenta.Imprimir();
            cuenta.Extraer(1500);
        }

        class Cuenta
        {
            private string _nombre;
            private int? _dni;
            private double _monto;
            public Cuenta()
            {
                _nombre = null;
                _dni = null;
            }
            public Cuenta(string nombre) : this()
            {
                _nombre = nombre;
            }
            public Cuenta(int dni) : this()
            {
                _dni = dni;
            }
            public Cuenta(string nombre, int dni)
            {
                _nombre = nombre;
                _dni = dni;
            }
            public void Imprimir()
            {
                string texto = "No especificado";
                string dni = (_dni ?? 0).ToString();
                Console.WriteLine("Nombre: {0}, DNI: {1}, Monto: {2}", _nombre?? texto, dni!="0"?_dni:texto, _monto);
            }
            public void Depositar(double monto)
            {
                _monto += monto;
            }
            public void Extraer(double monto)
            {
                if (_monto > monto)
                {
                    _monto -= monto;
                }
                else
                {
                    Console.WriteLine("Operación cancelada, monto insuficiente");
                }
            }
        }

    }
}
