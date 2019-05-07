using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace MailSender.ConsoleTest
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Cashcet Crono = new Cashcet();
            using (var message = new MailMessage(Crono.Adress, Crono.Adress1))
            {
                message.From = new MailAddress("shmachilin@yandex.ru", "От меня");
                message.To.Add(new MailAddress("shmachilin@gmail.com", "Ко мне"));

                message.Subject = "Заголовок сообщения";
                message.Body = "Текст сообщения";

                message.Attachments.Add(new Attachment("FileName.txt"));

                SmtpClient client = null;
                try
                {
                    client = new SmtpClient(Crono.SMTP, Crono.SMTPport);
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("UserName", "Password");

                    client.Send(message);
                }
                finally
                {
                  if(client != null)
                        client.Dispose();
                }

            }

            //Console.ReadLine();
        }

        
    }
}
