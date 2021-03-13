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



            
            */


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
            Console.WriteLine("Ingrese su nombre por favor: ");
            string nombre1 = Console.ReadLine();

            switch (nombre1)
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
                    Console.WriteLine("Buen día " + nombre1);
                    break;
            }
            Console.WriteLine("Ingrese su nombre por favor: ");
            string nombre2 = Console.ReadLine();

            switch (nombre2)
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
                    Console.WriteLine("Buen día " + nombre2);
                    break;
            }
            Console.WriteLine("Ingrese su nombre por favor: ");
            string nombre3 = Console.ReadLine();

            switch (nombre3)
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
                    Console.WriteLine("Buen día " + nombre3);
                    break;
            }
            Console.WriteLine("Ingrese su nombre por favor: ");
            string nombre4 = Console.ReadLine();

            switch (nombre4)
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
                    Console.WriteLine("Buen día " + nombre4);
                    break;
            }
     

        }
    }
}

