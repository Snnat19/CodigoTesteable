using BLL.ClassLibrary.Model.Email;
using BLL.ClassLibrary.Model.Firma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.ClassLibrary.Model.Documento
{
    public class Documento
    {
        //atributo, campos de la clase
        private string _titulo;
        private string _cuerpo;

        //metodos
        public void EscribirTitulo(string titulo) {
            this._titulo = titulo;
        }

        public void EscribirCuerpo(string cuerpo)
        {
            this._cuerpo = cuerpo;
        }

        public string GenerarDocumento() 
        {
            var generarFirma = new GeneradorFirma(); //¡Atencion! Siempre que vea una linea de codigo donde se utilice el operador new se genera alto acoplamiento. sospeche que ahi estamos implementando una mala practica llamada acoplamiento. Donde documento queda dependiendo de GeneradorFirma y si fuera un servicio externo entre otras y noestuviese funcionando, aparte de que la app dejaria de funcionar los test dejarian de correr, si los tests no correr va a tener muchas consecuencias
            return _titulo + _cuerpo + generarFirma.Firma();
        }
        public void EnviarPorCorreo(string email) // ¡Atencion! Este método viola el principio de responsabilidad unica
        {
            using (EmailSender emailSender = new EmailSender())
            {
                emailSender.Enviar(email, GenerarDocumento());
             }
        }
        
    }
}
