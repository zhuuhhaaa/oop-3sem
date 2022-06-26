using System;

namespace SharpForRepet
{
    
    public class Set
    {
        public Set()
        {
            arr = null;
            count = 0;
            size = -1;
            max = 0;
            min = 0;
            owner = new Owner(6, "Unnamed");
            creationDate = new Date();
            creationDate.day=DateTime.Now.Day;
            creationDate.month = DateTime.Now.Month;
            creationDate.year = DateTime.Now.Year;

        }
        
        public Set(int[] _arr, int _count, int _size)
        {
            arr = _arr;
            count = _count;
            size = _size;
            if (count > 0)
            {
                max = arr[0];
                min = arr[0];
                for (int i = 0; i < count; i++)
                {
                    if (max < arr[i])
                    {
                        max = arr[i];
                    }
                    if (min > arr[i])
                    {
                        min = arr[i];
                    }
                }
            }
        }
        
        private int[] arr;
        public void SetArr(int[] arrnew, int count, int size)
        {
            arr = arrnew;
            this.count = count;
            this.size = size;
            

        }
        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        private int size;
        private int max;
        public int Max
        {
            get { return max; }
        }
        private int min;
        public int Min
        {
            get { return min; }
        }
        public class Owner
        {
            private int id;
            private string organization;
            public Owner(int _id, string _organization)
            {
                id = _id;
                organization = _organization;
            }


            public void SetOwner(int _id, string _organization)
            {
                id = _id;
                organization = _organization;
            }
            public void Getinfo()
            {
                Console.WriteLine($"Owner ID - {id}, Organisation - {organization}");
            }
        }
        public Owner owner;
        public class Date
        {
            public int day;
            public int month;
            public int year;

            public void Getinfo()
            {
                Console.WriteLine($"Дата создания {day}.{month}.{year}") ;
            }

        }
        private Date creationDate;

        public Date CreationDate
            {
            get { return creationDate; } 
            }
        
       
        public int this[int index]
        {
            get
            {
                return arr[index];
            }
            set
            {
                arr[index] = value;
            }
        }
        public static Set operator *(Set a, Set b)
        {
           
            return new Set { count = a.count * b.count};
        }
        public static Set operator +(Set a, Set b)
        { 

            return new Set { count = a.count + b.count};
        }
        public static Set operator &(Set a, Set b)
        {   
            return new Set { count = a.count & b.count };
        }
    }
    public static class StaticOperation
    {
        public static int SumBetwMaxAndMin(this Set o)
        {
            int result = o.Max + o.Min;
            return result;
        }
        public static int DifBetwMaxAndMin(this Set o)
        {
            return o.Max - o.Min;
        }
        public static int CountOfElements(this Set o)
        {
            return o.Count;
        }
        public static string AddPointToStringEnd(this string o)
        {
            int a = 0;
            for (int i = 1; i < o.Length; i++)
            {
                if( o.Contains("?"))
                {
                    o = o.Remove(i, i);
                    a++;
                }

            }
            Console.WriteLine("a = " + a);
            return o;
        }
        public static void ErraseZeroValues(this Set o)
        {
            int[] arr1 = new int[o.Count];
            int count = 0;
            for (int i = 0; i < o.Count; i++)
            {
                if (o[i] != 0)
                {
                    arr1[count] = o[i];
                    count++;
                }
            }
            o.SetArr(arr1, count, count);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Set.Date date = new Set.Date();
            date.day = 8;
            date.month = 10;
            date.year = 2021;
            date.Getinfo();

            Set creation = new Set();
            int d = creation.CreationDate.day;
            int m = creation.CreationDate.month;
            int y = creation.CreationDate.year;
            Console.WriteLine($"Сегодня {d}.{m}.{y}");

            Set set1 = new Set();
            int[] arr1 = { 1, 2, 3, 4, 5 };
            set1.SetArr(arr1, 5, 5);

            Set set2 = new Set();
            int[] arr2 = { 5, 6, 0, 9, 7 };
            set2.SetArr(arr2, 5, 5);

            Set.Owner owner1 = new Set.Owner(4,"BSTU");
            owner1.Getinfo();

            set1.owner.Getinfo();
            string str = "Hello?";
            str = StaticOperation.AddPointToStringEnd(str);
            Console.WriteLine(str);

            int sum = StaticOperation.SumBetwMaxAndMin(set1);
            Console.WriteLine($"Сумма наибольшего и наименьшего: {sum}");
            int minmax = StaticOperation.DifBetwMaxAndMin(set1);
            Console.WriteLine($"Макс значение - мин {minmax}");
            int count = StaticOperation.CountOfElements(set2);
            Console.WriteLine(count);
            set1.SumBetwMaxAndMin();
            StaticOperation.ErraseZeroValues(set2);
            Set c = set1 + set2;
            Console.WriteLine(set1.Count);
            Console.WriteLine(c.Count);
        } 
    }
}

