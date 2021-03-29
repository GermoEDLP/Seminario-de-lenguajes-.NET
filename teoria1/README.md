
## EJERCICIO 01
            
* __Write:__ Escribe la representación de texto del valor o valores especificados en el flujo de salida estándar.

* __WriteLine:__ Escribe los datos especificados, seguidos del terminador de línea actual, en el flujo de salida estándar.

* __Diferencia entre ambos:__ El método write genera uno o más valores en la pantalla sin un nuevo carácter de línea. Esto significa que cualquier salida posterior se imprimirá en la misma línea. Mientras que cualquier salida posterior al writeLine, se imprimira debajo por realizar un salto de linea como ultima acción
            
* __ReadKey:__ Obtiene la siguiente tecla de carácter o de función presionada por el usuario. La tecla presionada se muestra en la ventana de la consola.
            
Es un poco de trampa porque sino se sobreescriben las lineas
~~~
Console.ReadKey();
Console.Write("Hola ");
Console.ReadKey();
Console.WriteLine("Hola Mundo");
~~~

## EJERCICIO 02
            
* __Secuencias de escape:__ Son las combinaciones de caracteres que constan de una barra invertida ( \ ) seguida de una letra o de una combinación de dígitos. Para representar un carácter de nueva línea, comillas simples u otros caracteres determinados en una constante de carácter, debe utilizar secuencias de escape. Una secuencia de escape se considera un carácter único y, por lo tanto, es válida como una constante de carácter.

    * __\n__ *Nueva linea:* El cursor se coloca debajo de la linea impresa (Como si fuera un ENTER).
    * __\t__ *Tab Horizonal:* El cursor se dezplaza horizontalmente luego de realzar la impresión
    * __\\"__ *Comillas dobles:* Este caracter no se puede realizar de manera convencional por estar reservado para indicar inicio y fin de los string, por lo que si se quiere imprimir en pantalla, se debe utilizar esta secuencia de escape.
    * __\\\\__ *Barra invertida:* Idem que en el caso de la comilla doble pero con la barra invertida.

~~~
string nombre = "German";
double total = 55.36;
Console.Write("Hola\n");
Console.WriteLine("\"" + nombre + "\"");
Console.Write("Este es tu saldo total:\t$" + total);
~~~

##  EJERCICIO 03
            
Se retira el @ y se agregan las barras invertidas necesarias para completar la secuencia de escape.

~~~
string st = "c:\\windows\\system";
Console.WriteLine(st);
~~~

## EJERCICIO 04

~~~
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
~~~
            
## EJERCICIO 05
   
* __a):__
~~~
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
~~~

* __b):__
~~~
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
~~~            

## EJERCICIO 06

~~~   
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
~~~
            
## EJERCICIO 07
   
Imprime la cantidad de caracteres que tiene la cadena, en este caso 3. 
~~~
System.Console.WriteLine("100".Length); 
// 3
~~~
            
## EJERCICIO 08

Teniendo en cuneta que debemos declararala correctamente, se puede asegurar que las lineas tienen sentido y vana a funcionar: Imprimiendo lo que se escriba por consola.
~~~
string st;
Console.WriteLine(st=Console.ReadLine());
~~~

## EJERCICIO 09
   
Esta forma de captar las palabras a analizar esta bien, pero en la practica dice que las palabras deben ser ingresadas separadas por un blanco, por lo que no estaría del todo bien, mas abajo se muestra la forma que finalmente se adoptó.

* __Forma a):__ Obtener los valores mendiante 2 tomas de valor.
~~~
Console.WriteLine("Ingrese la primera palabra: ");
string st1 = Console.ReadLine();
Console.WriteLine("Ingrese la segunda palabra: ");
string st2 = Console.ReadLine();
~~~

* __Forma b):__ Obtener los valores mendiante 1 toma de valor, y despues separar ambas palabras.
~~~
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
~~~

## EJERCICIO 10
~~~
for(int i = 1; i <= 1000; i++){
    if(i%17 == 0 || i%29==0){
        Console.WriteLine(i);
    }
}
~~~            
            
## EJERCICIO 11

~~~         
Console.WriteLine("10/3 = " + 10 / 3);
Console.WriteLine("10.0/3 = " + 10.0 / 3);
Console.WriteLine("10/3.0 = " + 10 / 3.0);
int a = 10, b = 3;
Console.WriteLine("Si a y b son variables enteras, si a=10 y b=3");
Console.WriteLine("entonces a/b = " + a / b);
double c = 3;
Console.WriteLine("Si c es una variable double, c=3");
Console.WriteLine("entonces a/c = " + a / c);
~~~

