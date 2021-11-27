using CoreEscuela.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using CoreEscuela.Util;
using System.Linq;

namespace CoreEscuela.App
{
   public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine()
        {
            
        }

      

        public void Inicializar()
        {

            Entidades.Escuela escuela = (Escuela) = new Entidades.Escuela("Jose .J Arosemena", 1988,
                ciudad: "Panamá",
                país: "Panamá",
                tipoescuela: Entidades.TiposEscuela.Primaria
            );

            List<Curso> listaCursos = InicializarCursos();

            AsignarCursos(escuela, listaCursos);
            AsignarAsignaturas();
            AsignarAlumnos();
            AsignarEvaluaciones();

        }

        private void AsignarEvaluaciones()
        {
            string[] nombrenotas = { "Test1","Test2","Test3","Quiz","ExamenFinal" };

            foreach (var curso in Escuela.Cursos)
            {
                
                var listaEvaluaciones = from asignatura in curso.Asignaturas
                from estudiante in curso.Alumnos
                from nomnotas in nombrenotas
                select new Evaluaciones { Nombre = nomnotas, Alumno = estudiante, Asignatura = asignatura, Nota = randomnota() };

                foreach (Evaluaciones ev in listaEvaluaciones)
                {
                    curso.Evaluaciones.Add(ev);
                        }
            }

        }

        private float randomnota()
        {
            float resp ;
            Random random = new Random();
             resp = (float)random.Next(0, 5) + (float)Math.Round(random.NextDouble(),2);
            return resp;
        }

        private List<Alumno> CrearAlumnos(int numalumnos)
        {
            string[] nombreF = { "Ana", "Diana", "Liz" };
            string[] segundonombreF = { "Maria", "Lucrecia", "Carolina", "Adriana" };
            string[] apellido = { "Arosemena", "Juarez", "Robles", "Solis", "Samaniego" };
            string[] segundoapellido = { "Cortez", "Rios", "Aguilar", "Moreno", "Castillo" };

            string[] nombreM = { "Elias", "Juan", "Jose" };
            string[] segundonombreM = { "Felipe", "Carlos", "Diego","Daniel" };

            var listaAlumnosF = from n1 in nombreF
                                from n2 in segundonombreF
                                from a1 in apellido
                                from a2 in segundoapellido
                                select new Alumno { Nombre = $"{n1} {n2} {a1} {a2}" };

            var listaAlumnosM = from n1 in nombreM
                                from n2 in segundonombreM
                                from a1 in apellido
                                from a2 in segundoapellido
                                select new Alumno { Nombre = $"{n1} {n2} {a1} {a2}" };

            List<Alumno> listaAlumnos = new List<Alumno>();
            listaAlumnos.AddRange(listaAlumnosF);
            listaAlumnos.AddRange(listaAlumnosM);

            return listaAlumnos.OrderBy(x => x.UniqueId).Take(numalumnos).ToList();
        }

        private void AsignarAlumnos()
        {
            foreach (var curso in Escuela.Cursos)
            {
                Random random = new Random();
                int numrandom = random.Next(10,45);                  
                curso.Alumnos = CrearAlumnos(numrandom);
            }

            }

        private void AsignarAsignaturas()
        {
            foreach(var curso in Escuela.Cursos )
            {
                List<Asignatura> listasignatura = new List<Asignatura>()
                {
                    new Asignatura {Nombre="Matemáticas"},
                    new Asignatura {Nombre="Educacion Física"},
                    new Asignatura {Nombre="Castellano"},
                    new Asignatura {Nombre="Ciencias Naturales"},
                    new Asignatura {Nombre="Español"}
                };
                curso.Asignaturas.AddRange(listasignatura);

            }
        }

        public List<Curso> InicializarCursos()
        {
            List<Curso> listaCursos = new List<Curso>
            {
                new Curso { Nombre = "101", Jornada = TiposJornadas.Mañana },
                new Curso { Nombre = "201", Jornada = TiposJornadas.Mañana },
                new Curso { Nombre = "301", Jornada = TiposJornadas.Mañana },
                new Curso { Nombre = "401", Jornada = TiposJornadas.Tarde },
                new Curso { Nombre = "501", Jornada = TiposJornadas.Tarde }
            };

            return listaCursos;
        }

        public bool AsignarCursos(Escuela escuela, List<Curso> Cursos)
        {
            bool respuesta = false;
            escuela.Cursos = Cursos;

            return respuesta;
        }
        public bool AsignarCursos(Escuela escuela, Curso Curso)
        {
            bool respuesta = false;
            escuela.Cursos.Add(Curso);

            return respuesta;
        }

        public void ImprimirCusosEscuela()
        {
            Printer.WriteTitle("Cursos de la Escuela");
           
            if (Escuela?.Cursos != null)
            {
                foreach (var curso in Escuela.Cursos )
                {
                    Console.WriteLine($"Nombre: \"{curso.Nombre}, ID:\"{curso.UniqueId}\" ");

                    Printer.WriteTitle($"Evaluaciones del Cursos \"{curso.Nombre}\"");
                    string oldasignatura = "";
                    foreach (var evaluacion in curso.Evaluaciones.OrderBy(x=>x.Alumno.Nombre).ThenBy(x=>x.Asignatura.UniqueId))
                    {
                        if (oldasignatura != evaluacion.Asignatura.UniqueId)
                        {
                            Console.WriteLine(System.Environment.NewLine);
                            Printer.DigujarLinea(50);
                            Console.WriteLine($"    Alumno: \"{evaluacion.Alumno.Nombre}\", Asignatura: \"{evaluacion.Asignatura.Nombre }\" ");
                            Printer.DigujarLinea(50);
                        }
                            Console.WriteLine($"         {evaluacion.Nombre} = {evaluacion.Nota} ");

                        oldasignatura = evaluacion.Asignatura.UniqueId;

                    }

                   
                }
                Printer.WriteTitle("Termina Impresion de Cursos");
            }
        }

       
    }
}
