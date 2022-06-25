using Modals;
using ServicesLibrary.ServiceContracts.v1;
using ServicesLibrary.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.ServiceImplementation.v1
{
    public class EmployeeService : IEmployeeService
    {
        public async Task<List<Employee>> GetEmployees()
        {
            return await HttpVerbs.GetAsync<List<Employee>>("https://interview-assessment-1.realmdigital.co.za/employees");
        }

        public async Task<List<int>> IgnoreEmployees()
        {
            return await HttpVerbs.GetAsync<List<int>>("https://interview-assessment-1.realmdigital.co.za/do-not-send-birthday-wishes");
        }
    }
}
