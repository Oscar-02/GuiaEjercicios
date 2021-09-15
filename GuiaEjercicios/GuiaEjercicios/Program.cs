using System;
using System.Linq;

namespace GuiaEjercicios
{
    class Program
    {
        public static int[] numRead;

        static void Main(string[] args)
        {
            while (true)
            {
                numRead = new int[4];
                int oldmin = 0, oldmax = 0, max = 0, min = 0;
                Console.Clear();
                Menu();
                Read();
                (oldmax, oldmin, max, min) = Operate();
                Result(oldmax, oldmin, max, min);
            }
        }

        static void Result(int oldmax, int oldmin, int max, int min)
        {
            Console.Clear();
            Console.WriteLine("Los resultados son los siguientes: ");
            Console.WriteLine("\n Los datos ingresados: " + numRead[0] + " - " + numRead[1] + " - " + numRead[2] + " - " + numRead[3]);
            Console.WriteLine("\n Mayores y menores originales y condicionados (si aplica): ");
            Console.WriteLine("\n Mayor original: " + oldmax + ". Menor original: " + oldmin + ".");
            Console.WriteLine("Mayor condicional: " + max + ". Menor condicional: " + oldmin + ".");
            bool error = true;
            while (error)
            {
                Console.WriteLine("\n\n¿Deseas realizar una nueva consulta? Y (Si) - N (No)");
                char key = Console.ReadKey().KeyChar;
                switch (key)
                {
                    case 'y':
                        error = false;
                        break;
                    case 'n':
                        Environment.Exit(0);
                        break;
                    default:
                        error = true;
                        Console.WriteLine("Opcion no valida. Presiona una tecla para volver a intentar.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        static (int, int, int, int) Operate()
        {
            int oldmin = 0, oldmax = 0, max = 0, min = 0;
            oldmax = numRead.Max();
            oldmin = numRead.Min();

            if (oldmin > 10)
            {
                max = oldmax + 10;
            }
            else
            {
                max = oldmax;
            }
            if (oldmax < 50)
            {
                min = oldmin - 5;
            }
            else
            {
                min = oldmin;
            }
            return (oldmax, oldmin, max, min);
        }

        static void Read()
        {
            for (int i = 0; i < 4; i++)
            {
                bool error = true;
                while (error)
                {
                    Console.Clear();
                    Console.WriteLine("Ingrese el valor del " + (i + 1) + "° numero.");
                    try
                    {
                        numRead[i] = int.Parse(Console.ReadLine());
                        error = false;
                        
                    }
                    catch (FormatException err)
                    {
                        error = true;
                        Console.WriteLine("\n El valor ingresado no es valido (" + err.Message + ")." +
                            "\nVuelvelo a intentar presionando cualquier tecla. Recuerda que deben ser valores numericos");
                        Console.ReadKey();
                    }
                    if (numRead[i] <= 0 && !error)
                    {
                        error = true;
                        Console.WriteLine("\n El valor ingresado no es valido (value less or equal than zero - 0 -)." +
                            "\nVuelvelo a intentar presionando cualquier tecla. Recuerda que deben ser valores > QUE 0");
                        Console.ReadKey();
                    }
                }
            }
            int cond = 0, sum = 0;
            foreach (int element in numRead)
            {
                sum += element;
                if (element == numRead[0])
                {
                    cond++;
                }
                if (element == numRead[1])
                {
                    cond++;
                }
                if (element == numRead[2])
                {
                    cond++;
                }
                if (element == numRead[3])
                {
                    cond++;
                }
            }
            if (cond > 5)
            {
                Console.WriteLine("Ocurrio un error (there are two or more values that are the same)" +
                    "\nVuelve a intentarlo presionando una tecla. Recuerda que no se deben REPETIR los valores.");
                Console.ReadKey();
                Read();
            }
            else if (sum > 200)
            {
                Console.WriteLine("Ocurrio un error (the addition of all values gives a value more than 200)" +
                    "\nVuelve a intentarlo presionando una tecla. Recuerda que la suma de los valores debe dar < QUE 200.");
                Console.ReadKey();
                Read();
            }
        }

        static void Menu()
        {
            Console.WriteLine("Bienvenido. Se solicitaran 4 numeros enteros (decimales se aproximaran)\n" +
                "y tienen que cumplir las siguientes condiciones:\n" +
                "1. No deben ser menores o iguales a 0 (NO <= 0)\n" +
                "2. Si la suma de los 4 numeros se obtiene un total igual o mayor a 200 se solicitaran " +
                "de nuevo los enteros\n" +
                "3. Si el MENOR es mayor a 10, se le sumara 10 al MAYOR\n" +
                "4. Si el MAYOR es menor que 50, se le restara 5 al MENOR)\n" +
                "5. No deben existir valores iguales\n\n" +
                "Para continuar, presiona cualquier tecla.");
            Console.ReadKey();
        }
    }
}
