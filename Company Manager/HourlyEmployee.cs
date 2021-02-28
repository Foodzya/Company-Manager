using System;
using System.Collections.Generic;
using System.Text;

namespace Company_Manager
{
    class HourlyEmployee : Employee
    {
        private double HourCost { get; set; }

        private int WorkedHours { get; set; }

        private string Name { get; set; }

        private string Surname { get; set; }

        public HourlyEmployee (string name, string surname)
        {
            Name = name;

            Surname = surname;

            HourCost = PaymentPerHour();

            WorkedHours = HoursEmployeeInput();
        }


        public override double Payroll()
        {
            double salary = HourCost * WorkedHours;

            return salary;
        }

        public override void EmployeeInfo()
        {
            double salary = Payroll();

            Console.WriteLine($"Employee's full name: {Name} {Surname}");
            Console.WriteLine($"{Name} {Surname} earns ${salary} \n" +
                $"Hours worked — {WorkedHours};\n" +
                $"Hour cost is ${HourCost}.");
        }

        public override (string, string) GetFullName()
        {
            return (Name, Surname);
        }

        public static int HoursEmployeeInput()
        {
            int workedHours;

            Console.WriteLine("Please, enter how many hours does Hourly Employee work?");
            do
            {
                while (!int.TryParse(Console.ReadLine(), out workedHours))
                {
                    Console.WriteLine("Wrong input. Try again.");
                }

                if (workedHours > 200)
                {
                    Console.WriteLine("Employee couldn't work more than 200 hours. Try again: ");
                }
                else if (workedHours < 0)
                {
                    Console.WriteLine("That is nonsense. Employee cannot work less than 0 hours :D");
                }
            }
            while (workedHours > 200 || workedHours < 0);


            return workedHours;
        }

        // Hour cost entry method.
        public static double PaymentPerHour()
        {
            double hourCost;
            Console.WriteLine("Please, enter how much does hour cost?");

            while (!double.TryParse(Console.ReadLine(), out hourCost))
            {
                Console.WriteLine("Wrong input. Try again.");
            }

            return hourCost;
        }
    }
}
