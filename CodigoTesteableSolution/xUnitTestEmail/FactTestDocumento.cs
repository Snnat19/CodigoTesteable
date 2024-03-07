using BLL.ClassLibrary.Model.Documento;
using BLL.ClassLibrary.Model.Firma;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTestEmail
{
    public class FactTestDocumento
    {
        [Fact]
        public void GenerarDocumento_DeberiaGenerarDocumentoCorrecto()
        {
            // Arrange
            var generadorFirmaMock = new Mock<IGeneradorFirma>();
            generadorFirmaMock.Setup(g => g.Firma()).Returns("FirmaMock");

            var documento = new Documento(generadorFirmaMock.Object);
            documento.EscribirTitulo("Título de prueba");
            documento.EscribirCuerpo("Cuerpo de prueba");

            // Act
            var resultado = documento.GenerarDocumento();

            // Assert
            Assert.Equal("Título de pruebaCuerpo de pruebaFirmaMock", resultado);
        }
    }
}
