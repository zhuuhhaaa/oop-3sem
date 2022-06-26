using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace _8
{
    public interface ICollectionType<T> 
    {
        void Add(T myList);
        void Insert(int index, T myList);
        void RemoveAt(int index);
        void Clear();
        void Show();
        
    }

    public class CollectionType<T> : ICollectionType<T> 
    {
        private List<T> list = new List<T> { };
        static int count = 0;

        public void Add(T myList)
        {
            list.Add(myList);
            count++;
        }

        public void Insert(int index, T myList)
        {
            if (index > list.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Out of range");
            }
            list.Insert(index, myList);
            count++;
        }

        public T this[int index]
        {
            get
            {
                if (index > list.Count || index < 0)
                {
                    throw new Exception("Out of range");
                }

                return list[index];
            }
            set
            {
                if (index > list.Count || index < 0)
                {
                    throw new Exception("Out of range");
                }
                list[index] = value;
            }
        }

        public void Show()
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write("{0}\t", list[i]);
            }
            Console.WriteLine();
        }

        public void Print()
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]) ;
            }
            Console.WriteLine();

        }

        public void Clear()
        {
            list.Clear();
            count = 0;
        }

        public void RemoveAt(int index)
        {
            if (index > list.Count || index < 0)
            {
                throw new Exception("Out of range");
            }
            list.RemoveAt(index);
            count--;
        }
        
        public void SerializeAndSave()
        {
            using (FileStream fs = new FileStream("notes.json", FileMode.OpenOrCreate))
            {
            for (int i = 0; i < list.Count; i++)
            {
                JsonSerializer.SerializeAsync<T>(fs, list[i]);
            }
            Console.WriteLine("Data has been saved to file");
            }
        }
    }

    public abstract class Plant
    {
        public int couttlepeskov;
        public override string ToString() => "Plant";
        public string name;

        public virtual void Pour(int litters)
        {
            Console.WriteLine($"Вы полили растение {litters} литрами воды");
        }
        public abstract void ToPlant();
        public void GetPlants() => Console.WriteLine($"Тип объекта: {GetType()} растение вида {ToString()}");
    }

    public class Flower : Plant
    {
        public Flower() { }
        public Flower(string _name, int _count)
        {
            name = _name;
            couttlepeskov = _count;
        }
        public override string ToString() => "Flower";
        public override void ToPlant() => Console.WriteLine("Вы посадили цветок");
        public void Vyanyt()
       =>
           Console.WriteLine($"Завял {ToString()}");

        public void Tsvesti()
       =>
           Console.WriteLine($"Расцвел {ToString()}");
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var collectionString = new CollectionType<string> { };

                collectionString.Add("first");
                collectionString.Add("second");
                collectionString.Add("third");
                collectionString.Show();

                collectionString.RemoveAt(2);

                Console.WriteLine(new string('-', 50));
                collectionString.Show();
                Console.WriteLine();

                var collectionAuthor = new CollectionType<Flower> { };

                collectionAuthor.Add(new Flower("Rose", 6));
                collectionAuthor.Add(new Flower("Gladiolus",4));

                collectionAuthor.Print();

                var collectionObj = new CollectionType<object> { };

                collectionObj.Add(12);
                collectionObj.Add(16);
                collectionObj.Add(18);

                collectionObj.Show();

                Console.WriteLine(new string('-', 50));

                collectionObj.Insert(2, 20);
                collectionObj.Show();

                collectionAuthor.SerializeAndSave();

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("\n\nEnd.");
            }
        }
    }
}
