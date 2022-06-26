using System;
using System.Diagnostics;

namespace _6laba
{
    enum Color : uint
    {
        RED = 1,
        ORANGE,
        YELLOW,
        GREEN,
        SKYBLUE=56,
        BLUE,
        PURPLE
    }
    interface IFlower
    {
        void Tsvesti();
        void Vyanyt();

    }

    interface IPaper
    {
        void PackIn();
    }

    interface ICactus
    {
        void PutInPot();
        void ToPlant();
    }
    struct Typeofplant
    {
        public string nameofplant;
        public int numberofplants;
        public Typeofplant(string _name)
        {
            nameofplant = _name;
            numberofplants = 8;
        }

        public static void PackIn()
        {
            throw new NotImplementedException();
        }
    }

    abstract class Plant
    {
        
        protected int numOfPlants = 0;
        public override string ToString() => "Plant";

        public virtual void Pour(int litters)
        {
            Console.WriteLine($"Вы полили растение {litters} литрами воды");
        }
        public abstract void ToPlant();
        public void GetPlants() => Console.WriteLine($"Всего {numOfPlants} растений вида {ToString()}");
    }

    sealed class Bush : Plant
    { 
        public override string ToString() => "Bush";
        public override void ToPlant() => Console.WriteLine("Вы посадили куст", numOfPlants += 1);

    }

    partial class Flower : Plant, IFlower
    {
        public string color;
        public int price;
        public void Vyanyt()
       =>
           Console.WriteLine($"Завял {ToString()}");

        public void Tsvesti()
       =>
           Console.WriteLine($"Расцвел {ToString()}");
        public void Color(Color value)
        {
            switch (value)
            {
                case _6laba.Color.RED:
                    Console.WriteLine("Красный цветок");
                    break;
                case _6laba.Color.YELLOW:
                    Console.WriteLine("Желтый цветок");
                    break;
                case _6laba.Color.ORANGE:
                    Console.WriteLine("Оранжевый цветок");
                    break;
                case _6laba.Color.SKYBLUE:
                    Console.WriteLine("Небесно-голубой цветок");
                    break;
                case _6laba.Color.BLUE:
                    Console.WriteLine("Голубой цветок");
                    break;
                case _6laba.Color.PURPLE:
                    Console.WriteLine("Желтый цветок");
                    break;
                case _6laba.Color.GREEN:
                    Console.WriteLine("Зеленый цветок");
                    break;

            }
        }
    }

    class Cactus : Flower, ICactus
    {
        public override string ToString() => "Cactus";
        public override void ToPlant() => Console.WriteLine("Вы посадили кактус (abstract)", numOfPlants += 1);
        void ICactus.ToPlant() => Console.WriteLine("Вы посадили кактус (interface)", numOfPlants += 1);
        public void Collect() => Console.WriteLine("Вы собрали кактус");
        public void PutInPot() => Console.WriteLine("Вы поместили кактус в горшок");

    }

    class Rose : Flower, IPaper, IFlower
    {   public Rose(string _color,int _price)
        {
            color = _color;
            price = _price;
        }
        public override string ToString() => "Rose";
        public override void ToPlant() => Console.WriteLine("Вы посадили розу", numOfPlants += 1);
        public void Collect() => Console.WriteLine("Вы собрали букет роз");
        public void PackIn() => Console.WriteLine("Вы обернули букет в бумагу");
        
    }

    class Gladiolus : Flower, IPaper
    {
        public Gladiolus(string _color, int _price)
        {
            color = _color;
            price = _price;
        }
        public override string ToString() => "Gladiolus";
        public override void ToPlant() => Console.WriteLine("Вы посадили гладиолус", numOfPlants += 1);
        public void Collect() => Console.WriteLine("Вы собрали букет из гладиолусов");
        public void PackIn() => Console.WriteLine("Вы обернули букет в бумагу");
    }

    class Byket
    {
        public Byket()
        {
            arr = null;
            count = 0;
        }
        public Byket(Flower[] _arr, int _count)
        {
            arr = _arr;
            count = _count;
            
        }
        
