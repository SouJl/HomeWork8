using System;
using System.Reflection;

namespace ReflectionProject
{
    class Program
    {
        static void Main(string[] args)
        { 
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
