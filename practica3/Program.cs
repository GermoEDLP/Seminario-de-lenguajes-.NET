using System;
using System.Text;
using System.Collections;
using System.Globalization;

namespace practica3
{
    class Program
    {
        private const string Message = "No hay coherencia en la disposicion";

        /*
EJERCICIO 01
============
static void Main(string[] args)
{
Console.CursorVisible = false;
ConsoleKeyInfo k = Console.ReadKey(true);
while (k.Key != ConsoleKey.End)
{
Console.Clear();
Console.Write($"{k.Modifiers}-{k.Key}-{k.KeyChar}");
k = Console.ReadKey(true);
}
}            
*/

        /*
        EJERCICIO 02
        ============
        static void Main(string[] args)
        {
            double[,] mat = new double[4, 4];
            for (int i = 0; i <= 15; i++)
            {
                mat[i / 4, i % 4] = i;
            }
            ImprimirMatriz(mat);
        }

        static void ImprimirMatriz(double[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write($"{matriz[i,j], 3}");
                }
                Console.WriteLine();
            }
        }

        */

        /*
        EJERCICIO 03
        ============
        static void Main(string[] args)
        {
            double[,] mat = new double[4, 4];
            string format = "0.0";
            for (int i = 0; i <= 15; i++)
            {
                mat[i / 4, i % 4] = i;
            }
            ImprimirMatriz(mat, format);
        }

        static void ImprimirMatriz(double[,] matriz, string formatString)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write($"{matriz[i, j].ToString(formatString),5}");
                }
                Console.WriteLine();
            }
        }
        
        */

        /*
        EJERCICIO 04
        ============

        static void Main(string[] args)
        {
            double[,] mat = generadorDeMatrices(4,4);
            try{
                ImprimirMatriz(mat);
                ImprimirDiagonal(GetDiagonalSecundaria(mat), "Diagonal principal: ");
                ImprimirDiagonal(GetDiagonalSecundaria(mat), "Diagonal secundaria: ");

            }catch (ArgumentException e){
                Console.WriteLine(e.Message);
            }
        }

        static double[,] generadorDeMatrices(int a, int b){
            double[,] mat = new double[a, b];
            for (int i = 0; i <= ((a*b)-1); i++)
            {
                mat[i / b, i % b] = i;
            }
            return mat;
        }

        static double[] GetDiagonalPrincipal(double[,] matriz)
        {
            checkSquare(matriz);
            double[] diag = new double[matriz.GetLength(0)];
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                diag[i] = matriz[i,i];
            }
            return diag;
        }
        static double[] GetDiagonalSecundaria(double[,] matriz)
        {
            checkSquare(matriz);
            int dimension = matriz.GetLength(0) - 1;
            double[] diag = new double[dimension];
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                diag[i] = matriz[i, dimension-i];
            }
            return diag;
        }

        static double[] GetDiagonal(double[,] matriz, bool principal)
        {
            checkSquare(matriz);
            int dimension = matriz.GetLength(0) - 1;
            double[] diag = new double[dimension];
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                diag[i] = matriz[i, principal ? i : dimension-i];
            }
            return diag;
        }

        static void checkSquare(double[,] matriz){
            if(matriz.GetLength(0)!=matriz.GetLength(1)){
                throw new ArgumentException("La matriz no es cuadrada");
            }
            return;
        }

         static void ImprimirMatriz(double[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write($"{matriz[i, j],5}");
                }
                Console.WriteLine();
            }
        }

          static void ImprimirDiagonal(double[] diag, string texto)
        {
            Console.WriteLine();
            Console.WriteLine(texto);
            for (int i = 0; i < diag.Length; i++)
            {
                    Console.Write($"{diag[i],5}");
            }
            Console.WriteLine();
        }       
        */

