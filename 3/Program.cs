using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    class Tour
    {
        private string destination;                 //поля  
        private int duration;
        private int price;

        public string Destination                  //властивості 
        {
            get { return destination; }
            set { destination = value; }
        }
        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public Tour()                                          //конструктор за замовчуванням
        {
            destination = "unknown destination";
            duration = 3;
            price = 1000;
        }
        public Tour(string destination, int duration, int price)       //параметризований конструктор
        {
            Destination = destination;
            Duration = duration;
            Price = price;
        }

        public virtual void BookTour()
        {
            Console.WriteLine("тур до {0} на {1} днів заброньовано.", destination, duration);
        }
        public void GetTourDetails()
        {
            Console.WriteLine("місце призначення: {0}, тривалість: {1} днів, ціна: {2}.", destination, duration, price);
        }

        class AdventureTour : Tour             //  AdventureTour
        {
            public string difficultyLevel;     //додаткове поле 

            public AdventureTour() : base() { }  // конструктор за замовчуванням

            public AdventureTour(string destination, int duration, int price, string difficultyLevel)
                : base(destination, duration, price)
            {
                this.difficultyLevel = difficultyLevel;
            }

            public override void BookTour()    //перевизначений метод
            {
                Console.WriteLine("пригодницький тур до {0} заброньовано. рівень складності: {1}.", destination, difficultyLevel);
            }

            public void SetDifficultyLevel(string level)             //встановлення рівня складності 
            {
                difficultyLevel = level;
                Console.WriteLine("рівень складності туру змінено на {0}.", level);
            }
        }
        class RelaxationTour : Tour                 //RelaxationTour
        {
            private bool spaIncluded;               //поля спа

            public RelaxationTour() : base() { }  // конструктор за замовчуванням

            public RelaxationTour(string destination, int duration, int price, bool spaIncluded)
                : base(destination, duration, price)
            {
                this.spaIncluded = spaIncluded;
            }

            public override void BookTour()         //перевизначений метод
            {
                string spaStatus = spaIncluded ? "включено" : "не включено";
                Console.WriteLine("релаксаційний тур до {0} заброньовано. спа: {1}.", destination, spaStatus);
            }
            public void IncludeSpa()                //метод для включення спа-послуг
            {
                spaIncluded = true;
                Console.WriteLine("спа включено до туру");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("оберіть тип відпочинку:");
            Console.WriteLine("1. Relaxation");
            Console.WriteLine("2. Adventure");
            Console.Write("Ваш вибір: ");
            string choice = Console.ReadLine();
             
            if (choice == "1")
            { 
                Console.WriteLine("ви хочете включити спа у ваш тур? (так/ні): ");
                string spaChoice = Console.ReadLine().ToLower();
                 
                if (spaChoice == "так")
                {
                     
                    RelaxationTour tour1 = new RelaxationTour("Буковель", 5, 20000, true);
                    tour1.GetTourDetails();
                    tour1.BookTour();
                }
                else if (spaChoice == "ні")
                {
                    
                    RelaxationTour tour2 = new RelaxationTour("Гаваї", 2, 14000, false);
                    tour2.GetTourDetails();
                    tour2.BookTour();
                }
                else
                {
                    Console.WriteLine("некоректний ввід даних ");
                }
            }
            else if (choice == "2")
            {
                Console.WriteLine("оберіть тур:");
                Console.WriteLine("1. Сингапур - Камбоджа - Малайзія - 21 день - 50000 грн, рівень складності екстримальний");
                Console.WriteLine("2. Ефіопія - 7 днів - 10000 грн, середній рівень складності");
                Console.Write("Ваш вибір: ");
                string adventureChoice = Console.ReadLine();

               
                if (adventureChoice == "1")
                {
                    
                    AdventureTour tour1 = new AdventureTour("Сингапур - Камбоджа - Малайзія", 21, 50000, "екстримальний");
                    tour1.GetTourDetails();
                    tour1.BookTour();
                        
                    Console.WriteLine("чи бажаєте змінити рівень складності на супер-пупер-екстримальний? (так/ні): ");
                    string changeDifficulty = Console.ReadLine().ToLower();
                    if (changeDifficulty == "так")
                    {
                        tour1.SetDifficultyLevel("супер-пупер-екстримальний :)");
                        tour1.BookTour();   
                    }

                    else if (changeDifficulty == "ні")
                    { 
                        Console.WriteLine("добре, ваш тур залишається екстримальним"); 
                    }

                }
                else if (adventureChoice == "2")
                {
                    AdventureTour tour2 = new AdventureTour("Ефіопія", 7, 10000, "середній");
                    tour2.GetTourDetails();
                    tour2.BookTour();
                }
                else
                {
                    Console.WriteLine("невірний вибір туру");
                }
            }
            else
            {
                Console.WriteLine("невірний вибір типу відпочинку ");
            }
        }
    }
} 