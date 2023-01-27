using ComprehensiveExam.Interfaces;
using ComprehensiveExam.Models;
using ComprehensiveExam.services;

namespace ComprehensiveExam
{
    public class Program
    {
        public static void createEmployee(IEmployeeService employeeService, string choice)
        {
            Console.Write("\nEnter Employee First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Employee Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Employee Number: ");
            string empNumber = Console.ReadLine();

            Console.Write("Enter Base Salary: ");
            float baseSalary = float.Parse(Console.ReadLine());

            // int employeeId = selectList.getLastId(itemCount); 


            if (choice.Equals("Normal"))
            {
                Employee employee = new Employee(1, firstName, lastName, empNumber, baseSalary);

                employeeService.Save(employee);
                Console.WriteLine("Normal Employee Successfully Created!");
            }
            else if (choice.Equals("Sales"))
            {
                Console.Write("Enter Commission: ");
                float commission = float.Parse(Console.ReadLine());

                // int employeeId = selectList.getLastId(itemCount); 
                SalesEmployee salesEmployee = new SalesEmployee(1, firstName, lastName, empNumber, baseSalary, commission);

                employeeService.Save(salesEmployee);

                Console.WriteLine("Sales Employee Successfully Created!");
            }
        }

        public static void Main(string[] args)
        {
            IEmployeeService employeeService = new EmployeeService();

            List<Employee> employeeList = employeeService.GetAll();

            bool isContinue = true;

            while (isContinue)
            {
                Console.WriteLine("\n\n======= MAIN MENU =======\n");
                Console.WriteLine("a -  List All Employees");
                Console.WriteLine("b -  Create Employee Record");
                Console.WriteLine("c -  Delete Employee");
                Console.WriteLine("d -  Add Sale to Employee");
                Console.WriteLine("\nType \"quit\" to exit program");

                Console.Write("\nEnter choice: ");
                string choice = Console.ReadLine();

                switch (choice.ToLower())
                {
                    case "a":
                        Console.WriteLine("\n\n======= Display All Employees =======");

                        // display all normal employees first 
                        //then sales employees

                        if (employeeList.Count() > 0)
                        {

                            for (int i = 0; i < employeeList.Count(); i++)
                            {
                                Console.WriteLine("\nEmployee #" + employeeList[i].EmployeeNumber + " : " + employeeList[i].FirstName);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n\nEmployee List is EMPTY...");
                        }

                        break;

                    case "b":
                        bool isCorrectChoice = false;

                        do
                        {
                            Console.WriteLine("\n\n======= Create Employee Record =======\n");

                            Console.WriteLine("a -  Normal Employee");
                            Console.WriteLine("b -  Sales Employee");

                            Console.Write("\nWhat type of employee would you like to create?: ");
                            choice = Console.ReadLine();

                            switch (choice.ToLower())
                            {
                                case "a":
                                    choice = "Normal";
                                    isCorrectChoice = true;
                                    createEmployee(employeeService, choice);
                                    break;

                                case "b":
                                    choice = "Sales";
                                    isCorrectChoice = true;
                                    createEmployee(employeeService, choice);
                                    break;
                                    
                                default:
                                    isCorrectChoice = false;
                                    Console.Write("Invalid Choice. Try Again\n");
                                    break;
                            }

                        } while (!isCorrectChoice);



                        break;

                    case "c":
                        Console.WriteLine("\n\n======= Delete Employee =======\n");

                        break;

                    case "d":
                        Console.WriteLine("\n\n======= Add Sale to Employee =======\n");

                        break;

                    case "quit":
                        Console.Write("\nGoodbye!");
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