        /*
        EJERCICIO 05
        ============
        
                static void Main(string[] args)
        {
            double[,] mat = generadorDeMatrices(4,4);
            Console.WriteLine("Matriz original: ");
            ImprimirMatriz(mat);
            Console.WriteLine();
            Console.WriteLine("Array de arrays: ");
            ImprimirArrayDeArrays(GetArregloDeArreglo(mat));
        }

        static double[,] generadorDeMatrices(int a, int b){
            double[,] mat = new double[a, b];
            for (int i = 0; i <= ((a*b)-1); i++)
            {
                mat[i / b, i % b] = i;
            }
            return mat;
        }

        static double[][] GetArregloDeArreglo(double [,] matriz){
            double[][] newMat = new double[matriz.GetLength(1)][];
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                newMat[i] = new double[matriz.GetLength(0)];
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    newMat[i][j] = matriz[i,j];
                }
            }
            return newMat;
        }

        static void ImprimirMatriz(double[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write($"{matriz[i, j],5}");
                }
                Console.WriteLine();
            }
        }

        static void ImprimirArrayDeArrays(double[][] matriz)
        {
            for (int i = 0; i < matriz.Length; i++)
            {
                for (int j = 0; j < matriz[i].Length; j++)
                {
                    Console.Write($"{matriz[i][j],5}");
                }
                Console.WriteLine();
            }
        }
        */

        /*
        EJERCICIO 06
        ============
        
        static void Main(string[] args)
        {
            try
            {
                double[,] mat1 = generadorDeMatrices(4, 3, 1);
                double[,] mat2 = generadorDeMatrices(4, 4, 2);
                Console.WriteLine("Matriz original A: ");
                ImprimirMatriz(mat1);
                Console.WriteLine("Matriz original B: ");
                ImprimirMatriz(mat2);
                Console.WriteLine();

                Console.WriteLine("Matriz suma: ");
                double[,] suma = Suma(mat1, mat2);
                if(suma!=null){
                    ImprimirMatriz(suma);
                    Console.WriteLine();
                }else{
                    Console.WriteLine("Matrices con tamaños diferentes");
                    Console.WriteLine();
                }

                Console.WriteLine("Matriz resta: ");
                double[,] resta = Resta(mat1, mat2);
                if(resta!=null){
                    ImprimirMatriz(Resta(mat1, mat2));
                    Console.WriteLine();
                }else{
                    Console.WriteLine("Matrices con tamaños diferentes");
                    Console.WriteLine();
                }

                Console.WriteLine("Matriz multiplicación: ");
                ImprimirMatriz(Multiplicacion(mat1, mat2));
                Console.WriteLine();
                

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        static double[,] Suma(double[,] A, double[,] B)
        {
            if (checkearTamaños(A, B))
            {
                double[,] suma = new double[A.GetLength(0), A.GetLength(1)];
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        suma[i, j] = A[i, j] + B[i, j];
                    }
                }
                return suma;
            }
            return null;

        }
        static double[,] Resta(double[,] A, double[,] B)
        {
            if (checkearTamaños(A, B))
            {
                double[,] resta = new double[A.GetLength(0), A.GetLength(1)];
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        resta[i, j] = A[i, j] - B[i, j];
                    }
                }
                return resta;
            }
            return null;
        }

        static double[,] Calculo(double[,] A, double[,] B, bool suma)
        {
            if (checkearTamaños(A, B))
            {
                double[,] operacion = new double[A.GetLength(0), A.GetLength(1)];
                for (int i = 0; i < A.GetLength(0); i++)
                {
                    for (int j = 0; j < A.GetLength(1); j++)
                    {
                        operacion[i, j] = suma ? A[i, j] + B[i, j] : A[i, j] - B[i, j];
                    }
                }
                return operacion;
            }
            return null;
        }
        static double[,] Multiplicacion(double[,] A, double[,] B)
        {
            checkearTamañosConException(A,B);
            double[,] mult = new double[A.GetLength(0), A.GetLength(1)];
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    mult[i, j] = A[i, j] * B[i, j];
                }
            }
            return mult;
        }

        static void ImprimirMatriz(double[,] matriz)
        {
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write($"{matriz[i, j],5}");
                }
                Console.WriteLine();
            }
        }

        static double[,] generadorDeMatrices(int a, int b, int modf)
        {
            double[,] mat = new double[a, b];
            for (int i = 0; i <= ((a * b) - 1); i++)
            {
                mat[i / b, i % b] = i*modf;
            }
            return mat;
        }

        static void checkearTamañosConException(double[,] mat1, double[,] mat2)
        {
            if (mat1.GetLength(1) != mat2.GetLength(0))
            {
                throw new ArgumentException("Las filas de B deben ser iguales a las columnas de A.");
            }
        }

        static bool checkearTamaños(double[,] mat1, double[,] mat2)
        {
            return (mat1.GetLength(0) != mat2.GetLength(0) || mat1.GetLength(1) != mat2.GetLength(1)) ? false : true;
        }

        */

