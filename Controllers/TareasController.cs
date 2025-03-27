using Microsoft.AspNetCore.Mvc;
using Actv_Sem2_TareaGestion.Models;
using Actv_Sem2_TareaGestion.Data;

namespace Actv_Sem2_TareaGestion.Controllers;

[ApiController]
[Route("api/tareas")]
public class TareasController : ControllerBase
{
    // Crear una tarea sin asignarla a una persona
    [HttpPost]
    public IActionResult CrearTarea([FromBody] Tarea nuevaTarea)
    {
        nuevaTarea.Id = Repositorio.Tareas.Count + 1; // Generar ID simple
        nuevaTarea.PersonaId = null;
        Repositorio.Tareas.Add(nuevaTarea);
        return CreatedAtAction(nameof(ObtenerTarea), new { id = nuevaTarea.Id }, nuevaTarea);
    }

    // Obtener todas las tareas
    [HttpGet]
    public IActionResult ObtenerTareas()
    {
        return Ok(Repositorio.Tareas);
    }

    // Obtener una tarea por ID
    [HttpGet("{id}")]
    public IActionResult ObtenerTarea(int id)
    {
        var tarea = Repositorio.Tareas.FirstOrDefault(t => t.Id == id);
        if (tarea == null)
            return NotFound();

        return Ok(tarea);
    }

    // Asignar una tarea a una persona
    [HttpPost("{tareaId}/asignar/{personaId}")]
    public IActionResult AsignarTarea(int tareaId, int personaId)
    {
        var tarea = Repositorio.Tareas.FirstOrDefault(t => t.Id == tareaId);
        var persona = Repositorio.Personas.FirstOrDefault(p => p.Id == personaId);

        if (tarea == null || persona == null)
            return NotFound("Tarea o Persona no encontrada.");

        tarea.PersonaId = personaId;
        persona.Tareas.Add(tarea);

        return Ok(tarea);
    }
}