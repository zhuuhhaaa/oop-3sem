using System;
using System.Collections.Generic;
using lab9;

namespace lab9
{
    public class Director
    {
        public delegate void RemoveDelegate(string message, List<Student> labs);
        public delegate void MutateDelegate(string message, List<Student> labs);
        public event RemoveDelegate UppZp;
        public event MutateDelegate Shtraf;
        public Director(List<Student> studs)
    {
            Studs = studs;
        }
        public List<Student> Studs { get; private set; }
        public void Upp(List<Student> _studs)
        {
            foreach (Student elem in _studs) { elem.Zp = elem.Zp + 100;}
            UppZp?.Invoke($"Students added",_studs);
        }

        public void RemoveLabs(List<Student> _studs)
        {
            foreach (Student elem in _studs) { elem.Zp = elem.Zp - 150; if (elem.Zp < 0) elem.Zp = 0; }
            Shtraf?.Invoke($"Student were fined", _studs);
        }
    }

    public class Student
    {
        public Student(string _name, int _zp)
        {
            name = _name;
            zp = _zp;
        }
        public Student() { }

        private string name;
        public string Name { get { return name; } set { name = value; } }
        private int zp;
        public int Zp { get { return zp; } set { zp = value; } }


        public static void ShowStudents(List<Student> list, int n)
        {
            for(int i=0;i<n;i++)
            {
                Console.WriteLine("Student " + list[i].Name + " zp = " + list[i].Zp);
            }

        }

    }


    }
    class Program
    {

        public delegate int Oper(int x, int y);
        static void Main(string[] args)
        {
            Oper sum = (x, y) => x + y;
            Oper mult = (x, y) => x * y;
            Console.WriteLine($"Сумма через лямбду: { sum(5, 5) }\n");
            Console.WriteLine($"Умножение через лямбду: { mult(5, 5) }\n");

            List<Student> list1 = new List<Student>() { new Student("Polyakov", 200), new Student("Rybakov", 180) ,new Student("Minin", 500) };
            List<Student> list2 = new List<Student>() { new Student("Alexeev", 250), new Student("Zhykov", 230), new Student("Zybrevich", 280) };
            List<Student> list3 = new List<Student>() { new Student("Makeev", 780), new Student("Leghovskii",160), new Student("Bereev", 290) };
            Director diric = new Director(list1);

            diric.UppZp += RemoveMessage;
            diric.Shtraf += Message;
            diric.Shtraf += MutateMessage;

            diric.Upp(list2);
            foreach (Student elem in list2) { Console.WriteLine(elem.Name+" --- " +elem.Zp ); }
            Console.WriteLine();


            diric.RemoveLabs(list3);
            foreach (Student elem in list3) { Console.WriteLine(elem.Name + " --- " + elem.Zp); }
            Console.WriteLine();

            Console.WriteLine("Вывод студентов:");
            foreach (Student elem in diric.Studs) { Console.WriteLine(elem.Name + " --- " + elem.Zp); }

            Func<string, string> textRedact;

            string myString = "    Hello, My Dear, Friend  ";
            Console.WriteLine(myString);

            textRedact = RemoveSpaces;
            myString = textRedact(myString);
            Console.WriteLine(myString);

            textRedact += RemoveCommas;
            myString = textRedact(myString);
            Console.WriteLine(myString);

            textRedact = ToLowerCase;
            myString = textRedact(myString);
            Console.WriteLine(myString);

            textRedact = ToUpperCase;
            myString = textRedact(myString);
            Console.WriteLine(myString);

            Console.Read();


        }

   
    private static void RemoveMessage(string message, List<Student> list)
        {
            Console.WriteLine($"Уволить 1-го ");
            list.RemoveAt(0);
        }

        private static void MutateMessage(string message, List<Student> list)
        {
            Console.WriteLine($"Список был перемешан!");
            list.Reverse();
        }

        private static void Message(string message, List<Student> list)
        {
            Console.WriteLine(message);

        }

        private static string RemoveCommas(string message)
        {
            message = message.Replace(",", "");
            return message;
        }
        private static string RemoveSpaces(string message)
        {
            message = message.Trim();
            return message;
        }

        private static string ToUpperCase(string message)
        {
            message = message.ToUpper();
            return message;
        }

        private static string ToLowerCase(string message)
        {
            message = message.ToLower();
            return message;
        }
    }
