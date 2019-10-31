using Mail.Service;
using System;

namespace SmtpClient
{
    class Program
    {
        static void Main(string[] _args)
        {
            var service = new MailService(new MsCredential
            {
                Host = "",
                UserName = "",
                Password = "",
                Sender = new MsAddress
                {
                    Address = "",
                    DisplayName = ""
                }
            });

            try
            {
                service.SendEmail(
                    "",
                    new MailContent
                    {
                        Subject = "Test Mail",
                        Content = "This is a test mail"
                    }
                );
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
