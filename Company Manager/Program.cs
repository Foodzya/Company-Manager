using System;
using System.Collections;

namespace Company_Manager
{
    class Program
    {
        public static void ActionMenu()
        {
            Console.Clear();

            bool menu = true;

            while (menu)
            {
                Console.Clear();

                Console.WriteLine("\tMenu: \n" +
               "----------------------\n" +
               "1: To hire an employee;\n" +
               "2: To fire an employee;\n" +
               "3: To promote an employee;\n" +
               "4: To get employees list.");

                char input = Console.ReadKey().KeyChar;

                while (!char.IsDigit(input) || (input != '1' && input != '2' && input != '3' && input != '4'))
                {
                    Console.WriteLine("\nSelect existing item (1-4)");
                    input = Console.ReadKey().KeyChar;
                }

                MenuSwitch(input);
            }
        }

        public static void MenuSwitch(char input)
        {
            switch (input)
            {
                case '1':
                    Company.ToHire();
                    break;
                case '2':
                    Company.ToFire();
                    break;
                case '3':
                    Company.ToPromote();
                    break;
                case '4':
                    Company.GetEmployeesList();
                    break;
            }
        }

        public static void Start()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("\t\t\tWelcome to COMPANY MANAGER application \n" +
                "\t\t\t-------------------------------------- \n" +
                "\t\t\tStudent: Alexander Borisyonok");

            Console.WriteLine("\nPress any button to get the menu...");
            Console.ReadKey();

            ActionMenu();

        }

        static void Main(string[] args)
        {
            Start();

            Console.ReadLine();
        }

    }


}