        /*
        EJERCICIO 08
        ============
         static void Main(string[] args)
        {
            var a = 3L;
            dynamic b = 32;
            object obj = 3;
            // a = a * 2.0;        // => a fue definido como un entero (64bits), no puede contener un double (resultado de operar un integer con un double literal)
            b = b * 2.0;
            b = "hola";
            obj = b;
            b = b + 11;
            // obj = obj + 11;        // => No se puede sumar directamente un integer con un objeto. Incluso si el objeto contiene un integer.
            var c = new { Nombre = "Juan" };
            var d = new { Nombre = "María" };
            var e = new { Nombre = "Maria", Edad = 20 };
            var f = new { Edad = 20, Nombre = "Maria" };
            // f.Edad = 22;            // => La La inferencia de tipos permite instanciar objetos de tipos anónimos con un conjunto de propiedades de SOLO LECTURA.
            d = c;
            // e = d;                  // => No se pueden igualar objetos que no comparten estructura.
            // f = e;                  // => No se pueden igualar objetos que no comparten estructura, incluso si esta esta solo desordenada (para el comilador son dos objetos de estructura distinta)
        }
        
        */

        /*
        EJERCICIO 09
        ============
        
        static void Main(string[] args)
        {
            object obj = new int[10];
            dynamic dyn = 13;
            Console.WriteLine(obj.Length);
            Console.WriteLine(dyn.Length);
        }

        */

        /*
        EJERCICIO 10
        ============
        
        static void Main(string[] args)
        {
            double a = 1.163852;
            
            Console.WriteLine("Numero a: {0:0.0}", a);      // => Numero a: 1,2
            Console.WriteLine("Numero a: {0:0.00}", a);     // => Numero a: 1,16
            Console.WriteLine("Numero a: {0:0.000}", a);    // => Numero a: 1,164
            Console.WriteLine("Numero a: {0:0.0000}", a);   // => Numero a: 1,1639
            Console.WriteLine("Numero a: {0:0.00000}", a);  // => Numero a: 1,16385

            Console.WriteLine($"Numero a: {a:0.0}");        // => Numero a: 1,2
            Console.WriteLine($"Numero a: {a:0.00}");       // => Numero a: 1,16
            Console.WriteLine($"Numero a: {a:0.000}");      // => Numero a: 1,164
            Console.WriteLine($"Numero a: {a:0.0000}");     // => Numero a: 1,1639
            Console.WriteLine($"Numero a: {a:0.00000}");    // => Numero a: 1,16385
        }
        */

        /*
        EJERCICIO 11
        ============
        
        static void Main(string[] args)
        {
            ArrayList a = new ArrayList() { 1, 2, 3, 4 };
            a.Remove(5);
            // a.RemoveAt(5);
            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }
        }
        */

