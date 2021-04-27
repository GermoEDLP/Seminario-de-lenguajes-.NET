# Trabajo Práctico N°5

## Ejercicio 01

Tener en cuenta que se utilizaron Propiedades autoimplementadas en vez de campos privados y que algunos setters se utilizan para administrar otras Propiedades. 
~~~
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
~~~

## Ejercicio 02

Primero creamos una Propiedad de lectura y escritura estatica que contenga una ArrayList:
~~~
public static ArrayList Lista{
                get;
                set;
            } = new ArrayList();
~~~

Luego implementamos la forma de que se llene ese ArrayList en el constructor, es decir, cuando se crea cada instancia:
~~~
public Cuenta()
{
    Id++;
    Id_cuenta = Id;
    Lista.Add(this);
    Console.WriteLine("Se creo la cuenta Id={0}", Id_cuenta);
}
~~~
Por ultimo definimos el método estático que nos retornará el ArrayList para trabajar. Tener en cuenta qu debemos retornar un ArrayList nuevo para romper la relación referencial del objeto `List` y así no afectar al mismo:
~~~
public static ArrayList GetCuentas(){
    ArrayList resp = new ArrayList();
    foreach ( Object obj in Lista )
        resp.Add(obj);
    return resp;
}
~~~

## Ejercicio 03

Creamos la Propiedad estatica de solo lectura:
~~~
public static ArrayList GetCuentas{
    get{
        ArrayList resp = new ArrayList();
        foreach ( Object obj in Lista )
            resp.Add(obj);
        return resp;
    }
}
~~~
Y cambiamos el llamado del método `GetCuentas()` en el Main por un llamado a una Propiedad:
~~~
ArrayList cuentas = Cuenta.GetCuentas;
~~~

## Ejercicio 04
