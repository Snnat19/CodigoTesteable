using BLL.ClassLibrary.Model.Firma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitTestEmail
{
    public class FactTestFirma
    {
        [Fact]
        public void Firma_ReturnsEmptyString()
        {
            // Arrange
            var generadorFirma = new GeneradorFirma();

            // Act
            string firma = generadorFirma.Firma();

            // Assert
            Assert.Equal(string.Empty, firma);
        }
    }
}
