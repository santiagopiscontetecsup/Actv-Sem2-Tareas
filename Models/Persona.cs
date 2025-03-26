namespace Actv_Sem2_TareaGestion.Models;

public class Persona
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    
    public List<Tarea> Tareas { get; set; }= new List<Tarea>();
}