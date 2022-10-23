using System.Net;
using System.Net.Mail;
<<<<<<< HEAD
=======
using System.Threading;
>>>>>>> Cesar
using System.Web.Configuration;

namespace ElCaminoDeCostaRica.Models
{
    public class Mail
    {
        public Mail() { }
        public void sendRegisterCode (string destinationEmail, string code)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.To.Add(new MailAddress(destinationEmail));
                message.From = new MailAddress(WebConfigurationManager.AppSettings["MailUser"], "El Camino de Costa Rica");
                const string subject = "Código de registro - El Camino CR";
                message.Subject = subject;
                string body = "<h3>Estimado(a): usuario<br /><p class='text-decoration: none'>El código de confirmación es:</p>";
                code = "<h2>" + code + "</h2>";
                const string reminder = "<p><b>Nota:</b> Tiene 3 intentos para colocar este código," +
                    " en caso de agotarlos, debe realizar el registro nuevamente</p> <br /> <br />" +
                    "<img src='https://2.bp.blogspot.com/-C61IxecR2Eg/WuCsEe_RTfI/AAAAAAAAOWI/05upIlSsbmY7zq6C3nZLanfCPiAeeSYfwCLcBGAs/s1600/El+Camino+de+Costa+Rica.jpg' width='200' height='150' >" +
                    "<h3>El Camino de Costa Rica</h3>";
                message.Body = body + code + reminder;
                message.IsBodyHtml = true;


                using (var smtp = new SmtpClient())
                {
                    smtp.UseDefaultCredentials = false;
                    var credentials = new NetworkCredential
                    {
                        UserName = WebConfigurationManager.AppSettings["MailUser"],
                        Password = WebConfigurationManager.AppSettings["MailPassword"],
                    };
                    smtp.Credentials = credentials;
                    smtp.Host = WebConfigurationManager.AppSettings["SMTPServer"];
                    smtp.Port = int.Parse(WebConfigurationManager.AppSettings["SMTPPort"]);
                    smtp.EnableSsl = true;
                    

                    smtp.Send(message);
                }
            }
            catch (SmtpException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
<<<<<<< HEAD
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
        }
=======
                System.Diagnostics.Debug.WriteLine(e.Data);
            }
        }

        public void sendInscriptionCode (string destinationEmail, string code, string stageName)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.To.Add(new MailAddress(destinationEmail));
                message.From = new MailAddress(WebConfigurationManager.AppSettings["MailUser"], "El Camino de Costa Rica");
                const string subject = "Código de inscripción - El Camino CR";
                message.Subject = subject;
                string body = "<h3>Estimado(a): usuario<br /><p class='text-decoration: none'>Se ha registrado correctamente en la etapa <b>" + stageName
                   + "</b> <br />El código de inscripción es:</p>";
                code = "<h2>" + code + "</h2>";
                const string reminder = "<p>Recuerde que con este código puede realizar las distintas encuestas disponibles" +
                    " de los servicios durante la etapa.</p> <br /> <br />" +
                    "<img src='https://2.bp.blogspot.com/-C61IxecR2Eg/WuCsEe_RTfI/AAAAAAAAOWI/05upIlSsbmY7zq6C3nZLanfCPiAeeSYfwCLcBGAs/s1600/El+Camino+de+Costa+Rica.jpg' width='200' height='150' >" +
                    "<h3>El Camino de Costa Rica</h3>";
                message.Body = body + code + reminder;
                message.IsBodyHtml = true;


                using (var smtp = new SmtpClient())
                {
                    smtp.UseDefaultCredentials = false;
                    var credentials = new NetworkCredential
                    {
                        UserName = WebConfigurationManager.AppSettings["MailUser"],
                        Password = WebConfigurationManager.AppSettings["MailPassword"],
                    };
                    smtp.Credentials = credentials;
                    smtp.Host = WebConfigurationManager.AppSettings["SMTPServer"];
                    smtp.Port = int.Parse(WebConfigurationManager.AppSettings["SMTPPort"]);
                    smtp.EnableSsl = true;


                    smtp.Send(message);
                }
            }
            catch (SmtpException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.ToString());
            }
}
>>>>>>> Cesar
    }
}