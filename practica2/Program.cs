using System;
using System.Diagnostics;
using System.Text;
using System.Collections;

namespace practica2
{
    class Program
    {
        static void Main(String[] args)
        {
            int num = args.Length != 0 ? Int32.Parse(args[0]) : 0;
            if (num != 0)
            {
                int result;
                Program.Fac(num, out result);
                Console.WriteLine("Factorial de {0}: {1}", num, result);
            }
            else
            {
                Console.WriteLine("Debe ingresar un numero por consola para poder calcular su factorial");
            }
            Console.Read();
        }

        static void Fac(int n, out int r)
        {
            int total = 1;
            for (int i = 1; i <= n; i++)
            {
                total *= i;
            }
            r = total;
        }



    }



}


