using System;
using System.Collections.Generic;
using System.Linq;

namespace NetBaires.Funciones
{
    public class Autor
    {
        public string Nombre { get; }

        public string Apellido { get; }

        public DateTime FechaDeNacimiento { get; }

        public int Edad { get; }

        private List<Libro> _libros;
        public IReadOnlyCollection<Libro> Libros => _libros;

        public Autor(string nombre, string apellido, DateTime fechaDeNacimiento)
        {
            if (nombre == null) throw new ArgumentNullException(nameof(nombre), "Nombre no puede ser null.");
            if (apellido == null) throw new ArgumentNullException(nameof(apellido), "Apellido no puede ser null.");

            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("Nombre no puede ser un string vacío.", nameof(nombre));
            if (string.IsNullOrWhiteSpace(apellido)) throw new ArgumentException("Apellido no puede ser un string vacío.", nameof(apellido));

            if (fechaDeNacimiento < DateTime.MinValue) throw new ArgumentException($"Fecha de nacimiento no puede ser menor a {DateTime.MinValue.ToString("dd-MM-yyyy")}.", nameof(fechaDeNacimiento));

            Nombre = nombre;
            Apellido = apellido;
            FechaDeNacimiento = fechaDeNacimiento;
            Edad = CalcularEdad(fechaDeNacimiento);
        }

        public Autor(string nombre, string apellido, DateTime fechaDeNacimiento, IEnumerable<Libro> libros)
            : this(nombre, apellido, fechaDeNacimiento)
        {
            if (libros == null) throw new ArgumentNullException(nameof(libros), "Libros no puede ser null.");
            if (libros.Count() == 0) throw new ArgumentException(nameof(libros), "Libros no puede ser una colección vacía.");

            _libros = libros.ToList();
        }

        public bool EditoLibro(string titulo)
            => _libros.Any(libro => libro.Titulo == titulo);

        public int ObtenerCantidadDeLibros()
            => _libros.Count();

        public IReadOnlyCollection<Libro> ObtenerLibrosPorAnio(int anio)
            => _libros.Where(libro => libro.Anio == anio).ToList();

        public void AgregarLibro(Libro libro)
        {
            if(_libros.Contains(libro) == false)
                _libros.Add(libro);
        }

        public void EliminarLibro(Libro libro)
        {
            if (_libros.Contains(libro) == true)
                _libros.Remove(libro);
        }

        public void AgregarLibros(IEnumerable<Libro> libros)
        {
            foreach (var libro in libros.ToList())
            {
                AgregarLibro(libro);
            }
        }

        private static int CalcularEdad(DateTime fechaDeNacimiento)
        {
            var hoy = DateTime.Today;
            var edad = hoy.Year - fechaDeNacimiento.Year;

            if (hoy.Date > hoy.AddYears(-edad)) edad--;

            return edad;
        }
    }
}
