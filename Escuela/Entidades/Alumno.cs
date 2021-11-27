using System;
using System.Collections.Generic;
using System.Text;

namespace CoreEscuela.Entidades
{
    public class Alumno
    {
        #region Properties
        public string UniqueId { get; set; }

        public string Nombre { get; set; }

        #endregion 

        #region Metodos

        public Alumno() => UniqueId = Guid.NewGuid().ToString();
        
        #endregion
    }
}
