using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace NetBaires.Funciones.Tests
{
    public class AutorTests
    {
        [Fact]
        public void EditoLibro_LibroPerteneceAutor_RetornaTrue()
        {
            //Arrange
            var titulo = "tituloLibro";
            var libros = new List<Libro>
            {
                new Libro(titulo, "descripcion", 2019),
                new Libro("otro titulo", "descripcion", 2000)
            };
            var autor = new Autor("nombre", "apellido", DateTime.Now, libros);

            //Act
            var resultadoActual = autor.EditoLibro(titulo);

            //Assert
            Assert.True(resultadoActual);
        }

        [Fact]
        public void AgregarLibro_LibroNoExiste_LibroEsAgregado()
        {
            //Arrange
            var nuevoLibro = new Libro("nuevo", "libro", 2019);
            var libros = new List<Libro>
            {
                new Libro("otro titulo", "descripcion", 2000)
            };
            var autor = new Autor("nombre", "apellido", DateTime.Now, libros);

            //Act
            autor.AgregarLibro(nuevoLibro);

            //Assert
            Assert.Contains(nuevoLibro, autor.Libros);
        }
    }
}
