using Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.ServiceContracts.v1
{
    public interface IInternalComs
    {
        public void SendBirthdayWishes(List<Employee> employees, MailRequest request);
        public void SendAnniversaryWhishes(List<Employee> employees, MailRequest request);

    }
}
