using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Linq;

namespace Company_Manager
{
    public abstract class Company
    {
        private static List<Employee> employees = new List<Employee>();

        private enum Menu
        {
            HourlyEmployee = 1,
            SalaryEmployee,
            Manager,
            Executive
        }

        public static void ToHire()
        {
            Console.Clear();

            bool toHireEmployee;
            toHireEmployee = true;

            while (toHireEmployee)
            {
                EmployeesMenu();

                toHireEmployee = NewDecision();

                Program.ActionMenu();

                Console.Clear();
            }
        }

        public static void ToFire()
        {
            Console.Clear();

            if (employees.Count > 0)
            {
                ToFireRealization();
            }
            else
            {
                Console.WriteLine("Nobody is employed at the moment..");
                Console.WriteLine("----------------------------------");
            }
        }

        private static void ToFireRealization()
        {
            byte employeeToBeFired;

            int indexCount = GetEmployeesList();

            Console.WriteLine("\nChoose an employee you want to fire from the list above: \n" +
                "To exit this menu type 0");
            while (!byte.TryParse(Console.ReadLine(), out employeeToBeFired))
            {
                Console.WriteLine("Try again: ");
            }

            EmployeeToBeFired(employeeToBeFired, indexCount);
        }

        private static void EmployeeToBeFired(byte toFireIndex, int indexCount)
        {
            if (toFireIndex < 0 || toFireIndex > indexCount)
            {
                try
                {
                    employees.RemoveAt(toFireIndex - 1);
                    Console.WriteLine("Item have been successfully deleted.");
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"{ex.Message} + \nTry again...");
                }
            }
            else if (toFireIndex == 0)
            {
                Console.WriteLine("Returning to the menu..");
            }

        }

        public static void ToPromote()
        {
            Console.Clear();

            if (employees.Count > 0)
            {
                PromoteRealization();
            }
            else
            {
                Console.WriteLine("Nobody is employed at the moment..");
                Console.WriteLine("----------------------------------");
            }
        }

        private static void PromoteRealization()
        {
            byte employeeToBePromoted;

            Console.WriteLine();
            Console.WriteLine("Choose an employee you want to promote from the list below: ");

            int indexCount = GetEmployeesList();

            do
            {
                while (!byte.TryParse(Console.ReadLine(), out employeeToBePromoted))
                {
                    Console.WriteLine("Try again: ");
                }
            }
            while (employeeToBePromoted < 0 || employeeToBePromoted > indexCount);


            Employee currentEmployee = employees.ElementAt(employeeToBePromoted - 1);

            employees.RemoveAt(employeeToBePromoted - 1);

            var (name, surname) = currentEmployee.GetFullName();

            if (currentEmployee is HourlyEmployee || currentEmployee is SalaryEmployee)
            {
                employees.Add(new Manager(name, surname));
            }
            else if (currentEmployee is Manager)
            {
                employees.Add(new Executive(name, surname));
            }
            else if (currentEmployee is Executive)
            {
                Console.WriteLine("There is no position higher than Executive at the moment.");
            }
        }


        public static int GetEmployeesList()
        {
            int i = 0;
            if (employees.Count > 0)
            {
                foreach (Employee e in employees)
                {
                    Console.WriteLine($"{i + 1}: ");
                    e.EmployeeInfo();
                    i++;
                }
            }
            else
            {
                Console.WriteLine("\nEmployees list is empty..");
                Console.WriteLine("Press any button to continue...");
                Console.ReadKey();
            }
            return i;
        }

        private static void SwitchForNewEmployee(char usersChoice)
        {
            switch (usersChoice)
            {
                case '1':
                    var (firstName, lastName) = EmployeesName();
                    employees.Add(new HourlyEmployee(firstName, lastName));
                    break;
                case '2':
                    (firstName, lastName) = EmployeesName();
                    employees.Add(new SalaryEmployee(firstName, lastName));
                    break;
                case '3':
                    (firstName, lastName) = EmployeesName();
                    employees.Add(new Manager(firstName, lastName));
                    break;
                case '4':
                    (firstName, lastName) = EmployeesName();
                    employees.Add(new Executive(firstName, lastName));
                    break;
            }
        }

        private static void EmployeesMenu()
        {
            Console.WriteLine("Choose an employee from the list: \n" +
                $"1: {Menu.HourlyEmployee};\n" +
                $"2: {Menu.SalaryEmployee};\n" +
                $"3: {Menu.Manager};\n" +
                $"4: {Menu.Executive};\n");
            char usersChoice = Console.ReadKey().KeyChar;

            while (!char.IsDigit(usersChoice) || (usersChoice != '1' && usersChoice != '2' && usersChoice != '3' && usersChoice != '4'))
            {
                Console.WriteLine("\nSelect existing item (1-4)");
                usersChoice = Console.ReadKey().KeyChar;
            }
            Console.WriteLine();

            SwitchForNewEmployee(usersChoice);
        }

        private static bool NewDecision()
        {
            bool hireEmployee = true;

            Console.WriteLine("Do you want to choose another option? \nType N to exit...");

            string toContinue = Console.ReadLine();
            toContinue = toContinue.Trim();
            toContinue = toContinue.ToLower();

            if (toContinue == "n")
            {
                hireEmployee = false;
                Console.WriteLine("Quit (type Y/N)...");

                char input = Console.ReadKey().KeyChar;

                if (input == 'y' || input == 'Y')
                {
                    Environment.Exit(0);
                }
            }

            return hireEmployee;
        }

        private static (string, string) EmployeesName()
        {
            Console.WriteLine("Enter employee's first name please");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter employee's second name please");
            string lastName = Console.ReadLine();

            return (firstName, lastName);

        }
    }
}
