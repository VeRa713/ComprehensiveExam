using ComprehensiveExam.Interfaces;
using ComprehensiveExam.Models;
using ComprehensiveExam.services;

namespace ComprehensiveExam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // EmployeeService todoItemService = new EmployeeService();

            // List<Employee> employeeLists = todoItemService.GetAll();

            bool isContinue = true;

            while (isContinue)
            {
                Console.WriteLine("\n\n======= MAIN MENU =======\n");
                Console.WriteLine("1 -  List All Employees");
                Console.WriteLine("2 -  Create Employee Record");
                Console.WriteLine("3 -  Delete Employee");
                Console.WriteLine("4 -  Add Sale to Employee");
                Console.WriteLine("5 -  Quit");

                Console.Write("\nEnter Number: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        break;

                    case "2":
                        break;
                        
                    case "3":
                        break;

                    case "4":
                        break;

                    case "5":
                        Console.Write("Quit");
                        isContinue = false;
                        break;

                    default:
                        Console.Write("Invalid Choice. Try Again");
                        break;
                }
            }


            // // create salesEmployee
            // SalesEmployee salesEmployee = new SalesEmployee(1, "fname", "lname", "061307", 1000.00f, 0.1f);

            // //add sales
            // Sale item1 = new Sale("Item 1", 500.00f);
            // Sale item2 = new Sale("Item 2", 500.00f);

            // salesEmployee.Sales.Add(item1);
            // salesEmployee.Sales.Add(item2);

            // // display salary
            // Console.WriteLine("Salary: " + salesEmployee.GetSalary()); //should output

            // Listing all employees(first all normal employees then sales employees)\
            // Save an Employee record
            // Delete an Employee
            // Add a sale to a selected sales employee

        }
    }
}