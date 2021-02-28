using System;
using System.Collections.Generic;
using System.Text;

namespace Company_Manager
{
    class Manager : Employee
    {
        private readonly double fixedSalary = 1000;

        private double finalSalary;

        private double SoldByManager { get; set; }

        private string Name { get; set; }

        private string Surname { get; set; }

        private double SalesPercent { get; set; }

        public Manager(string firstName, string lastName)
        {
            SalesPercent = PercentageOfSales();

            SoldByManager = Proceeds();

            Name = firstName;

            Surname = lastName;

        }

        public override double Payroll()
        {
            if (SoldByManager > 0)
            {
                finalSalary = SoldByManager * SalesPercent / 100;
            }

            else
            {
                finalSalary = fixedSalary;
            }

            return finalSalary;
        }

        public override void EmployeeInfo()
        {
            double salary = Payroll();

            Console.WriteLine($"Manager {Name} {Surname} earned ${salary}.\n" +
                $"Manager's part: {SalesPercent}\n" +
                $"Have been sold in total: ${SoldByManager}");
        }

        public override (string, string) GetFullName()
        {
            return (Name, Surname);
        }

        private double PercentageOfSales()
        {
            double percentOfSales;

            Console.WriteLine("What sales percentage does the employee receive?");
            while (!double.TryParse(Console.ReadLine(), out percentOfSales))
            {
                Console.WriteLine("Incorrect number. Try again: ");
            }

            return percentOfSales;
        }

        private double Proceeds()
        {
            double proceeds;

            Console.WriteLine("How much have manager sold for month?");
            while (!double.TryParse(Console.ReadLine(), out proceeds))
            {
                Console.WriteLine("Incorrect number. Try again: ");
            }

            return proceeds;
        }
    }
}
