using System;
using _3laba;

namespace test
{
    
    class Program
    {
        static void SortBySname( ref Customer[] customers)
        {
            for (int i = 0; i < customers.Length; i++)
            {
                for (int j = i + 1; j < customers.Length; j++)
                {
                    if (String.Compare(customers[i].Surname, customers[j].Surname) == 1)
                    {
                        swap(ref customers[i], ref customers[j]);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            int sum = 6;
            Customer[] customers = new Customer[sum];
            customers[0] = new Customer("Lyash", "Alexander", "Petrov", "Minsk, Prospect Pushkina 50", 11223344, 250, 1111);
            customers[1] = new Customer("Balashov", "Ivan", "Alexandrov", "Grodno, Ulica Lenina 3", 22222222, 10, 2222);
            customers[2] = new Customer("Alymov", "Sergei", "Vladimirovich", "Polotsk, Prospect Nezavisimosti 6", 42449034, 30, 3333);
            customers[3] = new Customer("Dybrovskii", "Petr", "Vitalievich", "Minsk, Ulica Mayakovskogo 73", 43214321, 65030, 4444);
            customers[4] = new Customer("Zyev", "Yan", "Ivanovich", "Minsk, Ulica Libnexta 32", 66667777, 100, 5555);
            customers[5] = new Customer("Romanuk", "Liza", "Alexeeva", "Minsk, Prospect Pobeditelej 40", 99999999, 10000, 6666);




            Customer.upc = 5;

       
            
            SortBySname(ref customers);

            for (int i = 0; i < sum; i++)
            {
                Console.WriteLine("Покупатель");
                customers[i].Getinfo();
            }


            Findname(ref customers);
            Findbankcount(ref customers);
            
        }

        static void swap(ref Customer customer1, ref Customer customer2)
        {
            Customer temp = customer1;
            customer1 = customer2;
            customer2 = temp;

        }
        static void Findbankcount(ref Customer[] customers)
        {
            
            bool work = true;

            while(work)
            {
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Введите диапазон номера карты (8 цифр) для поиска или 0 для выхода:\nОт: ");


                uint find = Convert.ToUInt32(Console.ReadLine());
                if(find==0)
                {
                    work = false;
                }
                else
                {
                    Console.WriteLine("До: ");
                    uint fend = Convert.ToUInt32(Console.ReadLine());
                    if(find<10000000 || fend< 10000000|| fend<find)
                    {
                        Console.WriteLine("Ввод неверный, повторите");
                    }
                    else
                    {
                        int flag = 0;
                        for (int i = 0; i < customers.Length; i++)
                        {
                            if (find <= customers[i].Bankrecv && fend >= customers[i].Bankrecv)
                            {
                                customers[i].Getinfo();
                                flag++;
                            }
                        }


                        if (flag == 0)
                        {
                            Console.WriteLine("Ничего не найдено");
                        }
                    }
                    
                }
            }
        }
        static void Findname(ref Customer[] customers)
        {
            
            bool work = true;
            while (work)
            {
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Фамилия для поиска или 0 для выхода: ");
                string find = Console.ReadLine();
                if (find == "0")
                {
                    work = false;
                }
                else
                {
                    int flag = 0;
                    for (int i = 0; i < customers.Length; i++)
                    {
                        string name = customers[i].Surname;
                        if (find == name)
                        {
                            flag++;
                            customers[i].Getinfo();
                        }   
                    }
                    if(flag==0)
                    {
                            Console.WriteLine("Не найдено ничего, повторите ввод");
                    }
                }
            }
            
        }
    }
}
