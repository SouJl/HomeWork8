using System;
using System.Reflection;

namespace ReflectionProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=====================================================");
            Console.WriteLine("Мельников Александр. Практическая работа 8, задание 1");
            Console.WriteLine("=====================================================");
            
            Console.WriteLine();
            Console.WriteLine("Структура DateTime:");
            Console.WriteLine();
            DateTime dateTime = new DateTime();
            foreach(var property in dateTime.GetType().GetProperties()) 
            {
                Console.WriteLine($"{property.Name} = {property.GetValue(dateTime)}");
            }
            Console.ReadKey();
        }
    }
}