        /*
        EJERCICIO 12
        ============
        
                static void Main(string[] args)
        {
            // Seteo el Queue
            int[] enteros = { 5, 3, 9, 7 };
            Queue codigo = setearQueue(enteros);

            Console.WriteLine("Ingrese el texto a cifrar: ");

            // Al solicitar el texto, lo convierto en un array de caracteres.
            string texto = Console.ReadLine();

            // Codifico el texto y lo almaceno en la variable
            codigo = setearQueue(enteros);
            string texto_codificado = codificar(texto, codigo);
            Console.WriteLine("<<Texto codificado>>");
            Console.WriteLine(texto_codificado);

            // Decodifico el texto y lo almaceno en la variable
            codigo = setearQueue(enteros);
            string texto_decodificado = decodificar(texto_codificado, codigo);
            Console.WriteLine("<<Texto decodificado>>");
            Console.WriteLine(texto_decodificado);

        }

        static string decodificar(string texto, Queue q)
        {
            // Convierto el texto recibido en un array de caracteres
            char[] textoADecodificar = texto.ToCharArray();
            // Creo una variable para alamacenar el texto decodificado
            char[] decodificado = new char[texto.Length];

            // Inicio un ciclo for en base a la cantidad de caracteres del texto.
            for (int i = 0; i < textoADecodificar.Length; i++)
            {
                // Tomo el primer valor de la queue
                int codigo = (int)q.Dequeue();
                // Obtengo el entero de tabla ascii que corresponde al caracter
                int ascii = getAsciiByChar(texto[i].ToString());
                // Le resto el codigo
                int ascii_con_codigo = ascii - codigo;
                // Averiguo el caracter que corresponde al codigo ascii ya restado y lo agrego al array de decodificacion
                decodificado[i] = getCharByAscii(ascii_con_codigo);
                // Recoloco el codigo al final de la cola
                q.Enqueue(codigo);
            }
            Console.WriteLine();
            // Retorno un string en base al array de caracteres creado en el ciclo for
            return new string(decodificado);
        }

        static string codificar(string texto, Queue q)
        {
            char[] textoACodificar = texto.ToCharArray();
            char[] codificado = new char[texto.Length];
            for (int i = 0; i < texto.Length; i++)
            {
                // Tomo el primer valor de la queue
                int codigo = (int)q.Dequeue();
                // Obtengo el entero de tabla ascii que corresponde al caracter
                int ascii = getAsciiByChar(texto[i].ToString());
                // Le sumo el codigo
                int ascii_con_codigo = ascii + codigo;
                // Averiguo el caracter que corresponde al codigo ascii ya sumado y lo agrego al array de codificacion
                codificado[i] = getCharByAscii(ascii_con_codigo);
                // Recoloco el codigo al final de la cola  
                q.Enqueue(codigo);
            }
            Console.WriteLine();
            return new string(codificado);
        }

        static int getAsciiByChar(string a)
        {
            // Pongo todos los caracteres en mayusculas
            a = a.ToUpper();
            // Si el caracter es un espacio vacío o una Ñ, les coloco un valor predefinido (por no estar en tabla ascii de manera ordenada con los otros)
            if (a == " ")
            {
                // Console.WriteLine("Aqui asciibychar: caracter " + a);
                return 28;
            }
            if (a == "Ñ")
            {
                return 15;
            }

            // Decodifico el caracter y obtengo su codigo ascii
            int ascii = Encoding.ASCII.GetBytes(a)[0];

            // Evaluo el codigo ascii original y lo llevo a la tabla que dieron en el ejercicio
            if (ascii >= 65 && ascii < 79)
            {
                return ascii - 64;
            }
            else if (ascii >= 79 && ascii <= 90)
            {
                return ascii - 63;
            }
            return 0;

        }

        static char getCharByAscii(int a)
        {
            // Si el ascii que recivo esta por encima de 28 o por debajo de cero, lo modifico para que entre en la tabla de letras que defini
            if (a > 28)
            {
                a = -28 + a;
            }
            else if (a <= 0)
            {
                a = 28 + a;
            }
            // Si el caracter es 28 (espacio vacio) o un 15(Ñ), les coloco esos valores.
            if (a == 28)
            {
                // Console.WriteLine("Aqui charbyAscii: caracter " + a);
                return ' ';
            }
            else if (a == 15)
            {
                return 'Ñ';
            }
            // Al retornar un entero casteandolo como char, retorno ese caracter, pero primero debo llevarlo a tabla ascii original.
            else if (a >= 1 && a < 15)
            {
                return (char)(a + 64);
            }
            else if (a >= 15 && a <= 27)
            {
                return (char)(a + 63);
            }
            return ' ';
        }

    static Queue setearQueue(int[] enteros)
    {
        //Defino el queue
        Queue codigo = new Queue();
        // Lo inicilizo en base al array de enteros que recibe por parametro
        for (int i = 0; i < enteros.Length; i++)
        {
            codigo.Enqueue(enteros[i]);

        }
        return codigo;
    }
        */

