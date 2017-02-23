using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace consolaCorreo

{
    class GMail
    {
        SmtpClient server = new SmtpClient("smtp.gmail.com", 587);
        public GMail()
        {
            server.Credentials = new System.Net.NetworkCredential("uyarikuna@gmail.com", "uyarikuna2015");
            server.EnableSsl = true;
        }
        public void MandarCorreo(MailMessage mensaje)
        {
            server.Send(mensaje);
        }
    }
}
