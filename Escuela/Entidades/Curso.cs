using System;
using System.Collections.Generic;
using System.Text;

namespace CoreEscuela.Entidades
{
    public class Curso
    {
        #region Properties

        public string UniqueId { get; set; }

        public string Nombre { get; set; }

        public TiposJornadas Jornada { get; set; }

        public List<Asignatura> Asignaturas { get; set; }

        public List<Alumno> Alumnos { get; set; }

        public List<Evaluaciones> Evaluaciones { get; set;}


        #endregion 

        #region Metodos

        public Curso() => (UniqueId,Asignaturas,Alumnos,Evaluaciones ) = (Guid.NewGuid().ToString(),new List<Asignatura>(), new List<Alumno>() , new List<Evaluaciones>());

        #endregion 

    }

    public enum TiposJornadas
    {
        Mañana,
        Tarde, 
        Noche
    }
}