* __División entre enteros:__ Para los operandos de tipos enteros, el resultado del operador / es de un tipo entero y equivale al cociente de los dos operandos redondeados hacia cero. Para obtener el cociente de los dos operandos como número de punto flotante, debemos usar el tipo float, double o decimal.

* __División de punto flotante:__ Para los tipos float, double y decimal, el resultado del operador / es el cociente de los dos operandos. Si uno de los operandos es decimal, otro operando no puede ser float ni double, ya que ni float ni double se convierte de forma implícita a decimal. Debe convertir explícitamente el operando float o double al tipo decimal.

* __Suma de distintos tipos de dato:__ 
    * Si dos numeros se suman, se obtiene la suam aritmetica. 
    * Si dos strings (o caracteres) se suman, se obtiene la concatenación de ambos. 
    * Si un numero y un string se suman, el numero es convertido a string y es concatenado con el otro string. 
            
## EJERCICIO 12

~~~         
Console.WriteLine("Ingrese el primer numero: ");
int num1 = int.Parse(Console.ReadLine());
Console.WriteLine("Ingrese el segundo numero: ");
int num2 = int.Parse(Console.ReadLine());
int total = num1 + num2;
Console.WriteLine("El resultado de la suma es: " + total);
~~~

## EJERCICIO 13

~~~            
Console.WriteLine("Ingrese el primer numero: ");
double num1 = double.Parse(Console.ReadLine());
Console.WriteLine("Ingrese el segundo numero: ");
double num2 = double.Parse(Console.ReadLine());
double total = num1 + num2;
Console.WriteLine("El resultado de la suma es: " + total);
~~~            

## EJERCICIO 14

~~~
Console.WriteLine("Ingrese el numero: ");

// Esta linea convierte el string retornado por el método ReadLine() (ingresado por el usuario)
// a un entero para poder multiplicarlo por 365. Luego, el resultado es convertido a un string, 
// por medio de la función toString().
string num = (int.Parse(Console.ReadLine()) * 365).ToString();

string numRev = "";
for(int i = 0; i < num.Length; i++){
    //A medida que se sucede el bucle, se le agrega a la variable numero con siguiente mayor 
    relevancia, ademas de un espacio.
    numRev += num[num.Length-1-i] + " ";
};

Console.WriteLine(numRev);
~~~

## EJERCICIO 15

~~~            
Console.WriteLine("Ingrese un año: ");
int ano = int.Parse(Console.ReadLine());

if (ano % 100 == 0)
{
    if (ano % 400 == 0)
    {
        Console.WriteLine("El año es Bisiesto");
    }
    else
    {
        Console.WriteLine("El año NO es Bisiesto");
    }
}
else if (ano % 4 == 0)
{
    Console.WriteLine("El año es Bisiesto");
}
else
{
    Console.WriteLine("El año NO es Bisiesto");
}
~~~

## EJERCICIO 16

~~~
int a = 19, b=0;
if ((b != 0) && (a/b > 5)) Console.WriteLine(a/b);
~~~

EL problema radica en el operador lógico AND (&). Cuando es solo un caracter (&), el operador evalua siempre ambos operandos, ocurriendo que si b = 0, entonces retorne un error porque no se puede dividir por cero. Pero si colocamos doble operador (&&), se lo conoce como operador logico condicional y evalua en etapas: Si el primer operando es ciento, entonces procede a verificar el segundo, sino no lo verifica, evitando dividir por cero en nuestro ejemplo.


## EJERCICIO 17

~~~         
int a = 5, b = 6, c;
c = (a<b) ? a : b;
Console.WriteLine(c);
~~~


## EJERCICIO 18
   
~~~        
for (int i = 0; i <= 4; i++)
{
    string st2;
    string st1 = i < 3 ? i == 2 ? "dos" : i == 1 ? "uno" : "< 1" : i < 4 ? "tres" : "> 3";
    
    if (i < 3)
    {
        if (i == 2)
        {
            st2 = "dos";
        }
        else
        {
            if (i == 1)
            {
                st2 = "uno";
            }
            else
            {
                st2 = "< 1";
            }
        }
    }
    else
    {
        if (i < 4)
        {
            st2 = "tres";
        }
        else
        {
            st2 = "> 3";
        }
    }
    Console.WriteLine("Una linea: " + st1 + "| Anidada: " + st2);
}
// "<1"
// "uno"
// "dos"
// "tres"
// ">3"
~~~

