namespace Core
{
    public class StoreRepository
    {
        private readonly List<Employee> _employees;

        public StoreRepository()
        {
            _employees = new List<Employee>
            {
                new Employee("Max", 17),
                new Employee("Sepp", 18),
                new Employee("Nina", 15),
                new Employee("Mike", 51)
            };
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employees;
        }

        public IEnumerable<Employee> GetAdultEmployees()
        {
            return _employees.Where(e => e.Age > 17);
        }

        public IEnumerable<Employee> GetOrderedEmployeesByName()
        {
            return _employees.OrderBy(e => e.Name);
        }

        public IEnumerable<Employee> GetOrderedDescendingEmployeesByName()
        {
            return _employees.OrderByDescending(e => e.Name);
        }
    }
}