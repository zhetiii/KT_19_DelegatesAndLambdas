using System;
using System.Collections.Generic;

namespace KT_19_DelegatesAndLambdas
{
    public class MessageProcessor
    {
        public void RunTeacherTests()
        {
            List<string> messages = new() { "hi", "привет", "ok", "до свидания" };
            List<string> historyList = new();

            // Лямбда-фильтр: длиннее 3 символов
            Func<string, bool> isLongEnough = str => !string.IsNullOrEmpty(str) && str.Length > 3;

            // Лямбда-преобразование: верхний регистр + префикс [LOG]
            Func<string, string> formatMessage = str => $"[LOG] {str.ToUpper()}";

            // Два лямбда-действия, объединённые через +=
            Action<string> printAction = msg => Console.WriteLine($"Вывод на экран: {msg}");
            Action<string> saveAction = msg => historyList.Add(msg);

            Action<string> combinedAction = printAction;
            combinedAction += saveAction;

            Console.WriteLine("--- Конвейер обработки сообщений ---");
            foreach (string msg in messages)
            {
                if (isLongEnough(msg))
                {
                    string result = formatMessage(msg);
                    combinedAction(result);
                }
            }

            Console.WriteLine($"\nСохранено элементов в истории: {historyList.Count}");
            Console.WriteLine($"История: {string.Join(" | ", historyList)}");
        }

        public void ProcessUserMessages(List<string> userMessages)
        {
            List<string> historyList = new();

            Func<string, bool> isLongEnough = str => !string.IsNullOrEmpty(str) && str.Length > 3;
            Func<string, string> formatMessage = str => $"[LOG] {str.ToUpper()}";

            Action<string> printAction = msg => Console.WriteLine($"[Вывод]: {msg}");
            Action<string> saveAction = msg => historyList.Add(msg);

            Action<string> combinedAction = printAction;
            combinedAction += saveAction;

            Console.WriteLine("\n--- Результат обработки ваших сообщений ---");
            foreach (string msg in userMessages)
            {
                if (isLongEnough(msg))
                {
                    string result = formatMessage(msg);
                    combinedAction(result);
                }
            }

            Console.WriteLine($"Всего подходящих сообщений сохранено: {historyList.Count}");
        }
    }
}