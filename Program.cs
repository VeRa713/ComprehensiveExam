using ComprehensiveExam.Interfaces;
using ComprehensiveExam.Models;
using ComprehensiveExam.services;
using ComprehensiveExam.command;

namespace ComprehensiveExam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IEmployeeService employeeService = new EmployeeService();

            List<Employee> employeeList = employeeService.GetAll();

            BuildReport cmdBuildReport = new BuildReport();

            bool isContinue = true;

            while (isContinue)
            {
                Console.WriteLine("\n\n======= MAIN MENU =======\n");
                Console.WriteLine("a -  List All Employees");
                Console.WriteLine("b -  Create Employee Record");
                Console.WriteLine("c -  Delete Employee");
                Console.WriteLine("d -  Add Sale to Employee");
                Console.WriteLine("e -  Generate Report");
                Console.WriteLine("\nType \"quit\" to exit program");

                Console.Write("\nEnter choice: ");
                string choice = Console.ReadLine();

                bool isValid = false;

                switch (choice.ToLower())
                {
                    case "a":
                        Console.WriteLine("\n\n======= Display All Employees =======");

                        if (employeeList.Count() > 0)
                        {
                            //loop if user enters invalid choice
                            do
                            {
                                //ask user which type of employee to show
                                Console.WriteLine("\na - Normal Employees");
                                Console.WriteLine("b - Sales Employees");

                                Console.Write("\nWhich type of employee would you like to display: ");
                                choice = Console.ReadLine();

                                switch (choice.ToLower())
                                {
                                    case "a":
                                        isValid = true;
                                        Console.WriteLine("\n\n======= All Normal Employees =======");
                                        displayAllNormalEmployees(employeeList);
                                        break;

                                    case "b":
                                        isValid = true;
                                        Console.WriteLine("\n\n======= All Sales Employees =======");
                                        displayAllSalesEmployees(employeeService.GetAllSalesEmployees());
                                        break;

                                    default:
                                        isValid = false;
                                        Console.Write("Invalid Choice. Try Again\n");
                                        break;
                                }
                            } while (!isValid);
                        }
                        else
                        {
                            Console.WriteLine("\n\nEmployee List is EMPTY...");
                        }

                        break;

                    case "b":
                        isValid = false;

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
                                    choice = "normal";
                                    isValid = true;
                                    createEmployee(employeeService, choice, employeeList);
                                    break;

                                case "b":
                                    choice = "sales";
                                    isValid = true;
                                    createEmployee(employeeService, choice, employeeList);
                                    break;

                                default:
                                    isValid = false;
                                    Console.Write("Invalid Choice. Try Again\n");
                                    break;
                            }

                        } while (!isValid);

                        break;

                    case "c":
                        Console.WriteLine("\n\n======= Delete Employee =======\n");

                        Console.Write("Employee Number: ");
                        string empNum = Console.ReadLine();

                        if (employeeList != null)
                        {
                            Console.WriteLine("\nDeleting employee with employee number: " + empNum);

                            Employee deleteEmployee = employeeService.GetAll().Where(item => item.EmployeeNumber == empNum).FirstOrDefault();

                            if (deleteEmployee != null)
                            {
                                employeeService.Delete(deleteEmployee);

                                Console.WriteLine("\nDelete Successful!");
                            }
                            else
                            {
                                Console.WriteLine("\nEmployee does not exist");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nInvalid id. Try Again.");
                        }

                        break;

                    case "d":
                        Console.WriteLine("\n\n======= Add Sale to Employee =======\n");

                        Console.Write("Sales Employee Number: ");
                        string saleEmpNum = Console.ReadLine();

                        Employee saleEmployee = employeeService.GetAllSalesEmployees().Where(item => item.EmployeeNumber == saleEmpNum).FirstOrDefault();

                        if (saleEmployee != null)
                        {
                            Console.Write("\nItem Name: ");
                            string itemName = Console.ReadLine();

                            Console.Write("Amount: ");
                            float amount = float.Parse(Console.ReadLine());

                            Sale saleItem = new Sale(itemName, amount);

                            employeeService.AddSale((SalesEmployee)saleEmployee, saleItem);

                            Console.WriteLine("\nSale Successfully Added!");
                        }
                        else
                        {
                            Console.WriteLine("\nSales employee ID does not exist...");
                        }

                        break;

                    case "e":
                        Console.WriteLine("\n\n======= Generate Report =======\n");
                        Console.WriteLine(cmdBuildReport.Execute());
                        cmdBuildReport.CleanReportData();
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
        }

        private static void displayAllSalesEmployees(List<Employee> saleEmployeeList)
        {
            bool isFound = false;

            for (int i = 0; i < saleEmployeeList.Count(); i++)
            {
                Console.WriteLine("\nEmployee #" + saleEmployeeList[i].EmployeeNumber  + " : " + saleEmployeeList[i].LastName + ", " + saleEmployeeList[i].FirstName);
                isFound = true;
            }

            if (!isFound)
            {
                Console.WriteLine("\nList is EMPTY..");
            }

        }

        private static void displayAllNormalEmployees(List<Employee> employeeList)
        {
            bool isFound = false;

            for (int i = 0; i < employeeList.Count(); i++)
            {
                //check if employeeList is Normal - display if normal
                if (employeeList[i].GetType() == typeof(Employee))
                {
                    Employee temp = (Employee)employeeList[i];
                    Console.WriteLine("\nEmployee #" + temp.EmployeeNumber + " : " + temp.LastName + ", " + temp.FirstName);
                    isFound = true;
                }
            }

            if (!isFound)
            {
                Console.WriteLine("\nList is EMPTY..");
            }
        }

        public static void createEmployee(IEmployeeService employeeService, string choice, List<Employee> employeeList)
        {
            Console.Write("\nEnter Employee First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Employee Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Employee Number: ");
            string empNumber = Console.ReadLine();

            Console.Write("Enter Base Salary: ");
            float baseSalary = float.Parse(Console.ReadLine());

            int employeeId = employeeService.getNextId(employeeList.Count());

            if (choice.Equals("normal"))
            {
                Employee employee = new Employee(employeeId, firstName, lastName, empNumber, baseSalary);

                employeeService.Save(employee);
                Console.WriteLine("\nNormal Employee Successfully Created!");
            }
            else if (choice.Equals("sales"))
            {
                Console.Write("Enter Commission: ");
                float commission = float.Parse(Console.ReadLine());

                SalesEmployee salesEmployee = new SalesEmployee(employeeId, firstName, lastName, empNumber, baseSalary, commission);

                employeeService.Save(salesEmployee);

                Console.WriteLine("\nSales Employee Successfully Created!");
            }
        }
    }
}