using System;
using System.Collections;

namespace practica5
{
    class Program
    {
        /*
        EJERCICIO 01
        ============
        static void Main(string[] args)
            {
                Cuenta c1 = new Cuenta();
                c1.Depositar(100).Depositar(50).Extraer(120).Extraer(50);
                Cuenta c2 = new Cuenta();
                c2.Depositar(200).Depositar(800);
                new Cuenta().Depositar(20).Extraer(20);
                c2.Extraer(1000).Extraer(1);
                Console.WriteLine("\nDETALLE");
                Cuenta.ImprimirDetalle();
            }

            class Cuenta
            {
                public double Monto{get;set;}
                public static int Id{get;set;}
                public static int Denegada{get;set;}
                public static int Extracciones{get;set;}
                public static int Depositos{get;set;}
                private static double _extracciones_monto;
                private static double _depositos_monto;
                public static double Extracciones_monto
                {
                    get{
                        return _extracciones_monto;
                        }
                    set{
                        _extracciones_monto=value;
                        Extracciones++;
                        }
                }
                public static double Depositos_monto
                {
                    get{
                        return _depositos_monto;
                        }
                    set{
                        _depositos_monto=value;
                        Depositos++;
                        }
                }
                public int Id_cuenta{get;set;}
                public Cuenta()
                {
                    Id++;
                    Id_cuenta = Id;
                    Console.WriteLine("Se creo la cuenta Id={0}", Id_cuenta);
                }
                public Cuenta Depositar(double monto)
                {
                    Monto += monto;
                    Depositos_monto+=monto;
                    Console.WriteLine("Se depositó {0} en la cuenta {1} (Saldo={2})", monto, Id_cuenta, Monto);
                    return this;
                }
                public Cuenta Extraer(double monto)
                {
                    if (monto <= Monto)
                    {
                        Monto -= monto;
                        Extracciones_monto+=monto;
                        Console.WriteLine("Se extrajo {0} en la cuenta {1} (Saldo={2})", monto, Id_cuenta, Monto);
                    }
                    else{
                        Console.WriteLine("Operación denegada - Saldo insuficiente");
                        Denegada++;
                    }
                    return this;
                }
                public static void ImprimirDetalle(){
                    Console.WriteLine("CUENTAS CREADAS: {0}", Id);
                    Console.Write("DEPOSITOS: {0,6} ", Depositos);
                    Console.WriteLine("- Total depositado: {0,5}", Depositos_monto);
                    Console.Write("EXTRACCIONES: {0,3} ", Extracciones);
                    Console.WriteLine("- Total extraido: {0,7}", Extracciones_monto);
                    Console.WriteLine($"{"",17} - Saldo: {(Depositos_monto-Extracciones_monto),16}");
                    Console.WriteLine(" * Se denegaron {0} extracciones por falta de fondos", Denegada);
                }
            }    
        */
        /*
        EJERCICIO 02
        ============

            static void Main(string[] args)
            {
                new Cuenta();
                new Cuenta();
                ArrayList cuentas = Cuenta.GetCuentas();
                // se recuperó la lista de cuentas creadas
                (cuentas[0] as Cuenta).Depositar(50);
                // se depositó 50 en la primera cuenta de la lista devuelta
                cuentas.RemoveAt(0);
                Console.WriteLine(cuentas.Count);
                // se borró un elemento de la lista devuelta
                // pero la clase Cuenta sigue manteniendo todos
                // los datos "La cuenta id: 1 tiene 50 de saldo"
                cuentas = Cuenta.GetCuentas();
                Console.WriteLine(cuentas.Count);
                // se recupera nuevamente la lista de cuentas
                (cuentas[0] as Cuenta).Extraer(30);
                //se extrae 25 de la cuenta id: 1 que tenía 50 de saldo
            }

            class Cuenta
            {
                public double Monto{get;set;}
                public static int Id{get;set;}
                public static int Denegada{get;set;}
                public static int Extracciones{get;set;}
                public static int Depositos{get;set;}
                private static double _extracciones_monto;
                private static double _depositos_monto;
                public static double Extracciones_monto
                {
                    get{
                        return _extracciones_monto;
                        }
                    set{
                        _extracciones_monto=value;
                        Extracciones++;
                        }
                }
                public static double Depositos_monto
                {
                    get{
                        return _depositos_monto;
                        }
                    set{
                        _depositos_monto=value;
                        Depositos++;
                        }
                }

                public static ArrayList Lista{
                    get;
                    set;
                } = new ArrayList();
                public int Id_cuenta{get;set;}
                public Cuenta()
                {
                    Id++;
                    Id_cuenta = Id;
                    Lista.Add(this);
                    Console.WriteLine("Se creo la cuenta Id={0}", Id_cuenta);
                }
                public Cuenta Depositar(double monto)
                {
                    Monto += monto;
                    Depositos_monto+=monto;
                    Console.WriteLine("Se depositó {0} en la cuenta {1} (Saldo={2})", monto, Id_cuenta, Monto);
                    return this;
                }
                public Cuenta Extraer(double monto)
                {
                    if (monto <= Monto)
                    {
                        Monto -= monto;
                        Extracciones_monto+=monto;
                        Console.WriteLine("Se extrajo {0} en la cuenta {1} (Saldo={2})", monto, Id_cuenta, Monto);
                    }
                    else{
                        Console.WriteLine("Operación denegada - Saldo insuficiente");
                        Denegada++;
                    }
                    return this;
                }
                public static void ImprimirDetalle(){
                    Console.WriteLine("CUENTAS CREADAS: {0}", Id);
                    Console.Write("DEPOSITOS: {0,6} ", Depositos);
                    Console.WriteLine("- Total depositado: {0,5}", Depositos_monto);
                    Console.Write("EXTRACCIONES: {0,3} ", Extracciones);
                    Console.WriteLine("- Total extraido: {0,7}", Extracciones_monto);
                    Console.WriteLine($"{"",17} - Saldo: {(Depositos_monto-Extracciones_monto),16}");
                    Console.WriteLine(" * Se denegaron {0} extracciones por falta de fondos", Denegada);
                }

                public static ArrayList GetCuentas(){
                    ArrayList resp = new ArrayList();
                    foreach ( Object obj in Lista )
                        resp.Add(obj);
                    return resp;
                }
            }
        */
        /*
        EJERCICIO 03
        ============

         static void Main(string[] args)
            {
                new Cuenta();
                new Cuenta();
                ArrayList cuentas = Cuenta.GetCuentas;
                // se recuperó la lista de cuentas creadas
                (cuentas[0] as Cuenta).Depositar(50);
                // se depositó 50 en la primera cuenta de la lista devuelta
                cuentas.RemoveAt(0);
                Console.WriteLine(cuentas.Count);
                // se borró un elemento de la lista devuelta
                // pero la clase Cuenta sigue manteniendo todos
                // los datos "La cuenta id: 1 tiene 50 de saldo"
                cuentas = Cuenta.GetCuentas;
                Console.WriteLine(cuentas.Count);
                // se recupera nuevamente la lista de cuentas
                (cuentas[0] as Cuenta).Extraer(30);
                //se extrae 25 de la cuenta id: 1 que tenía 50 de saldo
            }

            class Cuenta
            {
                public double Monto{get;set;}
                public static int Id{get;set;}
                public static int Denegada{get;set;}
                public static int Extracciones{get;set;}
                public static int Depositos{get;set;}
                private static double _extracciones_monto;
                private static double _depositos_monto;
                public static double Extracciones_monto
                {
                    get{
                        return _extracciones_monto;
                        }
                    set{
                        _extracciones_monto=value;
                        Extracciones++;
                        }
                }
                public static double Depositos_monto
                {
                    get{
                        return _depositos_monto;
                        }
                    set{
                        _depositos_monto=value;
                        Depositos++;
                        }
                }

                public static ArrayList GetCuentas{
                    get{
                        ArrayList resp = new ArrayList();
                        foreach ( Object obj in Lista )
                            resp.Add(obj);
                        return resp;
                    }
                }

                public static ArrayList Lista{
                    get;
                    set;
                } = new ArrayList();
                public int Id_cuenta{get;set;}
                public Cuenta()
                {
                    Id++;
                    Id_cuenta = Id;
                    Lista.Add(this);
                    Console.WriteLine("Se creo la cuenta Id={0}", Id_cuenta);
                }
                public Cuenta Depositar(double monto)
                {
                    Monto += monto;
                    Depositos_monto+=monto;
                    Console.WriteLine("Se depositó {0} en la cuenta {1} (Saldo={2})", monto, Id_cuenta, Monto);
                    return this;
                }
                public Cuenta Extraer(double monto)
                {
                    if (monto <= Monto)
                    {
                        Monto -= monto;
                        Extracciones_monto+=monto;
                        Console.WriteLine("Se extrajo {0} en la cuenta {1} (Saldo={2})", monto, Id_cuenta, Monto);
                    }
                    else{
                        Console.WriteLine("Operación denegada - Saldo insuficiente");
                        Denegada++;
                    }
                    return this;
                }
                public static void ImprimirDetalle(){
                    Console.WriteLine("CUENTAS CREADAS: {0}", Id);
                    Console.Write("DEPOSITOS: {0,6} ", Depositos);
                    Console.WriteLine("- Total depositado: {0,5}", Depositos_monto);
                    Console.Write("EXTRACCIONES: {0,3} ", Extracciones);
                    Console.WriteLine("- Total extraido: {0,7}", Extracciones_monto);
                    Console.WriteLine($"{"",17} - Saldo: {(Depositos_monto-Extracciones_monto),16}");
                    Console.WriteLine(" * Se denegaron {0} extracciones por falta de fondos", Denegada);
                }


            }
        */

