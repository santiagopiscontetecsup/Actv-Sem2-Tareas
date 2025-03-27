using System.Text.Json.Serialization;

namespace Actv_Sem2_TareaGestion.Models;

public class Tarea
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Estado { get; set; }
    
    
    [JsonIgnore]
    public int? PersonaId { get; set; }
    [JsonIgnore]
    public Persona? Persona { get; set; }
}