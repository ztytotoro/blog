using System.Collections.Generic;
using System.Net.Mail;

namespace Mail.Service
{
    public class MsCredential
    {
        public string Host;
        public string UserName;
        public string Password;

        public MsAddress Sender;
    }

    public class MsAddress
    {
        public string DisplayName;
        public string Address;

        public MailAddress ToMailAddress()
        {
            if (string.IsNullOrEmpty(DisplayName))
                return new MailAddress(Address);
            return new MailAddress(Address, DisplayName);
        }
    }

    public class MailContent
    {
        public string Subject;
        public string Content;
    }

    public class MailService
    {
        private readonly string host;
        private readonly string userName;
        private readonly string password;
        private readonly MailAddress from;

        public MailService(MsCredential credential)
        {
            host = credential.Host;
            userName = credential.UserName;
            password = credential.Password;
            from = credential.Sender.ToMailAddress();
        }

        public void SendEmail(string receiver, MailContent content, List<MsAddress> cc = null)
        {
            SendEmail(new MsAddress { Address = receiver }, content, cc);
        }

        public void SendEmail(MsAddress receiver, MailContent content, List<MsAddress> cc = null)
        {
            using (var client = new SmtpClient(host)
            {
                Credentials = new System.Net.NetworkCredential(userName, password)
            })
            {
                var to = receiver.ToMailAddress();
                using (var message = new MailMessage(from, to))
                {
                    message.Body = content.Content;
                    message.BodyEncoding = System.Text.Encoding.UTF8;

                    if (!string.IsNullOrEmpty(content.Subject))
                    {
                        message.Subject = content.Subject;
                        message.SubjectEncoding = System.Text.Encoding.UTF8;
                    }

                    cc?.ForEach(addr => message.CC.Add(addr.Address));

                    try
                    {
                        client.Send(message);
                    }
                    catch(SmtpException ex)
                    {
                        throw ex;
                    }
                }
            };
        }
    }
}
