using ComprehensiveExam.Models;

namespace ComprehensiveExam
{
    public class Program
    {
        public static void Main(string[] args)
        { 
            // create salesEmployee
            SalesEmployee salesEmployee = new SalesEmployee(1, "fname", "lname", "061307", 1000.00f, 0.1f);

            //add sales
            Sale item1 = new Sale("Item 1", 500.00f);
            Sale item2 = new Sale("Item 2", 500.00f);

            salesEmployee.Sales.Add(item1);
            salesEmployee.Sales.Add(item2);

            // display salary
            Console.WriteLine("Salary: " + salesEmployee.GetSalary()); //should output
        }
    }
}