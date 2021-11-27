using System;
using System.Collections.Generic;
using System.Text;


namespace CoreEscuela.Util
{
    public static class Printer
    {
        public static void DigujarLinea(int tamaño = 20)
        {
            Console.WriteLine("".PadLeft(tamaño, '='));
        }

        public static void WriteTitle (string Titulo )
        {
            int largo = Titulo.Length + 4;
            Printer.DigujarLinea(largo );
            Console.WriteLine($"| {Titulo} |");
            Printer.DigujarLinea(largo );
            Beep();
        }

        public static void Beep(int hz=900, int tiempo =100, int cantidad = 1)
        {
            while (cantidad-- > 0 )
            {
                Console.Beep(hz, tiempo);
               
            }
        }
    }
}
