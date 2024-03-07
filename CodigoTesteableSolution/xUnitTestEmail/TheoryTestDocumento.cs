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
    public class TheoryTestDocumento
    {
        [Theory]
        [InlineData("Titulo1", "Cuerpo1", "FirmaMock1", "Titulo1Cuerpo1FirmaMock1")]
        [InlineData("Titulo2", "Cuerpo2", "FirmaMock2", "Titulo2Cuerpo2FirmaMock2")]
        public void GenerarDocumento_DeberiaGenerarDocumentoCorrecto(string titulo, string cuerpo, string firma, string resultadoEsperado)
        {
            // Arrange
            var generadorFirmaMock = new Mock<IGeneradorFirma>();
            generadorFirmaMock.Setup(g => g.Firma()).Returns(firma);

            var documento = new Documento(generadorFirmaMock.Object);
            documento.EscribirTitulo(titulo);
            documento.EscribirCuerpo(cuerpo);

            // Act
            var resultado = documento.GenerarDocumento();

            // Assert
            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}
