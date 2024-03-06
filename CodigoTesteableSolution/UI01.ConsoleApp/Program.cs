using BLL.ClassLibrary.Model.Documento;

namespace UI01.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var correo = "direccion_de_correo@soy.sena.edu.co";

            var documento = new Documento();
            documento.EscribirTitulo("Documento01 de prueba");
            documento.EscribirCuerpo("Cuerpo del documento de prueba 01");
            documento.EnviarPorCorreo(correo);

            Console.ReadKey();

        }
    }
}