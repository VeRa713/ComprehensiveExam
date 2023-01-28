using ComprehensiveExam.Models;
using ComprehensiveExam.services;
using System.Text.Json;

namespace ComprehensiveExam.command
{
    public class BuildReport
    {
        /*
        {
            “employees”: [
                { 
                    “id”: 1, 
                    “employeeNumber”: “x”, 
                    “firstName”: “x”, 
                    “lastName”: “x”, 
                    “baseSalary”: 100.00 
                }
            ],
            “salesEmployees”: [
                { 
                    “id”: 1, 
                    employeeNumber”: “x”, 
                    “firstName”: “x”, 
                    “lastName”: “x”, 
                    “baseSalary”: 100.00, 
                    “commission”: 0.1 
                }
            ],
            “totalSales”: 1000.00,
            “totalCommission”: 1000.00
        }
        */

        private EmployeeService employeeService;
        private List<Employee> allEmployees;   
        private List<Employee> normalEmployees;
        private List<SalesEmployee> salesEmployees;

        public BuildReport()
        {
            this.employeeService = new EmployeeService();
            this.normalEmployees = new List<Employee>();
            this.salesEmployees = new List<SalesEmployee>();
        }

        public string Execute()
        {
            this.allEmployees = employeeService.GetAll();

            var seralizerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            for (int i = 0; i < this.allEmployees.Count(); i++)
            {
                //check if employee is Normal or Sales - add to respective lists
                if (this.allEmployees[i].GetType() == typeof(SalesEmployee))
                {
                    SalesEmployee temp = (SalesEmployee)this.allEmployees[i];
                    salesEmployees.Add(temp);
                } else if (this.allEmployees[i].GetType() == typeof(Employee))
                {
                    Employee temp = (Employee)this.allEmployees[i];
                    this.normalEmployees.Add(temp);
                }
            }

            List<Object> normalEmployee = this.normalEmployees.Select(ne => new { ne.Id, ne.EmployeeNumber, ne.FirstName, ne.LastName, ne.BaseSalary }).ToList<Object>();
            List<Object> salesEmployee = this.salesEmployees.Select(se => new { se.Id, se.EmployeeNumber, se.FirstName, se.LastName, se.BaseSalary, se.Commission }).ToList<Object>();

            Dictionary<string, object> jsonReport = new Dictionary<string, object>();
            jsonReport.Add("employees", normalEmployee);
            jsonReport.Add("salesEmployees", salesEmployee);

            if (this.salesEmployees.Count > 0)
            {
                jsonReport.Add("totalSales", 0);
                jsonReport.Add("totalCommission", 0);
            }

            return JsonSerializer.Serialize(jsonReport, seralizerOptions);
        }

        //cleans data after output so that data won't repeat upon next run
        public void CleanReportData()
        {
            this.normalEmployees.Clear();
            this.salesEmployees.Clear();
        }
    }
}