        /*
        EJERCICIO 06
        ============
        
        static void Main(string[] args)
        {
            Matriz A = new Matriz(2, 3);
            for (int i = 0; i < 6; i++) A[i / 3, i % 3]=((i + 1) / 3.0);
            Console.WriteLine("Impresión de la matriz A");
            A.Imprimir("0.000");
            double[,] aux = new double[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Matriz B = new Matriz(aux);
            Console.WriteLine("\nImpresión de la matriz B");
            B.Imprimir();
            Console.WriteLine("\nAcceso al elemento B[1,2]={0}", B[1, 2]);
            Console.Write("\nfila 1 de A: ");
            foreach (double d in A.GetFila(1)) Console.Write("{0:0.0} ", d);
            Console.Write("\n\nColumna 0 de B: ");
            foreach (double d in B.GetColumna(0)) Console.Write("{0} ", d);
            Console.Write("\n\nDiagonal principal de B: ");
            try { foreach (double d in B.DiagonalPrincipal) Console.Write("{0} ", d); } catch (Exception e) { Console.WriteLine(e.Message); }
            Console.Write("\n\nDiagonal secundaria de B: ");
            try { foreach (double d in B.DiagonalSecundaria) Console.Write("{0} ", d); } catch (Exception e) { Console.WriteLine(e.Message); }
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

            public double[] DiagonalPrincipal
            {
                get
                {
                    double[] diag = new double[matriz.GetLength(0)];
                    for (int i = 0; i < matriz.GetLength(0); i++)
                    {
                        diag[i] = matriz[i, i];
                    }
                    return diag;
                }
            }

            public double[] DiagonalSecundaria
            {
                get
                {
                    int dimension = matriz.GetLength(0);
                    double[] diag = new double[dimension];
                    for (int i = 0; i < matriz.GetLength(0); i++)
                    {
                        diag[i] = matriz[i, dimension - i - 1];
                    }
                    return diag;
                }
            }

            public double this[int a, int b]
            {
                set{
                    matriz[a,b] = value;
                }
                get{
                    return matriz[a,b];
                }
            }

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
        EJERCICIO 07
        ============
        
        static void Main(string[] args)
        {
            Persona p = new Persona();
            p[0] = "Juan Perez";
            p[1] = 'M';
            p[2] = 42123456;
            p[3] = new DateTime(2000,1,1);

            Console.WriteLine($"Nombre: {p[0]}");
            Console.WriteLine("Sexo: {0}", p[1].Equals('M')?"Masculino":"Femenino");
            Console.WriteLine($"DNI: {p[2]}");
            Console.WriteLine($"Fecha de nacimiento: {p[3]:dd/MM/yyyy}");
            Console.WriteLine($"Edad: {p[4]}");
        }

        class Persona
        {
            public string Nombre{get;set;}
            public char Sexo{get;set;}
            public int DNI{get;set;}
            public DateTime FechaNacimiento{get;set;}
            public int Edad
            {
                get{
                    DateTime hoy = DateTime.Now;
                    int edad = hoy.Year-FechaNacimiento.Year-1;
                    if(hoy.Month>FechaNacimiento.Month){
                        edad++;
                    }else if(hoy.Month==FechaNacimiento.Month){
                        if(hoy.Day>=FechaNacimiento.Day){
                            edad++;
                        }
                    }
                    return edad;
                }
            }
            public object this[int i]
            {
                get
                {
                    switch (i)
                    {
                        case 0:
                            return Nombre;
                        case 1:
                            return Sexo;
                        case 2:
                            return DNI;
                        case 3:
                            return FechaNacimiento;
                        case 4:
                            return Edad;
                        default:
                            return null;
                    }
                }
                set
                {
                    switch (i)
                    {
                        case 0:
                            Nombre = (string)value;
                            break;
                        case 1:
                            Sexo = (char)value;
                            break;
                        case 2:
                            DNI = (int)value;
                            break;
                        case 3:
                            FechaNacimiento = (DateTime)value;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        */

