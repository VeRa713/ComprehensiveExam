using ComprehensiveExam.Models;
using ComprehensiveExam.Interfaces;
using ComprehensiveExam.Conf;

namespace ComprehensiveExam.services
{
    public class EmployeeService : IEmployeeService
    {
        private ApplicationContext appInstance;

        private List<Employee> employeeList;

        public EmployeeService()
        {
            appInstance = ApplicationContext.Instance;
            employeeList = appInstance.GetAll();
        }

        public void AddSale(SalesEmployee e, Sale s)
        {
            throw new NotImplementedException();
        }

        public void Delete(Employee e)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            return this.employeeList;
        }

        public List<Employee> GetAllSalesEmployees()
        {
            throw new NotImplementedException();
        }

        public Employee Save(Employee e)
        {
            employeeList.Add(e);
            
            return e;
        }
    }
}