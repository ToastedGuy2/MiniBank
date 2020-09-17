using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            object value = 3500;
            string valueToString = value as string;
            double amount = 0;
            var result = Double.TryParse(valueToString,out amount);
            Console.WriteLine("Test complete");
        }    
    }
}