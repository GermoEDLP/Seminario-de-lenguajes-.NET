using System;

namespace practica3
{
    class Program
    {
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
        static void Main(string[] args)
        {
            
        }

    }
}
