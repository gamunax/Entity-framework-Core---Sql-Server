using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace LeerData
{
  class Program
  {
    static void Main(string[] args)
    {
      using (var db = new AppVentaCursosContext())
      {
        // * table many to many
        var cursos = db.Curso
          .Include(curso => curso.InstructorLink)
          .ThenInclude(cursoInstructor => cursoInstructor.Instructor);

          foreach(Curso curso in cursos) {
            Console.WriteLine(curso.Titulo);
            foreach(CursoInstructor cursoIntructor in curso.InstructorLink) {
              Console.WriteLine("*************" + cursoIntructor.Instructor.Nombre);
            }
          }

        // * table one to many
        // var cursos = db.Curso.Include(comentario => comentario.ComentarioLista).AsNoTracking();
        // foreach (Curso curso in cursos)
        // {
        //   Console.WriteLine(curso.Titulo);
        //   foreach (Comentario comentario in curso.ComentarioLista)
        //   {
        //     Console.WriteLine("***************" + comentario.ComentarioTexto);
        //   }
        // }

        // * table one to one
        // var cursos = db.Curso.Include(precio => precio.PrecioPromocion).AsNoTracking();
        // foreach (Curso curso in cursos)
        // {
        //   Console.WriteLine(curso.Titulo + "-----" + curso.PrecioPromocion.PrecioActual);
        // }

        // * all table
        //   var cursos = db.Curso.AsNoTracking();
        //   foreach(Curso curso in cursos) {
        //       Console.WriteLine(curso.Titulo);
        //   }
      }
    }
  }
}
