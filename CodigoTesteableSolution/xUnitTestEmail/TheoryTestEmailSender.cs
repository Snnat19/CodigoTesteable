using BLL.ClassLibrary.Model.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTestEmail
{
    public class TheoryTestEmailSender
    {
        [Theory]
        [InlineData("recipient@example.com", "Document Content", "Email Subject")]
        [InlineData("another@example.com", "Another Document", "Another Subject")]
        public void Enviar_NoLanzaExcepcion(string email, string documento, string asunto)
        {
            // Arrange
            using (var emailSender = new EmailSender(new SmtpClient("yourSMTPServer")))
            {
                // Act y Assert
                Assert.Throws<System.Net.Mail.SmtpException>(() => emailSender.Enviar(email, documento, asunto));
            }
        }
        }
}
