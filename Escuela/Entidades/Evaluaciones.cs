using System;
using System.Collections.Generic;
using System.Text;

namespace CoreEscuela.Entidades
{
    public class Evaluaciones
    {
        #region Properties
        public string UniqueId { get; set; }

        public string Nombre { get; set; }

        public Alumno Alumno { get; set; }

        public Asignatura Asignatura { get; set; }
        
        public float Nota { get; set; }

        #endregion 

        #region Metodos

        public Evaluaciones() => UniqueId = Guid.NewGuid().ToString();

        #endregion
    }
}
