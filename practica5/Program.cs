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

        }    
}
