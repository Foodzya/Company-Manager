using System;
using System.Collections.Generic;
using System.Text;

namespace Company_Manager
{
    class Executive : Employee
    {
        private string Name { get; set; }

        private string Surname { get; set; }

        private double baseSalary;

        private double bonusPayout;

        private double extraBonus;

        public Executive(string name, string surname)
        {
            Name = name; 
            
            Surname = surname;

            baseSalary = BaseSalaryInput();

            bonusPayout = BonusesInput();
        }

        public override void EmployeeInfo()
        {
            double salary = Payroll();

            Console.WriteLine($"Executive {Name} {Surname} earned ${salary}.\n" +
                $"Base salary: ${baseSalary};\n" +
                $"Bonuses: ${bonusPayout}");
        }

        public override (string, string) GetFullName()
        {
            return (Name, Surname);
        }

        public override double Payroll()
        {
            double salary;

            salary = baseSalary + bonusPayout + extraBonus;

            return salary;
        }

        private double BaseSalaryInput()
        {
            double basisSalary;
            Console.WriteLine("Type base salary of executive: ");
            do
            {
                while (!double.TryParse(Console.ReadLine(), out basisSalary))
                {
                    Console.WriteLine("Incorrect number");
                }
                if (basisSalary < 0)
                {
                    Console.WriteLine("Number must be a positive.");
                }
            }
            while (basisSalary < 0);

            return basisSalary;
        }

        private double BonusesInput()
        {
            double bonuses;
            Console.WriteLine("Enter money bonuses received by the executive: ");
            do
            {
                while (!double.TryParse(Console.ReadLine(), out bonuses))
                {
                    Console.WriteLine("Incorrect number");
                }
                if (bonuses < 0)
                {
                    Console.WriteLine("Number must be a positive.");
                }
            }
            while (bonuses < 0);

            return bonuses;
        }

    }
}
