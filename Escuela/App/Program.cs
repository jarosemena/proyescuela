using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using CoreEscuela.App;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();

            Util.Printer.DigujarLinea();

            Console.WriteLine(engine.Escuela );
            engine.ImprimirCusosEscuela();

           
            Console.Read();
        }

      
    }
}
