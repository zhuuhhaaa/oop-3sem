using System;
namespace _3laba
{
    class Customer
    {

        public static int upc;
      
        public int Upc
        {
            set
            {
                upc = value;
            }
            get
            {
                return upc;
            }
        }

        private int id;
        public static int _id = 1;

        private string surname;
        public string Surname
        {
            set
            {
                if (value != null && value != "")
                    surname = value;
            }
            get
            {
                return surname; ;
            }
        }


        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set //Свойство сет с проверкой на корректность ввода
            {
                bool isCorrect = true;
                for (int i = 0; i < value.Length; i++)
                {
                    if (!(value[i] >= 'a' && value[i] <= 'z') && !(value[i] >= 'A' && value[i] <= 'Z'))
                    {
                        isCorrect = false;
                        break;
                    }
                }
                if (isCorrect)
                {
                    name = value;
                }

            }
        }
        private string patronymic;
        public string Patronymic
        {
            set
            {
                if (value != null && value != "")
                    patronymic = value;
            }
            get
            {
                return patronymic;
            }
        }

        private string adress;
        public string Adress
        {
            set
            {
                if (value != null && value != "")
                    adress = value;
            }
            get
            {
                return adress;
            }
        }

        private uint bankrecv;
        public uint Bankrecv
        {
            set
            {
                if (value > 0 && value < 99999999)
                    bankrecv = value;
            }
            get
            {
                return bankrecv;
            }

        }
        private int count;
        public int Сount
        {
            set
            {
                if (value >= 0)
                    count = value;
            }
            get
            {
                return count;
            }

        }

        public Customer(string _surname, string _name, string _patronymic, string _adress, uint _bankcount, int _count, int _id)      // 1 конструктор
        {
            id = _id;

            name = _name;

            surname = _surname;

            patronymic = _patronymic;

            adress = _adress;

            bankrecv = _bankcount;

            count = _count;
            
        }
        
        private Customer()
        {
            Console.WriteLine(new string('!', 20));
        }


        public void Getinfo()
        {

            Console.WriteLine(new string('-', 50));
            Console.WriteLine(this.surname + "\n" + this.name + "\n" + this.patronymic + "\n" + this.adress + "\n" + this.bankrecv + "\n" + this.count + "\n" + this.id);
            Console.WriteLine(new string('-', 50));

        }


    }
}