        public void InsertFlowers(Flower[] _arr, int _count)
        {
            arr = _arr;
            count = _count;
        }
        public bool CheckFlowerByColor(string color)
        {
            for(int i = 0; i<count; i++)
            {
                if (arr[i].color == color)
                {
                    return true;
                }
            }
            return false;
        }
        public void AddFlower(Flower o)
        {
            
                Flower[] arrnew = new Flower[count + 1];
                for (int i = 0; i < count; i++)
                {
                    arrnew[i] = arr[i];

                }
                arrnew[count] = o;
                count++;
                arr = arrnew;
                Console.WriteLine("Added");
            
        }

        public void ShowByket()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Букет из: {arr[i]}");
            }
        }

        Flower[] arr;
        int count;

        public Flower this[int index]
        {
            get
            {
                return arr[index];
            }
            set
            {
                if (index > count || index < 0)
                {
                    throw new Exception("Out of range");
                }
                else
                {
                    bool isCorrectColor = false;
                    for (int i = 0; i < 15; i++)
                    {
                        if (colors[i] == value.color)
                        {
                            isCorrectColor = true;
                        }
                    }
                    if (!isCorrectColor)
                    {
                        throw new Exception("Unknown color added");
                    }
                    else
                    {
                        arr[index] = value;
                    }
                }
            }
        }
        static string[] colors = { "", "purple", "red", "black", "white", "зеленый", "черный", "ярко красный", "коричневый", "green", "желтый", "оранжевый", "brown", "green", "green", };
        
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Byket byket = new Byket();
            Flower fl = new Flower();

            //byket[10] = fl;
            byket.AddFlower(fl);
            Flower flower = new Flower();
            Rose rose = new Rose("красный", 100);

            flower.ToPlant();
            flower.Tsvesti();
            flower.GetHashCode();
            flower.GetPlants();
            flower.Pour(5);
            if (flower is Flower)
            {
                Console.WriteLine(flower is Flower);
            }
            Flower emp = rose as Flower;
            Console.WriteLine(emp);
            Bush bush = new Bush();
            bush.ToPlant();
            bush.GetHashCode();
            bush.Pour(10);

            Cactus cactus = new Cactus();
            cactus.ToPlant();
            cactus.ToPlant();
            cactus.Tsvesti();
            cactus.GetHashCode();
            cactus.GetPlants();
            cactus.Pour(9);
            cactus.PutInPot();

           
            ICactus cactus_2 = cactus;
            cactus_2.ToPlant();

            
            rose.ToPlant();
            rose.Tsvesti();
            rose.GetHashCode();
            rose.GetPlants();
            rose.Pour(8);
            rose.Collect();
            rose.PackIn();
            rose.Color(Color.RED);

            Gladiolus gladiolus = new Gladiolus("розовый", 700);
            gladiolus.ToPlant();
            gladiolus.Tsvesti();
            gladiolus.GetHashCode();
            gladiolus.GetPlants();
            gladiolus.Pour(1);
            gladiolus.Collect();
            gladiolus.PackIn();

            Typeofplant typeofplant = new Typeofplant();
            typeofplant.nameofplant = "rose";
            Console.WriteLine(typeofplant.nameofplant);
            typeofplant.numberofplants = 5;
            Console.WriteLine(typeofplant.numberofplants);

            Gladiolus[] arrr = new Gladiolus[1];
            arrr[0] = new Gladiolus("розовый", 700);
            byket.InsertFlowers(arrr, 1);
            string clr = "розовый";
            if (byket.CheckFlowerByColor(clr))
            {
                Console.WriteLine("Byket has flower with " + clr + " color");
            }
            else
            {
                Console.WriteLine("Byket has not " + clr + " color");
            }

            Console.ReadKey();
            fl.color = "red";
            Console.WriteLine("Try to add to byket flower with " + fl.color + "color");
            byket.AddFlower(cactus);
            byket.AddFlower(rose);
            byket.AddFlower(flower);
            byket.AddFlower(gladiolus);
            byket.ShowByket();

            Console.WriteLine("__");
            
        }
    }
}
