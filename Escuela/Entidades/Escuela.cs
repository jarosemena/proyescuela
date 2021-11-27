using System;
using System.Collections.Generic;
using System.Text;

namespace CoreEscuela.Entidades
{
    public class Escuela
    {
        #region Properties
        public string UniqueId { get; set; }

        public string Nombre { set; get; }

        public int AñoDeCreacion { set; get; }

        public string País { get; set; }

        public string Ciudad { get; set; }

        public TiposEscuela TipoEscuela { get; set; }

        public List<Curso> Cursos { get; set; }
        #endregion Properties

        #region Metodos
        public Escuela(string nombre, int año) => (Nombre, AñoDeCreacion, UniqueId) = (nombre, año, Guid.NewGuid().ToString());
       

        public Escuela(string nombre, int año, string país = "Panamá", string ciudad = "Panamá", TiposEscuela tipoescuela = TiposEscuela.Primaria)
        {
            Nombre = nombre;
            AñoDeCreacion = año;
            País = país;
            Ciudad = ciudad;
            TipoEscuela = tipoescuela;
            UniqueId = Guid.NewGuid().ToString();

        }

        public override string ToString()
        {
            return $"Nombre: \"{Nombre}\", Tipo: \"{TipoEscuela}\" {System.Environment.NewLine}País: \"{País}\", Ciudad: \"{Ciudad}\" ";
        }

        #endregion Metodos
    }
}
