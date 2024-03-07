using BLL.ClassLibrary.Model.Documento;
using BLL.ClassLibrary.Model.Email;
using BLL.ClassLibrary.Model.Firma;

namespace UI01.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Destinatario del correo
            var correo = "direccion_de_correo@soy.sena.edu.co";

            //Inversion de control e inyeccion de dependencia por el constructor
            var generadorFirma = new GeneradorFirma();

            //generar documento (responsabilidad 1)
            var documento = new Documento(generadorFirma);
            documento.EscribirTitulo("Documento01 de prueba");
            documento.EscribirCuerpo("Cuerpo del documento de prueba 01");

            //documento.EnviarPorCorreo(correo);  (responsabilidad 2)
            using (var emailsender = new EmailSender())
            {
                emailsender.Enviar(correo, documento.GenerarDocumento());
            }

            Console.ReadKey();

        }
    }
}