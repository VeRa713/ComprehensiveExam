namespace ComprehensiveExam.Models
{
    public class Employee : Person
    {
        public string EmployeeNumber { get; set; }
        public float BaseSalary { get; set; }

        public Employee(int id, string firstName, string lastName, string empNumber, float baseSalary) : base(id, firstName, lastName)
        {
            this.EmployeeNumber = empNumber;
            this.BaseSalary = baseSalary;
        }

        public float GetSalary(){
            return this.BaseSalary;
        }
    }
}