Tambien se muestra la comparativa con la solución anidada de if(), else if() y else


## EJERCICIO 19
   

1. Valida. Las tres variables son creadas pero no inicializadas.
~~~
int a, b, c;
~~~
2. Valida. Las cuatro variables son creadas pero no inicializadas.
~~~
int a; int b; int c, d;
~~~
3. Valida. Las tres variables son creadas e inicializadas con los valores despues del igual para cada una.
~~~
int a = 1; int b = 2; int c = 3;
~~~
4. Valido. Las tres variables son creadas e inicializadas con el valor de 1.
~~~
int b; int c; int a = b = c = 1;
~~~
5. Valido. Las tres variables son creadas e inicializadas con el valor de 1.            
~~~
int c; int a, b = c = 1;
~~~
6. Valido. Las tres variables son creadas y, ***a*** queda iniclaizada con 2 y ***b*** y ***c*** quedan incializadas con 1.            
~~~
int c; int a = 2, b = c = 1;
~~~
7. Valido. Las cuatro variables son creadas. ***a*** es inicializada con 2, ***d*** con 4 las variables ***b*** y ***c*** no son inicializadas.
~~~
int a = 2, b , c , d = 2 * a;
~~~
8. Invalido. Si se coloca comas (,), la palabra ***int*** en la declaración de ***b*** y ***c*** son inecesarias. Si quiere dejarse las palabras ***int***, deben cambiarse las comas por punto y coma (;).
~~~
int a = 2, int b = 3 , int c = 4;
~~~
9. Invalido. Problema similar al anterior pero al contrario. Para arreglarlo debemos colocar la palabra ***int*** antes de la ***b*** y ***c*** o cambiar los puntos y coma por comas.
~~~
int a = 2; b = 3 ; char = 4;
~~~
10. Invalido. No podemos asignar a una variable el valor de una variable sin inicializar. No estamos asignando nada.
~~~
int a; int c = a;
~~~
11. Invalido. Dos variables de distinto tipo deben ser separadas por un punto y coma al ser creadas.
~~~
char c = 'A', string st = "Hola";
~~~
12. Valido. Las dos variables son creadas y la variable ***c*** se incializa con el caracter "A" y la variable ***st*** con el valor "Hola".
~~~
char c = 'A', string st = "Hola";
~~~
13. Invalido. Al poner una coma, le decimos al codigo que la variable ***st*** será de tipo char. No nos dejará asignar el valor "Hola" a una variable tipo char.
~~~
char c = 'A', st = "Hola";
~~~

## EJERCICIO 20

~~~
int i = 0;
for (int i = 1; i <= 10;)
{
    Console.WriteLine(i++);
}
~~~
El problema se haya en que la variable i esta siendo declarada 2 veces. Por lo que debemos eliminar una declaración o cambiarle el nombre. Tambien, se le esta asignando un valor 2 veces, una al incializarla y otra al definir el for, por lo que podemos trabajar mejor eso. 

* __Solución a):__ Solo declararla una vez
~~~
int i = 0;
for (i = 1; i <= 10;)
{
    Console.WriteLine(i++);
}
~~~
* __Solución b):__ Cambiarle el nombre al indice del for
~~~
int i = 0;
for (int j = 1; i <= 10;)
{
    Console.WriteLine(j++);
}
~~~
* __Solución c):__ Definirla e inicializarla dentro del ciclo
~~~
for ( int i = 1; i <= 10;)
{
    Console.WriteLine(i++);
}
~~~

## EJERCICIO 21

~~~              
int i = 1;
if(--i == 0){
    Console.WriteLine("Cero");
}
if(i++ == 0){
    Console.WriteLine("Cero");
}
Console.WriteLine(i);
~~~


En este caso, vemos como se ejecutan los operadores diferenciando los postfijos (x++) y los prefijos (++x).

* __Opeadores prefijos (++x):__ El resultado de ++x es el valor de x después de la operación, por eso --i == 0 es cierto, ya que la operación de resta se realiza y despues se verifica la igualdad con el cero.
* __Operadores postfijos (x++):__ El resultado de x++ es el valor de x antes de la operación, por eso i++ == 0 tambien es cierto, ya que primero evalua si i es igual a cero y despues la incrementa.
 
