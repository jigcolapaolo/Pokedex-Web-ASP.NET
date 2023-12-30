using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EmailService
    {
        private MailMessage email;      /*REPRESENTA EL MENSAJE QUE SE ENVIARA POR MEDIO DEL SMTPCLIENT*/
        private SmtpClient server;        /*PERMITE QUE LAS APLICACIONES ENVIEN EMAILS CON EL PROTOCOLO SMTP*/
        
        public EmailService()           /*CONSTRUCTOR, ESTABLECE LA CONEXION CON EL SERVIDOR Y LA CUENTA QUE ENVIARA LOS MENSAJES*/
        {
            server = new SmtpClient();
            //CREDENCIALES (EMAIL Y CONTRASEÑA) DESDE DONDE ENVIARE EL MENSAJE
            server.Credentials = new NetworkCredential("jaunoitto@gmail.com", "jowc ybfx dbli sejr");    /*("USER", "PASSWORD")*/
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";

        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            //NOMBRE DE LA CUENTA QUE VERAN LOS REMITENTES, LA CUENTA REAL ES MARCOPROGRAMA3@GMAIL.COM
            email.From = new MailAddress("noresponder@pokedexweb.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;                /*SE PUEDE ARMAR EL CORREO CON CODIGO HTML*/
            email.Body = cuerpo;
            //email.Body = "<h1>Mensaje Enviado</h1> <p>" + cuerpo + "</p><br>Que tenga buen dia!";

        }

        public void enviarMail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
    }
}
