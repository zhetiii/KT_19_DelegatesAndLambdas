using System;
using System.Collections.Generic;

namespace KT_19_DelegatesAndLambdas
{
    public static class ConsoleInputHelper
    {
        public static List<int> ReadIntList()
        {
            List<int> numbers = new();
            Console.WriteLine("Введите целые числа (для завершения нажмите Enter или введите 'stop'):");

            while (true)
            {
                try
                {
                    Console.Write($"Число #{numbers.Count + 1}: ");
                    string input = Console.ReadLine()?.Trim();

                    if (string.IsNullOrEmpty(input) || input.Equals("stop", StringComparison.OrdinalIgnoreCase))
                    {
                        if (numbers.Count == 0) throw new ArgumentException("Список не может быть пустым.");
                        break;
                    }

                    if (!int.TryParse(input, out int number))
                    {
                        throw new FormatException($"Значение '{input}' не является целым числом.");
                    }

                    numbers.Add(number);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Ошибка]: {ex.Message} Повторите ввод.");
                }
            }
            return numbers;
        }

        public static List<string> ReadStringList()
        {
            List<string> messages = new();
            Console.WriteLine("Введите строки (для завершения введите 'stop'):");

            while (true)
            {
                try
                {
                    Console.Write($"Строка #{messages.Count + 1}: ");
                    string input = Console.ReadLine()?.Trim();

                    if (input != null && input.Equals("stop", StringComparison.OrdinalIgnoreCase))
                    {
                        if (messages.Count == 0) throw new ArgumentException("Список не может быть пустым.");
                        break;
                    }

                    messages.Add(input ?? string.Empty);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Ошибка]: {ex.Message} Повторите ввод.");
                }
            }
            return messages;
        }
    }
}