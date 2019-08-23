using FakeItEasy;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace NetBaires.Colaboraciones.Tests
{
    public class AutorTests
    {
        [Fact]
        public void AgregarLibro_SinEventoLibroAgregado_LibroEsAgregado()
        {
            //Arrange
            var dummyServicioEditorial = A.Fake<IServicioEditorial>();
            var nuevoLibro = new Libro("nuevo", "libro", 2019);
            var libros = new List<Libro>
            {
                new Libro("otro titulo", "descripcion", 2000)
            };
            var autor = new Autor(
                "nombre", "apellido", DateTime.Now, libros, dummyServicioEditorial);

            //Act
            autor.AgregarLibro(nuevoLibro);

            //Assert
            Assert.Contains(nuevoLibro, autor.Libros);
        }

        [Fact]
        public void AgregarLibro_ServicioLanzaException_EventoErrorAgregandoLibroEsLlamado()
        {
            //Arrange
            var mockEventoLibroAgregado = A.Fake<Action<Libro, Exception>>();
            var nuevoLibro = new Libro("nuevo", "libro", 1949);
            var libros = new List<Libro>
            {
                new Libro("otro titulo", "descripcion", 2000)
            };
            var exceptionEsperada = new Exception("error esperado");

            var fakeServicioEditorial = A.Fake<IServicioEditorial>();
            A.CallTo(() => fakeServicioEditorial.LibroClasicoAgregado(A<Libro>.Ignored))
                .Throws(exceptionEsperada);

            var autor = new Autor(
                "nombre", "apellido", DateTime.Now, libros, fakeServicioEditorial);

            autor.ErrorAgregandoLibro += mockEventoLibroAgregado;

            //Act
            autor.AgregarLibro(nuevoLibro);

            //Assert
            A.CallTo(() => mockEventoLibroAgregado.Invoke(nuevoLibro, exceptionEsperada))
                .MustHaveHappened();
        }

        [Fact]
        public void AgregarLibro_LibroEsClasico_ServicioEditorialEsLlamado()
        {
            //Arrange
            var mockServicioEditorial = A.Fake<IServicioEditorial>();
            var nuevoLibroClasico = new Libro("libro", "clasico", 1949);
            var libros = new List<Libro>
            {
                new Libro("otro titulo", "descripcion", 2000)
            };
            var autor = new Autor(
                "nombre", "apellido", DateTime.Now, libros, 
                mockServicioEditorial);

            //Act
            autor.AgregarLibro(nuevoLibroClasico);

            //Assert
            A.CallTo(
                () => mockServicioEditorial.LibroClasicoAgregado(nuevoLibroClasico))
                    .MustHaveHappened();
        }
    }
}
