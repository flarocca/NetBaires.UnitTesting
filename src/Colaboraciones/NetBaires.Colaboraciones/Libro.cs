namespace NetBaires.Colaboraciones
{
    public class Libro
    {
        public string Titulo { get; }
        public string Descripcion { get; }
        public int Anio { get; }

        public Libro(string titulo, string descripcion, int anio)
        {
            Titulo = titulo;
            Descripcion = descripcion;
            Anio = anio;
        }
    }
}
