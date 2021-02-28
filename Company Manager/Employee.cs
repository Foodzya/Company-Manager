using System;
using System.Collections.Generic;
using System.Text;

namespace Company_Manager
{
    abstract class Employee
    {
        abstract public double Payroll();

        abstract public void EmployeeInfo();

        abstract public (string, string) GetFullName();
    }
}
