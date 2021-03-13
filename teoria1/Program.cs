using System;

namespace teoria1
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            EJERCICIO 01
            ============
            
            Write       => Escribe la representación de texto del valor o 
                           valores especificados en el flujo de salida estándar.

            WriteLine   => Escribe los datos especificados, seguidos del 
                           terminador de línea actual, en el flujo de salida estándar.

            Diferencia entre ambos  => El método write genera uno o más valores en 
                                       la pantalla sin un nuevo carácter de línea. Esto 
                                       significa que cualquier salida posterior se imprimirá 
                                       en la misma línea. Mientras que cualquier salida posterior
                                       al writeLine, se imprimira debajo por realizar un salto de
                                       linea como ultima acción
            
            ReadKey     => Obtiene la siguiente tecla de carácter o de función presionada por el 
                           usuario. La tecla presionada se muestra en la ventana de la consola.
            
            //Es un poco de trampa porque sino se sobreescriben las lineas
            Console.ReadKey();
            Console.Write("Hola ");
            Console.ReadKey();
            Console.WriteLine("Hola Mundo");

            */

            /*
            EJERCICIO 02
            ============
            
            Secuencias de escape  => Son las combinaciones de caracteres que constan de una barra 
                                     invertida ( \ ) seguida de una letra o de una combinación de 
                                     dígitos. Para representar un carácter de nueva línea, comillas 
                                     simples u otros caracteres determinados en una constante de 
                                     carácter, debe utilizar secuencias de escape. Una secuencia de 
                                     escape se considera un carácter único y, por lo tanto, es válida 
                                     como una constante de carácter.

            \n  => Nueva linea: El cursor se coloca debajo de la linea impresa (Como si fuera un ENTER)

            \t  => Tab Horizonal: EL cursor se dezplaza horizontalmente luego de realzar la impresión

            \"  => Comillas dobles: Este caracter no se puede realizar de manera convencional por estar
                   reservado para indicar inicio y fin de los string, por lo que si se quiere imprimir
                   en pantalla, se debe utilizar esta secuencia de escape.

            \\  => Barra invertida: Idem que en el caso de la comilla doble pero con la barra invertida.

            string nombre = "German";
            double total = 55.36;
            Console.Write("Hola\n");
            Console.WriteLine("\"" + nombre + "\"");
            Console.Write("Este es tu saldo total:\t$" + total);

            */

            /*
            EJERCICIO 03
            ============
            
            Se retira el @ y se agregan las barras invertidas necesarias para completar la secuencia de escape.

            
                string st = "c:\\windows\\system";
                Console.WriteLine(st);
            */

            /*
            EJERCICIO 04
            ============
            
            Console.WriteLine("Ingrese su nombre por favor: ");
            string nombre = Console.ReadLine();
            if (nombre == "")
            {

                Console.WriteLine("Hola mundo");
            }
            else
            {
                Console.WriteLine("Hola " + nombre + ". Bienvenidx!");
            };

            
            */

            /*
            EJERCICIO 05
            ============
            a)

              Console.WriteLine("Ingrese su nombre por favor: ");
            string nombre = Console.ReadLine();
            if (nombre == "Juan")
            {
                Console.WriteLine("Hola amigo");
            }
            else if (nombre == "María")
            {
                Console.WriteLine("Buen día señora");
            }
            else if (nombre == "Alberto")
            {
                Console.WriteLine("Hola Alberto");
            }
            else if (nombre == "")
            {
                Console.WriteLine("Hola mundo");
            }
            else
            {
                Console.WriteLine("Buen día " + nombre);
            }

            b)
            Console.WriteLine("Ingrese su nombre por favor: ");
            string nombre = Console.ReadLine();

            switch (nombre)
            {
                case "Juan":
                    Console.WriteLine("Hola amigo");
                    break;
                case "María":
                    Console.WriteLine("Buen día señora");
                    break;
                case "Alberto":
                    Console.WriteLine("Hola Alberto");
                    break;
                case "":
                    Console.WriteLine("Hola mundo");
                    break;
                default:
                    Console.WriteLine("Buen día " + nombre);
                    break;
            }
            
            */

            /*
            EJERCICIO 06
            ============
            Console.WriteLine("Ingrese cadenas de texto: ");
            bool continua = true;

            while (continua)
            {
                string st = Console.ReadLine();
                if (st != "")
                {
                    Console.WriteLine("Cantidad de caracteres ingresados: " + st.Length);
                }
                else
                {
                    continua = false;
                }
            }
            
            */

            /*
            EJERCICIO 07
            ============
            // Imprime la cantidad de caracteres que tiene la cadena, en este caso 3.
            System.Console.WriteLine("100".Length); 
            
            // 3

            */

            /*
            EJERCICIO 08
            ============
            
            // Teniendo en cuneta que debemos declararala correctamente, se puede asegurar que las
            // lineas tienen sentido y vana a funcionar: Imprimiendo lo que se escriba por consola.
            string st;
            Console.WriteLine(st=Console.ReadLine());
            */

            /*
            EJERCICIO 09
            ============
            
            Esta forma de captar las palabras a analizar esta bien, pero en la practica dice que las palabras
            deben ser ingresadas separadas por un blanco, por lo que no estaría del todo bien, mas abajo se 
            muestra la forma que finalmente se adoptó.

            // Console.WriteLine("Ingrese la primera palabra: ");
            // string st1 = Console.ReadLine();
            // Console.WriteLine("Ingrese la segunda palabra: ");
            // string st2 = Console.ReadLine();

            Console.WriteLine("Ingrese las palabras separadas por un espacio: ");
            string st = Console.ReadLine();
            string st1 = st.Split(" ")[0];
            string st2 = st.Split(" ")[1];


            bool ok = true;

            if (st1.Length != st2.Length)
            {
                Console.WriteLine("Las palabras " + st1 + " y " + st2 + ", NO son simetricas y ni siquiera comparten la misma cantidad de caracteres");
            }
            else
            {
                for (int i = 0; i < st1.Length; i++)
                {
                    if (st1[i] != st2[st1.Length - 1 - i])
                    {
                        ok = false;
                        break;
                    }
                }

                if (ok)
                {
                    Console.WriteLine("Las palabras " + st1 + " y " + st2 + ", son simetricas");
                }
                else
                {
                    Console.WriteLine("Las palabras " + st1 + " y " + st2 + ", NO son simetricas");

                }

            }

            
            */

            /*
            EJERCICIO 10
            ============
            
            for(int i = 1; i <= 1000; i++){
                if(i%17 == 0 || i%29==0){
                    Console.WriteLine(i);
                }
            }
            
            */

            Console.WriteLine("10/3 = " + 10 / 3);
            Console.WriteLine("10.0/3 = " + 10.0 / 3);
            Console.WriteLine("10/3.0 = " + 10 / 3.0);
            int a = 10, b = 3;
            Console.WriteLine("Si a y b son variables enteras, si a=10 y b=3");
            Console.WriteLine("entonces a/b = " + a / b);
            double c = 3;
            Console.WriteLine("Si c es una variable double, c=3");
            Console.WriteLine("entonces a/c = " + a / c);










        }
    }
}