        /*
        EJERCICIO 08
        ============
        
        static void Main(string[] args)
        {
            ListaDePersonas lista = new ListaDePersonas();

            Persona p1 = new Persona();
            p1[0] = "Juan Perez";
            p1[1] = 'M';
            p1[2] = 42123456;
            p1[3] = new DateTime(2000, 1, 1);
            lista.Agregar(p1);

            Persona p2 = new Persona();
            p2[0] = "Julian Gimenez";
            p2[1] = 'M';
            p2[2] = 41654987;
            p2[3] = new DateTime(2000, 1, 1);
            lista.Agregar(p2);

            Persona p3 = new Persona();
            p3[0] = "Virginia Flores";
            p3[1] = 'F';
            p3[2] = 38456123;
            p3[3] = new DateTime(2000, 1, 1);
            lista.Agregar(p3);
          
            // Mostramos el nombre de la persona con el DNI = 38456123
            Console.WriteLine("Persona con DNI = 38456123");
            Console.WriteLine(lista[38456123].Nombre);

            // Mostramos los nombres de las personas que empiezan con la letra J
            Console.WriteLine("\nPersonas con Nombre comenzado en 'J':");
            ArrayList listaPersonas = lista['J'];
            foreach (Persona persona in listaPersonas)
            {
                Console.WriteLine($"Nombre: {persona.Nombre}");
            }

        }

        class ListaDePersonas
        {
            private Hashtable ht = new Hashtable();
            public void Agregar(Persona p)
            {
                ht[p.DNI] = p;
            }

            public Persona this[int dni]
            {
                get
                {
                    return (Persona)ht[dni];
                }
            }
            public ArrayList this[char c]
            {
                get
                {
                    ArrayList list = new ArrayList();
                    foreach (DictionaryEntry p in ht)
                    {
                        if(((Persona)p.Value).Nombre[0]==c) list.Add(p.Value);
                    }
                    return list;
                }
            }
        }
        class Persona
        {
            public string Nombre { get; set; }
            public char Sexo { get; set; }
            public int DNI { get; set; }
            public DateTime FechaNacimiento { get; set; }
            public int Edad
            {
                get
                {
                    DateTime hoy = DateTime.Now;
                    int edad = hoy.Year - FechaNacimiento.Year - 1;
                    if (hoy.Month > FechaNacimiento.Month)
                    {
                        edad++;
                    }
                    else if (hoy.Month == FechaNacimiento.Month)
                    {
                        if (hoy.Day >= FechaNacimiento.Day)
                        {
                            edad++;
                        }
                    }
                    return edad;
                }
            }
            public object this[int i]
            {
                get
                {
                    switch (i)
                    {
                        case 0:
                            return Nombre;
                        case 1:
                            return Sexo;
                        case 2:
                            return DNI;
                        case 3:
                            return FechaNacimiento;
                        case 4:
                            return Edad;
                        default:
                            return null;
                    }
                }
                set
                {
                    switch (i)
                    {
                        case 0:
                            Nombre = (string)value;
                            break;
                        case 1:
                            Sexo = (char)value;
                            break;
                        case 2:
                            DNI = (int)value;
                            break;
                        case 3:
                            FechaNacimiento = (DateTime)value;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
*/
/*
EJERCICIO 09
============

        static void Main()
        {
            Auto a = new Auto();
            a.Marca = "Ford";
            Console.WriteLine(a.Marca);
        }

    }
    class Auto
    {
        public string Marca
        {
            set;
            get;
        }
    }
    */

    }

}
