using Microsoft.Extensions.Configuration;
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
    public class InternalComs : IInternalComs
    {
        private readonly IConfiguration _config;
        private MailSettings _mailSettings;

        public InternalComs(IConfiguration configuration)
        {
            _config = configuration;
            _mailSettings = new MailSettings();
            _config.GetSection("MailSettings").Bind(_mailSettings);//read email settings
        }
        public void SendAnniversaryWhishes(List<Employee> employees, MailRequest request)
        {
            //to implement
            throw new NotImplementedException();
        }

        public void SendBirthdayWishes(List<Employee> employees, MailRequest request)
        {
            MailRequest mailRequest = request == null ? new MailRequest() : request;
            mailRequest.ToEmail = mailRequest.ToEmail == null ? new List<string>() : mailRequest.ToEmail;

            if (!string.IsNullOrEmpty(mailRequest.Subject))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Happy Birthday");

                foreach (Employee employee in employees)
                {
                    sb.Append(" " + employee.name);
                    //mailRequest.ToEmail.Add(employee.emailaddress)//add email
                }
            }
            Communication.SendEmail(request, _mailSettings);//avoiding await here on purpose as we dont need call back results here.
        }
    }
}
