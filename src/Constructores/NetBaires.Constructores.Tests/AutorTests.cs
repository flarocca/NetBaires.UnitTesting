using System;
using Xunit;

namespace NetBaires.Constructores.Tests
{
    public class AutorTests
    {
        [Fact]
        public void Ctor_NombreNull_ThrowsArgumentNullException()
        {
            //Arrange
            string nombreNull = null;

            //Act
            Exception ex = Assert.Throws<ArgumentNullException>
                (() => new Autor(nombreNull, "apellido", new DateTime(1987, 03, 01)));

            //Assert
            Assert.Contains("Nombre no puede ser null.", ex.Message);
        }

        [Fact]
        public void Ctor_ParametrosValidos_ConstruyeAutorValido()
        {
            //Arrange

            //Act

            //Assert
            Assert.True(false);
        }
    }
}
