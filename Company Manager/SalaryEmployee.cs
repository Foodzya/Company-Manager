using System;
using System.Collections.Generic;
using System.Text;

namespace Company_Manager
{
    class SalaryEmployee : Employee
    {
        private byte DaysWorked { get; set; }

        private double Salary { get; set; }

        private static readonly uint workedDaysNormal = 21;

        private string Name { get; set; }

        private string Surname { get; set; }

        public SalaryEmployee(string firstName, string lastName)
        {
            Name = firstName;

            Surname = lastName;

            DaysWorked = WorkingDays();

            Salary = FulltimeSalary();
        }

        public override double Payroll()
        {
            double salary = (double)DaysWorked / workedDaysNormal * Salary;

            salary = Math.Round(salary, 3);

            return salary;
        }

        public override void EmployeeInfo()
        {
            double salary = Payroll();

            Console.WriteLine($"Working days per month by default — {workedDaysNormal}\n");
            Console.WriteLine($"Full-time employee {Name} {Surname} earned ${salary}; \n" +
                $"Default salary: ${Salary}\n" +
                $"Employee have worked {DaysWorked} days (when normal is {workedDaysNormal}");
        }

        public override (string, string) GetFullName()
        {
            return (Name, Surname);
        }

        public static byte WorkingDays()
        {
            byte workedDays;

            Console.WriteLine("Please, enter how many days have been Salary Employee working?");

            do
            {
                while (!byte.TryParse(Console.ReadLine(), out workedDays))
                {
                    Console.WriteLine("Wrong input. Try again.");
                }
                if (workedDays > workedDaysNormal)
                {
                    Console.WriteLine($"WOW! Employee overworked by {workedDays - workedDaysNormal} days");
                }
                else if(workedDays > 25)
                {
                    Console.WriteLine("It's against the rules! " +
                        "\nEmployee couldn't work more than 25 days in month. Try again...");
                }
            }
            while (workedDays > 25);


            return workedDays;
        }

        // Fulltime salary entry method.
        public static double FulltimeSalary()
        {
            double salary;

            Console.WriteLine("Enter the employee's monthly salary: ");
            while (!double.TryParse(Console.ReadLine(), out salary))
            {
                Console.WriteLine("Only number allowed. Try again: ");
            }

            salary = Math.Abs(salary);

            return salary;

        }
    }
}
