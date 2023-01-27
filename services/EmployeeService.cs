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

        public int getNextId(int itemCount)
        {
            if (itemCount > 0)
            {
                return this.employeeList.Last().Id + 1;
            }
            else
            {
                return 1;
            }
        }

        public void AddSale(SalesEmployee e, Sale s)
        {
            throw new NotImplementedException();
        }

        public void Delete(Employee e)
        {
            Employee deleteEmployee = employeeList.Where(list => list.Id == e.Id).FirstOrDefault();
            employeeList.Remove(deleteEmployee);
        }

        public List<Employee> GetAll()
        {
            return this.employeeList;
        }

        public List<Employee> GetAllSalesEmployees()
        {
            List<Employee> salesEmployeesList = new List<Employee>();

            for (int i = 0; i < employeeList.Count(); i++)
            {
                //check if employeeList is Normal or Sales - add to salesEmployeesList
                if (employeeList[i].GetType() == typeof(SalesEmployee))
                {
                    SalesEmployee temp = (SalesEmployee)employeeList[i];
                    salesEmployeesList.Add(temp);
                }
            }

            return salesEmployeesList;
        }

        public Employee Save(Employee e)
        {
            employeeList.Add(e);

            return e;
        }
    }
}