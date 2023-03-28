using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace smntp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            SmtpClient smtpClient = new SmtpClient();
            try
            {

                MimeMessage message = new MimeMessage();

                message.From.Add(new MailboxAddress("test", "dadada@gmail.com"));
                message.To.Add(MailboxAddress.Parse("arkashadasha23@gmail.com"));

                message.Subject = "андрюха лошара";
                message.Body = new TextPart("plain")
                {
                    Text = @"test"
                };
                //smtpClient.SslProtocols = System.Security.Authentication.SslProtocols.Tls;
              //  smtpClient.CheckCertificateRevocation = false;
                smtpClient.Connect("smtp.transset.ru", 465, true);  
                smtpClient.Authenticate("gerasimov_na@transset.ru", "6RWQFEv4D8");
                smtpClient.Send(message);
                Console.WriteLine("ok");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                smtpClient.Disconnect(true);
                smtpClient.Dispose();
            }
        }
    }
}
