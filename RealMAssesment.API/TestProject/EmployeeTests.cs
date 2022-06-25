using Modals;
using ServicesLibrary.ServiceContracts.v1;
using ServicesLibrary.ServiceImplementation.v1;

namespace TestProject
{
    public class EmployeeTests
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeTests()
        {
            _employeeService = new EmployeeService();
        }

        [Fact]
        public async void GetEmployeesTest()
        {
            var emplist = new List<Employee>();//arrange

            var actual = await _employeeService.GetEmployees();//act

            Assert.NotNull(actual);

        }

        [Fact]
        public async void getIngnoreEmployess()
        {
            var emplist = new List<Employee>();//arrange

            var actual = await _employeeService.IgnoreEmployees();//act

            Assert.NotNull(actual);

        }
    }
}