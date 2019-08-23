using System;
using System.Collections.Generic;
using System.Linq;

namespace NetBaires.Constructores
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

            if(fechaDeNacimiento < DateTime.MinValue) throw new ArgumentException($"Fecha de nacimiento no puede ser menor a {DateTime.MinValue.ToString("dd-MM-yyyy")}.", nameof(fechaDeNacimiento));

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

        private static int CalcularEdad(DateTime fechaDeNacimiento)
        {
            var hoy = DateTime.Today;
            var edad = hoy.Year - fechaDeNacimiento.Year;

            if (hoy.Date > hoy.AddYears(-edad)) edad--;

            return edad;
        }
    }
}
