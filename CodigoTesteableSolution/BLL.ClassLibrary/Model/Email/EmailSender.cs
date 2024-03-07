using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ClassLibrary.Model.Email
{
    public class EmailSender : IDisposable
    {
        private SmtpClient smtpClient; //Suponiendo que SmtpClient se utiliza para enviar correos electrónicos

        public EmailSender(SmtpClient @object)
        {
            //Inicialice el SmtpClient o cualquier otro recurso necesario para enviar correo electrónico
            smtpClient = new SmtpClient("yourSMTPServer");
            //Se puede realizar una configuración adicional para SmtpClient aquí
        }

        public void Enviar(string email, string documento, string asunto)
        {
            //Implementar la lógica para enviar el correo electrónico con el documento proporcionado
            // Este es un ejemplo básico; es posible que deba personalizarlo según sus requisitos
            var mailMenssage = new MailMessage("your@email.com", email, "Subject", documento);
            smtpClient.Send(mailMenssage);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                //publica recursos administrados aquí
                smtpClient.Dispose();
            }
            //
        }

        //Destructor
        ~EmailSender() 
        { 
            Dispose(false);
        }
    }
}
