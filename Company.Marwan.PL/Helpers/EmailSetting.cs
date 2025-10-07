using System.Net;
using System.Net.Mail;

namespace Company.Marwan.PL.Helpers
{
    public static class EmailSetting
    {

        public static bool SendEmail(Email email)
        {
            // Mail Server : Gmail 
            //SMTP 

            try
            {
                var client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("marawanelbably9@gmail.com", "eohgahqhctoklrvq"); // sender
                client.Send("marawanelbably9@gmail.com", email.To, email.Subject, email.Body);
                return true;


            }
            catch (Exception ex) {
                return false;
            
            }

        }
        



    }
}