        /*
        EJERCICIO 13
        ============
        
         static void Main(string[] args)
        {
            // Al solicitar el texto, lo convierto en un array de caracteres.
            string[] texto = { "(-5)*(5+3+(56*2))-(4)", "(-5)", "(-5)(", "(-5))(" };

            for (int i = 0; i < texto.Length; i++)
            {
                try
                {
                    char[] caracteres = texto[i].ToCharArray();
                    Console.WriteLine("Expresión: {0}", texto[i]);
                    analizar(caracteres);
                    Console.WriteLine("Expresión valida");
                    Console.WriteLine();
                }catch (Exception e){
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                }
            };
        }

        static void analizar(char[] carracteres)
        {
            // Defino la pila
            Stack pila = new Stack();
            // Recorro la expresión caracter a caracter
            for (int i = 0; i < carracteres.Length; i++)
            {
                // Tomo el carcter y analizo el valor ascii del mismo
                int ascii = Encoding.ASCII.GetBytes(carracteres[i].ToString())[0];
                // Si es 40 = ( y si es 41 = )
                if (ascii == 40)
                {
                    // Si hay un parentesis de apertura guardo en la pila
                    pila.Push(ascii);
                }
                else if (ascii == 41)
                {
                    // Si hay un parentesis de cierre primero pregunto si la pila no esta vacia, lo que daría un error.
                    if (pila.Count == 0)
                    {
                        throw new Exception("[Expresión invalida] Falta de coherencia");
                    }
                    // Si no esta vacia, saco un elemento de la pila
                    else
                    {
                        pila.Pop();
                    }
                }
            }
            // Si al finalzar toda la expresión, me quedarón parentesis abiertos, entonces salgo con una expecion
            if (pila.Count != 0)
            {
                throw new Exception("[Expresión invalida] Signos adicionales");
            }
        }
        */

        /*
        EJERCICIO 14
        ============
        
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese un numero en base 10: ");
            int numero = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("El binario de {0} es: {1}", numero, base10abase2(numero));

        }

        static string base10abase2(int num){
            // Se cre la pila
            Stack pila = new Stack();
            // Mientras que el numero sea mayor que 1, voy a seguir operando
            while(num>1){
                // Guardo el modulo de la division y divido de manera entera el numero
                pila.Push(num%2);
                num=num/2;
            }
            // Cunado termino guardo el restante en la pila. Aqui se encunetra el resto de la ultima operacion
            pila.Push(num);
            StringBuilder st = new StringBuilder();
            while(pila.Count!=0){
                // Por medio de un stringBuilder creo una cadena desapilando la pila.
                st.Append(pila.Pop());
            }
            return st.ToString();
        }
        */

        /*
        EJERCICIO 15
        ============
        
        static void Main()
        {
            int x = 0;
            try
            {
                Console.WriteLine(1.0 / x);
                // Console.WriteLine(1 / x);
                Console.WriteLine("todo OK");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        */

        /*
        EJERCICIO 16
        ============

                static void Main()
            {
                // Inicializa los controaldores
                bool continua = true;
                int total = 0;
                //EL ciclo while terminara una vez se ingrese un caracter vacio y eso cambie la bandera "Continua"
                while (continua)
                {
                    try
                    {
                        Console.WriteLine("Ingrese numeros por favor: ");
                        string entrada = Console.ReadLine();
                        //Evalua que no hayan ingresado un caracter vacio
                        if (entrada.Length == 0)
                        {
                            // Si es vacio, finaliza el "continua" y retorna el total
                            Console.WriteLine("Total: " + total);
                            continua = false;
                        }
                        else
                        {
                            // Si no es caracter vacio, lo convierte en entero y lo suma al total
                            total = total + analizarEntrada(entrada);
                            Console.WriteLine("Numero ingresado: {0} - Suma total: {1}", entrada, total);

                        }
                    }

                    catch (FormatException e)
                    {
                        Console.WriteLine();
                        Console.WriteLine("ERROR: Ingrese un valor numerico entero. (Error: {0})", e.Message);
                        Console.WriteLine();
                    }


                }
            }

            static int analizarEntrada(string entrada)
            {
                // Si no es entero, esta linea lanza una excepcion que es capturaa por el catch
                return Int32.Parse(entrada);
            }

    */

