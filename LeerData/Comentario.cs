namespace LeerData
{
  public class Comentario
  {
    public int ComentarId { get; set; }
    public string Alumno { get; set; }
    public int Puntaje { get; set; }
    public string ComentarioText { get; set; }
    public int CursoId { get; set; }

    public Curso Curso { get; set; }
  }
}