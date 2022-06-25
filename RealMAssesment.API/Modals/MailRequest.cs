using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modals
{
    public class MailRequest
    {
        public List<string> ToEmail { get; set; }        
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Sender { get; set; }
        //public List<IFormFile> Attachments { get; set; }
    }
}
