using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace Lab_10
{
    public class Worker : IEnumerable
    {
        public override string ToString() => "Plant";
        public string name;
        public string days;
        public Worker(string _name, string _days)
        {
            name = _name;
            days = _days;
        }
     

        public IEnumerator GetEnumerator()
        {
            return days.GetEnumerator();
        }
    }

    public class OwnCollection
    {
        public HashSet<Worker> Workers;

        public OwnCollection()
        {
            Workers = new HashSet<Worker>();
        }

        public void Delete(Worker item)
        {
            Workers.Remove(item);
        }
        public void Add(Worker item)
        {
            Workers.Add(item);
        }
    }

    class Program
    {

        static void Main(string[] args)
        {

            Worker worker1 = new Worker("Petr", "Thursday");
            Worker worker2 = new Worker("Alex", "Wednesday" );
            Worker worker3 = new Worker("Gosha", "Tuesday");
            Worker worker4 = new Worker("Petr", "Thursday");
            foreach (var day in worker1)
            {
                Console.WriteLine(day);
            }
            OwnCollection own = new OwnCollection();
            own.Add(worker1);
            own.Add(worker2);
            own.Add(worker3);
            Console.WriteLine("Вывод: ");
            foreach (Worker item in own.Workers)
            {
                Console.WriteLine(item.name +" "+ item.days);
            }
            own.Delete(worker1);
            Console.WriteLine("Вывод: после удаления");
            foreach (Worker item in own.Workers)
            {
                Console.WriteLine(item.name + " " + item.days);
            }
            //-------------------------------------------
            HashSet<int> Set = new HashSet<int>();
            for (int i = 0; i < 10; i++)
                Set.Add(i);
            Console.WriteLine("Вывод сета: ");
            foreach (int item in Set)
            {
                Console.Write(item + " ");
            }
            for (int i = 3; i < 5; i++)
                Set.Remove(i);
            Console.WriteLine();
            Console.WriteLine("Вывод сета после удаления 2 элементов: ");
            foreach (int item in Set)
            {
                Console.Write(item + " ");
            }
            int[] a1 = new int[Set.Count()];
            a1 = Set.ToArray();
            Stack<int> Stack1 = new Stack<int>();
            for (int i = 0; i < Set.Count(); i++)
                Stack1.Push(a1[i]);
            Console.WriteLine();
            Console.WriteLine("Вывод стека с элементами из сета: ");
            foreach (object i in Stack1)
                Console.Write(i + " ");
            Console.WriteLine();


            ObservableCollection<Worker> Col = new ObservableCollection<Worker>();
            Col.CollectionChanged += Obs_CollectionChanged;
            Col.Add(worker1);
            Col.Add(new Worker("Sanek", "Monday"));
            Col.Remove(worker1);
            foreach (Worker item in Col)
            {
                Console.WriteLine(item.name);
            }
        }
        private static void Obs_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Элемент добавлен ");
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Элемент удален ");
            }
            else
            {
                Console.WriteLine("Нет добавленных/удаленных элементов");
            }
        }
    }
}