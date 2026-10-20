using System;
using System.Collections.Generic;

namespace KT_19_DelegatesAndLambdas
{
    public class NumberProcessor
    {
        public void RunTeacherTests()
        {
            List<int> numbers = new() { 1, 2, 3, 4, 5, 6 };
            List<int> savedResults = new();

            // Лямбда-фильтр: чётные числа
            Func<int, bool> isEven = x => x % 2 == 0;

            // Лямбда-преобразование: квадрат числа
            Func<int, int> square = x => x * x;

            // Два лямбда-действия, объединённые через +=
            Action<int> printAction = res => Console.WriteLine($"Вывод на экран: {res}");
            Action<int> saveAction = res => savedResults.Add(res);

            Action<int> combinedAction = printAction;
            combinedAction += saveAction;

            Console.WriteLine("--- Конвейер обработки чисел ---");
            foreach (int number in numbers)
            {
                if (isEven(number))
                {
                    int result = square(number);
                    combinedAction(result);
                }
            }

            Console.WriteLine($"\nСохранено элементов в списке: {savedResults.Count}");
            Console.WriteLine($"Сохранённые элементы: {string.Join(", ", savedResults)}");
        }

        public void ProcessUserNumbers(List<int> userNumbers)
        {
            List<int> savedResults = new();

            Func<int, bool> isEven = x => x % 2 == 0;
            Func<int, int> square = x => x * x;

            Action<int> printAction = res => Console.WriteLine($"[Вывод]: {res}");
            Action<int> saveAction = res => savedResults.Add(res);

            Action<int> combinedAction = printAction;
            combinedAction += saveAction;

            Console.WriteLine("\n--- Результат обработки вашего списка чисел ---");
            foreach (int number in userNumbers)
            {
                if (isEven(number))
                {
                    int result = square(number);
                    combinedAction(result);
                }
            }

            Console.WriteLine($"Всего чётных чисел обработано и сохранено: {savedResults.Count}");
        }
    }
}