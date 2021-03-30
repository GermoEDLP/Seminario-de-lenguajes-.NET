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
            Imprimir(1, "casa", 'A', 3.4, DayOfWeek.Saturday);
            Imprimir(1, 2, "tres");
            Imprimir();
            Imprimir("-------------");
        }

        static void Imprimir(params object[] vector)
        {
            foreach (object item in vector)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }



    }



}


