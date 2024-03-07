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
        private readonly IGeneradorFirma _generadorFirma; //ABSTRACCION

        public Documento() {}
        public Documento(IGeneradorFirma generadorFirma)//parametro que se encarga de inicializar el campo _generadorFirma
        {
            this._generadorFirma = generadorFirma;
        }

        //metodos
        public void EscribirTitulo(string titulo) {  //fenomeno de acoplamiento y cohesion
            this._titulo = titulo;
        }

        public void EscribirCuerpo(string cuerpo)
        {
            this._cuerpo = cuerpo;
        }

        public string GenerarDocumento() 
        {
            //var generarFirma = new GeneradorFirma(); CONCRECION  //¡Atencion! Siempre que vea una linea de codigo donde se utilice el operador new se genera alto acoplamiento. sospeche que ahi estamos implementando una mala practica llamada acoplamiento. Donde documento queda dependiendo de GeneradorFirma y si fuera un servicio externo entre otras y noestuviese funcionando, aparte de que la app dejaria de funcionar los test dejarian de correr, si los tests no correr va a tener muchas consecuencias
            return _titulo + _cuerpo + _generadorFirma.Firma(); //¡ATENCION! reduzco el acoplamiento y incremento la cohesion
        }
        //public void EnviarPorCorreo(string email) // ¡Atencion! Este método viola el principio de responsabilidad unica MALAS PRACTICAS
        //{
        //    using (EmailSender emailSender = new EmailSender())
        //    {
        //        emailSender.Enviar(email, GenerarDocumento());
        //     }
        //}
        
    }
}
