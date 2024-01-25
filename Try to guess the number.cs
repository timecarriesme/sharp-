using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool playagain = true;
            int totalWins = 0;
            int totalLosses = 0;

            while (playagain)
            {
                Random random = new Random();
                int pullnum = random.Next(1, 101);

                Console.WriteLine("Угадайте число от 1 до 100");
                int howmanytrys = GetNumberOfTries();
                bool pravotv = false;

                while (howmanytrys > 0 && !pravotv)
                {
                    Console.WriteLine("Попытка {0}: (Осталось {1} попытк{2})", GetCurrentAttemptText(howmanytrys), howmanytrys, GetEnding(howmanytrys));
                    int usernum;
                    if (int.TryParse(Console.ReadLine(), out usernum))
                    {
                        if (usernum == pullnum)
                        {
                            Console.WriteLine("Вы угадали");
                            pravotv = true;
                            totalWins++;
                        }
                        else if (usernum > pullnum)
                        {
                            Console.WriteLine("Загаданное число меньше");
                        }
                        else if (usernum < pullnum)
                        {
                            Console.WriteLine("Загаданное число больше");
                        }
                        howmanytrys--;
                    }
                    else
                    {
                        Console.WriteLine("Некорректное число, введите целое число");
                    }

                    if (Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        return;
                    }
                }

                if (!pravotv)
                {
                    Console.WriteLine("Вы проиграли. Загаданное число {0} ", pullnum);
                    totalLosses++;
                }

                Console.Write("Хотите сыграть еще раз? (Y/N): ");
                string playagainInput = Console.ReadLine();
                playagain = (playagainInput.ToLower() == "y");

                if (Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    return;
                }

                Console.Clear();
            }

            Console.WriteLine("Статистика игр:");
            Console.WriteLine("Побед: {0}", totalWins);
            Console.WriteLine("Поражений: {0}", totalLosses);
            Console.WriteLine("Нажмите Enter, чтобы закрыть программу");
            Console.ReadLine();
        }

        static int GetNumberOfTries()
        {
            Console.Write("Введите количество попыток: ");
            int numberOfTries;
            while (!int.TryParse(Console.ReadLine(), out numberOfTries) || numberOfTries <= 0)
            {
                Console.WriteLine("Некорректное число, введите положительное целое число");
                Console.Write("Введите количество попыток: ");
            }

            return numberOfTries;
        }

        static string GetCurrentAttemptText(int currentAttempt)
        {
            switch (currentAttempt)
            {
                case 1:
                    return "первая";
                case 2:
                    return "вторая";
                case 3:
                    return "третья";
                default:
                    return (currentAttempt + "ая");
            }
        }

        static string GetEnding(int number)
        {
            if (number % 10 == 1 && number != 11)
            {
                return "ка";
            }
            else if ((number % 10 == 2 || number % 10 == 3 || number % 10 == 4) && (number < 10 || number > 20))
            {
                return "ки";
            }
            else
            {
                return "ок";
            }
        }
    }
}
