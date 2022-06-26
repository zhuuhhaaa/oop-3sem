using System;
using System.Diagnostics;
using System.Threading;
using static Lab_15.Methods;

namespace Lab_15
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Инфо Процессов:");
            var allProcesses = Process.GetProcesses();
            Console.Write("{0,-10}", "ID:");
            Console.Write("{0,-40}", "Process Name:");
            Console.Write("{0,-10}", "Priority:\n");
            foreach (var process in allProcesses)
            {
                Console.Write("{0,-10}", $"{process.Id}");
                Console.Write("{0,-40}", $"{process.ProcessName}");
                Console.Write("{0,-10}", $"{process.BasePriority}");
                Console.WriteLine();
            }

            Console.WriteLine("Инфо домена:");
            var thisAppDomain = Thread.GetDomain();

            Console.WriteLine($"\n\n\nName:  {thisAppDomain.FriendlyName}");
            Console.WriteLine($"Setup Information:  {thisAppDomain.SetupInformation.ToString()}");
            Console.WriteLine("Assemblies:");

            foreach (var item in thisAppDomain.GetAssemblies())
            {
                Console.WriteLine("    " + item.FullName.ToString());
            }

            Console.WriteLine("Задание 3");
            Mutex mutex = new Mutex();
            Thread NumbersThread = new Thread(new ParameterizedThreadStart(WriteNums));
            NumbersThread.Start(7);

            Thread.Sleep(2000);
            mutex.WaitOne();

            Console.WriteLine("\n--------------------");
            Console.WriteLine("Приоритет:   " + NumbersThread.Priority);
            Thread.Sleep(100);
            Console.WriteLine("Имя потока:  " + NumbersThread.Name);
            Thread.Sleep(100);
            Console.WriteLine("ID потока:   " + NumbersThread.ManagedThreadId);
            Console.WriteLine("---------------------");
            Thread.Sleep(1000);

            mutex.ReleaseMutex();
            Thread.Sleep(2000);


            void WriteNums(object number)     
            {
                int num = (int)number;
                for (int i = 0; i < num; i++)
                {
                    Console.WriteLine(i);
                    Thread.Sleep(500);
                }
            }


            Console.WriteLine("СНАЧАЛА НЕЧЕТНЫЕ, ПОТОМ ЧЕТНЫЕ:");
            DoItConsistently();
            Thread.Sleep(4000);

            Console.WriteLine("\nОДНО НЕЧЕТНОЕ, ОДНО ЧЕТНОЕ:");
            DoItOneByOne();
            Thread.Sleep(4000);

            TimerCallback timerCallback = new TimerCallback(WhatTimeIsIt);
            Timer timer = new Timer(timerCallback, null, 0, 1000);
            Thread.Sleep(5000);

            void WhatTimeIsIt(object obj)
            {
                Console.WriteLine($"It's {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}");
            }
        }
    }
}
