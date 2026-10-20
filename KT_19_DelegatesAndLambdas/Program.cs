using System;
using System.Collections.Generic;

namespace KT_19_DelegatesAndLambdas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("==================================================");
            Console.WriteLine("  КТ №19: Делегаты и лямбды (Варианты 1 и 2)     ");
            Console.WriteLine("==================================================\n");

            NumberProcessor numberProcessor = new();
            MessageProcessor messageProcessor = new();

            Console.WriteLine("=== 1. Проверка Варианта 1 (Числа) ===");
            numberProcessor.RunTeacherTests();

            Console.WriteLine("\n=== 2. Проверка Варианта 2 (Сообщения) ===");
            messageProcessor.RunTeacherTests();

            Console.WriteLine("\n=== 3. Интерактивный ручной ввод ===");

            Console.WriteLine("\n--- Ввод чисел ---");
            List<int> userNumbers = ConsoleInputHelper.ReadIntList();
            numberProcessor.ProcessUserNumbers(userNumbers);

            Console.WriteLine("\n--- Ввод сообщений ---");
            List<string> userMessages = ConsoleInputHelper.ReadStringList();
            messageProcessor.ProcessUserMessages(userMessages);

            Console.WriteLine("\nПрограмма завершена.");
        }
    }
}