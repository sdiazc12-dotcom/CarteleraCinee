using System;

namespace CarteleraCinee

{
    public class Funcion
    {
        public int Id { get; set; }
        public string Pelicula { get; set; } = string.Empty;
        public string Sala { get; set; } = string.Empty;
        public decimal Precio { get; set; }

        public override string ToString()
        {
            return $"{Id}. {Pelicula} ({Sala}) - Q {Precio:N2}";
        }
    }
}