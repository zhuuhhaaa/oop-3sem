using System;
using System.Diagnostics;

namespace Lab5
{ 
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

    class Flower : Plant, IFlower
    {
        public override string ToString() => "Flower";
        public override void ToPlant() => Console.WriteLine("Вы посадили цветок", numOfPlants += 1);
        public void Vyanyt()
       =>
           Console.WriteLine($"Завял {ToString()}");

        public void Tsvesti()
       =>
           Console.WriteLine($"Расцвел {ToString()}");
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
    {
        public override string ToString() => "Rose";
        public override void ToPlant() => Console.WriteLine("Вы посадили розу", numOfPlants += 1);
        public void Collect() => Console.WriteLine("Вы собрали букет роз");
        public void PackIn() => Console.WriteLine("Вы обернули букет в бумагу");
    }

    class Gladiolus : Flower, IPaper
    {
        public override string ToString() => "Gladiolus";
        public override void ToPlant() => Console.WriteLine("Вы посадили гладиолус", numOfPlants += 1);
        public void Collect() => Console.WriteLine("Вы собрали букет из гладиолусов");
        public void PackIn() => Console.WriteLine("Вы обернули букет в бумагу");
    }

    class Program
    {


        static void Main(string[] args)
        {
            
            Flower flower = new();
            flower.ToPlant();
            flower.Tsvesti();
            flower.GetHashCode();
            flower.GetPlants();
            flower.Pour(5);
            if (flower is Flower)
            {
                Console.WriteLine(flower is Flower);
            }


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

            Rose rose = new Rose();
            rose.ToPlant();
            rose.Tsvesti();
            rose.GetHashCode();
            rose.GetPlants();
            rose.Pour(8);
            rose.Collect();
            rose.PackIn();

            Gladiolus gladiolus = new Gladiolus();
            gladiolus.ToPlant();
            gladiolus.Tsvesti();
            gladiolus.GetHashCode();
            gladiolus.GetPlants();
            gladiolus.Pour(1);
            gladiolus.Collect();
            gladiolus.PackIn();


        }

    }


}

