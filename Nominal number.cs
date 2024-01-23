using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nominalnumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первое число: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе число: ");
            int num2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите третье число: ");
            int num3 = int.Parse(Console.ReadLine());

            if (num1 >= num2 && num1 <= num3 || num1 >= num3 && num1 <= num2)
                Console.WriteLine(num1);
            else if (num2 >= num1 && num2 <= num3 || num2 >= num3 && num2 <= num1)
                Console.WriteLine(num2);
            else 
                Console.WriteLine(num3);

            Console.Write("Нажмите Enter для завершения работы программы.");
            while (Console.ReadKey().Key != ConsoleKey.Enter) {}
        }
    }
}