            /*
        EJERCICIO 17
        ============
        
        static void Main(string[] args)
        {
            // Defino los operadores que voy a admitir
            string[] operadores = new string[4] { "+", "-", "/", "*" };
            // Utilizamos un tipo nullable para trabajar sobre la posibilidad de no ser calculado
            double? total = null;
            bool continua = true;
            // Inicio el ciclo de obtención de expresiones
            while (continua)
            {
                Console.WriteLine("Introduzca una operación básica de dos terminos ('fin' para terminar): ");
        
                string expresion = Console.ReadLine();
                // Corta el ciclo si determina el 'fin'
                if (expresion == "fin")
                {
                    continua = false;
                    break;
                }
                try
                {
                    // Evalua cada operador de la lista de operadores
                    for (int i = 0; i < operadores.Length; i++)
                    {
                        // Envia a calcular cada operador
                        calcular(operadores[i], expresion, ref total);
                    }
                    if (total == null)
                    {
                        // Si no se cambio el valor, significa que no hay operadores conocidos en expresión
                        // entonces lanzo una excepcion
                        throw new Exception("La expresión no tiene ningún operador conocido");
                    }
                    Console.WriteLine($"Total: {total:0.00}");
                }
                catch (Exception e)
                {
                    // Excepción manejada desde el método que llama
                    Console.WriteLine("Excepción manejada en el padre. Error: {0}", e.Message);
                }

                static void calcular(string operador, string expresion, ref double? total)
                {
                    // Defino el provedor de formato para la conversión de string a double.
                    // Basicamente, que simbolo usará para identificar los decimales.
                    NumberFormatInfo provider = new NumberFormatInfo();
                    provider.NumberDecimalSeparator = ".";
                    provider.NumberGroupSizes = new int[] { 3 };
                    // Evaluo si el operador esta en la expresión
                    if (expresion.IndexOf(operador) != -1)
                    {
                        // Separo los terminos de la operación usando el operador
                        string[] terminos = expresion.Split(operador);
                        try
                        {
                            // Calculo según sea el operador
                            switch (operador)
                            {
                                case "+":
                                    total = Convert.ToDouble(terminos[0], provider) + Convert.ToDouble(terminos[1], provider);
                                    break;
                                case "-":
                                    total = Convert.ToDouble(terminos[0], provider) - Convert.ToDouble(terminos[1], provider);
                                    break;
                                case "/":
                                    total = Convert.ToDouble(terminos[0], provider) / Convert.ToDouble(terminos[1], provider);
                                    break;
                                case "*":
                                    total = Convert.ToDouble(terminos[0], provider) * Convert.ToDouble(terminos[1], provider);
                                    break;
                            }
                        }
                        catch (Exception e)
                        {
                            // Excepción de error de conversión manejada y propagada.
                            Console.WriteLine("La expresión no es valida.");
                            throw;
                        }
                    }
                }
            }
        }
*/

        /*
        EJERCICIO 18
        ============
        
        static void Main(string[] args)
        {
            try
            {
                Metodo1();
            }
            catch
            {
                Console.WriteLine("Método 1 propagó una excepción no tratada");
            }
            try
            {
                Metodo2();
            }
            catch
            {
                Console.WriteLine("Método 2 propagó una excepción no tratada");
            }
            try
            {
                Metodo3();
            }
            catch
            {
                Console.WriteLine("Método 3 propagó una excepción");
            }
        }
        static void Metodo1()
        {
            object obj = "hola";
            try
            {
                int i = (int)obj;
            }
            finally
            {
                Console.WriteLine("Bloque finally en Metodo1");
            }
        }
        static void Metodo2()
        {
            object obj = "hola";
            try
            {
                int i = (int)obj;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Overflow");
            }
        }
        static void Metodo3()
        {
            object obj = "hola";
            try
            {
                int i = (int)obj;
            }
            catch (InvalidCastException)
            {
                Console.WriteLine("Excepción InvalidCast en Metodo3");
                throw;
            }
        }

        */



    }

}
