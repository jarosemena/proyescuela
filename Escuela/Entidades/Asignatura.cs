using System;
using System.Collections.Generic;
using System.Text;

namespace CoreEscuela.Entidades
{
    public class Asignatura
    {
        #region Properties
        public string UniqueId { get; set; }

        public string Nombre { get; set; }

        #endregion 

        #region Metodos

        public Asignatura() => UniqueId = Guid.NewGuid().ToString();

        #endregion
    }
}
