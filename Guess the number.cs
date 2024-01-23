using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int randomization = random.Next(1, 11); 

            int usertry;
            int trycount = 0;

            Console.WriteLine("Угадайте число от 1 до 10!");

            while (true)
            {
                Console.Write("Введите ваш ответ: ");
                usertry = int.Parse(Console.ReadLine());

                trycount++;

                if (usertry == randomization)
                {
                    Console.WriteLine("Поздравляем, вы угадали число!");
                    break;
                }
                else if (usertry < randomization)
                {
                    Console.WriteLine("Загаданное число больше вашей догадки.");
                }
                else
                {
                    Console.WriteLine("Загаданное число меньше вашей догадки.");
                }
            }
            

            Console.WriteLine($"Количество попыток: {trycount}");
            Console.ReadLine();
        }
    }
}
