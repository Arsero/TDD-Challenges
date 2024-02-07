using Core;

namespace Tests
{
    public class EmployeeTest
    {
        private readonly StoreRepository _repository;

        public EmployeeTest()
        {
            _repository = new StoreRepository();
        }

        [Fact]
        public void GetEmployees_ShouldReturnAllEmployee()
        {
            var employees = _repository.GetEmployees();

            employees.Count().Should().BeGreaterThan(0);
        }

        [Fact]
        public void GetAdultEmployees_ShouldReturnAllAdultEmployee()
        {
            var employees = _repository.GetAdultEmployees();

            employees.Count().Should().BeGreaterThan(0);
            foreach(var employee in employees)
            {
                employee.Age.Should().BeGreaterThanOrEqualTo(18);
            }
        }

        [Fact]
        public void GetOrderedEmployees_ShouldReturnAllEmployeeOrderedByName()
        {
            var employees = _repository.GetOrderedEmployeesByName();
            
            employees.Count().Should().BeGreaterThan(0);

            var expectedEmployees = employees.OrderBy(employee => employee.Name);
            expectedEmployees.SequenceEqual(employees).Should().BeTrue();
        }

        [Fact]
        public void GetEmployees_ShouldReturnAllEmployeeWithCapitalizedName()
        {
            var employees = _repository.GetOrderedEmployeesByName();

            employees.Count().Should().BeGreaterThan(0);
            foreach(var employee in employees)
            {
                char.IsUpper(employee.Name.First()).Should().BeTrue();
            }
        }

        [Fact]
        public void GetOrderedEmployees_ShouldReturnAllEmployeeOrderedDescendingByName()
        {
            var employees = _repository.GetOrderedDescendingEmployeesByName();

            employees.Count().Should().BeGreaterThan(0);

            var expectedEmployees = employees.OrderByDescending(employee => employee.Name);
            expectedEmployees.SequenceEqual(employees).Should().BeTrue();
        }
    }
}