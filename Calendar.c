using System;
using System.Collections.Generic;

class CalendarEvent
{
    public string Title { get; set; }
    public DateTime Date { get; set; }
}

class Program
{
    static Dictionary<DateTime, List<CalendarEvent>> calendar = new Dictionary<DateTime, List<CalendarEvent>>();

    static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1. Просмотр событий");
            Console.WriteLine("2. Добавить событие");
            Console.WriteLine("3. Выйти");

            Console.WriteLine("Выберите действие: ");

            string choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    ViewEvents();
                    break;
                case "2":
                    AddEvent();
                    break;
                case "3":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Ошибка. Неверный выбор.");
                    break;
            }
            Console.WriteLine();
        }
    }

    static void ViewEvents()
    {
        Console.WriteLine("Введите дату для просмотра событий (ГГГГ-ММ-ДД): ");
        string inputDate = Console.ReadLine();
        DateTime date;

        if (DateTime.TryParse(inputDate, out date))
        {
            if (calendar.ContainsKey(date))
            {
                Console.WriteLine($"События на {date.ToShortDateString()}:");

                List<CalendarEvent> events = calendar[date];
                foreach (CalendarEvent evt in events)
                {
                    Console.WriteLine($"{evt.Title} - {evt.Date.ToShortTimeString()}");
                }
            }
            else
            {
                Console.WriteLine("На данную дату нет событий.");
            }
        }
        else
        {
            Console.WriteLine("Неверный формат даты.");
        }
    }

    static void AddEvent()
    {
        Console.WriteLine("Введите дату и время события (ГГГГ-ММ-ДД ЧЧ:ММ): ");
        string inputDateTime = Console.ReadLine();
        DateTime dateTime;

        if (DateTime.TryParse(inputDateTime, out dateTime))
        {
            Console.WriteLine("Введите название события: ");
            string title = Console.ReadLine();

            CalendarEvent newEvent = new CalendarEvent
            {
                Title = title,
                Date = dateTime
            };

            if (calendar.ContainsKey(dateTime.Date))
            {
                calendar[dateTime.Date].Add(newEvent);
            }
            else
            {
                List<CalendarEvent> events = new List<CalendarEvent> { newEvent };
                calendar[dateTime.Date] = events;
            }
            Console.WriteLine("Событие успешно добавлено.");
        }
        else
        {
            Console.WriteLine("Неверный формат даты и времени.");
        }
    }
}
