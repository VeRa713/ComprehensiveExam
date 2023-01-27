using ComprehensiveExam.Models;

namespace ComprehensiveExam.Conf
{
    public class ApplicationContext
    {
        private List<Employee> allList;

        private static ApplicationContext instance = null;

        public static ApplicationContext Instance
        {
            get {
                if(instance == null) {
                    instance = new ApplicationContext();
                }
                return instance;
            }
        }

        public ApplicationContext()
        {
            this.allList = new List<Employee>();
        }

        public List<Employee> GetAll() //change to getALl
        {
            return this.allList;
        }
    }
}