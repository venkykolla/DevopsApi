using Microsoft.AspNetCore.Mvc;
using Modals;
using ServicesLibrary.ServiceContracts.v1;
using ServicesLibrary.Utilites;
using System.Net;

namespace RealMAssesment.API.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EmployeeComsController : ControllerBase
    {
        private readonly IInternalComs _internalComs;
        private readonly IEmployeeService _employeeService;

        public EmployeeComsController(IInternalComs internalComs, IEmployeeService employee)
        {
            _internalComs = internalComs;
            _employeeService = employee;            
        }

        [HttpPost()]
        [Route("SendAnniversaryWishes")]
        public IActionResult SendAnniversaryWishes([FromBody]MailRequest request)
        {
            return new ContentResult()
            {
                StatusCode = Convert.ToInt32(HttpStatusCode.ServiceUnavailable),
                Content = "Service Not Available. Please try again later."
            };
        }


        [HttpPost()]
        [Route("SendBirthDayWishes")]
        public IActionResult SendBirthDayWishes([FromBody] MailRequest request)
        {
            var employees = _employeeService.GetEmployees();
            var ignoreList = _employeeService.IgnoreEmployees();
            var result = employees.Result;
            var ignoreresult=ignoreList.Result;
            result.RemoveAll(item => ignoreresult.Contains(item.id));
            if (result != null&& result.Count() > 0)
            {
                var dllist = new List<Employee>();
                foreach (var em in result)
                {
                    var dob = em.dateOfBirth.GetDateTime();
                    var startDate = em.employmentStartDate.GetDateTime();
                    var endDate = em.employmentEndDate.GetDateTime();

                    if ((dob.Month == DateTime.Now.Month && dob.Day == DateTime.Now.Day) &&//check Dob Today
                        em.lastBirthdayNotified.GetDateTime().Date != DateTime.Now.Date && //check if already notified today
                        (startDate != DateTime.MinValue && startDate.Date <= DateTime.Now.Date) && //employee stared today or before
                        (endDate == DateTime.MinValue || endDate.Date >= DateTime.Now.Date) //if end date date not mentioned considering employee is active
                        )
                    {
                        dllist.Add(em);
                    }                   
                }
                if (dllist.Count() > 0)
                    _internalComs.SendBirthdayWishes(dllist, request);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
