using Microsoft.Extensions.Configuration;
using MimeKit;
using Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ServicesLibrary.Utilites
{
    public class Communication
    {       
        public static async Task SendEmail(MailRequest mailRequest,MailSettings settings)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(settings.Mail);
            foreach (string email in mailRequest.ToEmail)
            {
                message.To.Add(new MailAddress(email));
            }
            message.Subject = mailRequest.Subject;
            message.IsBodyHtml = true; //to make message body as html  
            message.Body = mailRequest.Body;
            smtp.Port = Convert.ToInt32(settings.Port);
            smtp.Host = settings.Host;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(settings.Mail, settings.Password);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(message);            
        }
    }
}
