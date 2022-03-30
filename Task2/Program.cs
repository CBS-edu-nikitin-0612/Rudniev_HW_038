using System;
using System.Threading;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoryWatcher memoryWatcher = new MemoryWatcher(100000, 1000000, 500);
            memoryWatcher.Start();

            object obj1 = (object)new byte[10000];
            Thread.Sleep(1000);

            object obj2 = (object)new byte[100000];
            Thread.Sleep(1000);

            object obj3 = (object)new byte[1000000];
            Thread.Sleep(1000);

            Console.ReadKey();
        }
    }
}
