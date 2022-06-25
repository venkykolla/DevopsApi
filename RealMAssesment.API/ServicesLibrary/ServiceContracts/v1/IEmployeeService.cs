using Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.ServiceContracts.v1
{
    public interface IEmployeeService
    {
        public Task<List<Employee>> GetEmployees();
        public Task<List<int>> IgnoreEmployees();
    }
}
