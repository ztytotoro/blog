using Mail.Service;

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

            service.SendEmail(
                "",
                new MailContent
                {
                    Subject = "Test Mail",
                    Content = "This is a test mail"        
                }
            );
        }
    }
}
