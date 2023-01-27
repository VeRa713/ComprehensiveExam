using ComprehensiveExam.Models;

namespace ComprehensiveExam.Interfaces
{
    public interface IEmployeeService
    {
        public List<Employee> GetAll();
        public List<Employee> GetAllSalesEmployees();
        public Employee Save(Employee e);
        public void Delete(Employee e);
        public void AddSale(SalesEmployee e, Sale s);
        int getNextId(int count);
    }
}