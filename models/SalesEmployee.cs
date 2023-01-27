namespace ComprehensiveExam.models
{
    public class SalesEmployee : Employee
    {
        public float Commission { get; set; }
        public List<Sale> Sales { get; set; }

        public SalesEmployee(int id, string firstName, string lastName, string empNumber, float baseSalary, float commission) : base(id, firstName, lastName, empNumber, baseSalary)
        {
            this.Commission = commission;
            this.Sales = new List<Sale>();
        }
    }
}