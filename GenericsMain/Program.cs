using System;
using System.Collections.Generic;

namespace GenericsMain
{
    class Employee
    {
        public string mName;
        public int mSalary;

        public Employee(string name, int salary)
        {
            mName = name;
            mSalary = salary;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>();

            empList.Add(new Employee("John Doe", 5000));
            empList.Add(new Employee("John Lee", 9000));
            empList.Add(new Employee("Jane Doe", 2000));
            empList.Add(new Employee("Jane Lee", 4000));

            //TODO: Use Exists() and Find()
            if (empList.Exists(HighPay))
            {
                Console.WriteLine("\nHoghly paid employee found!\n");
            }
            Employee e = empList.Find(x => x.mName.StartsWith("J"));
            if(e != null)
            {
                Console.WriteLine("Found employee whose nam starts with J: {0}", e.mName);
            }

            //TODO: Use ForEach() to iterate over each item
            empList.ForEach(TotalSalaries);
            Console.WriteLine("Total payrol is: {0}\n", total);


            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }

        // Iterator funv=ction for the ForEach method
        static int total = 0;
        static void TotalSalaries(Employee e)
        {
            total += e.mSalary;
        }

        // delegate function to use for the Exists method
        static Boolean HighPay(Employee emp)
        {
            return emp.mSalary >= 65000;
        }
    }
}