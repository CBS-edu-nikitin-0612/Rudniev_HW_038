using System;

namespace aditionalTask
{
    class Program
    {
        static void Main(string[] args)
        {
            using (new SomeClass())
            {
                Console.WriteLine("some work....");
            }

            Console.ReadKey();
        }
    }
}
