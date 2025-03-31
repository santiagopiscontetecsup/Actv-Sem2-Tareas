using Microsoft.AspNetCore.Mvc;
using Actv_Sem2_TareaGestion.Models;
using Actv_Sem2_TareaGestion.Data;

namespace Actv_Sem2_TareaGestion.Controllers;

[ApiController]
[Route("api/personas")]
public class PersonasController : ControllerBase
{
    // Crear una persona
    [HttpPost]
    public IActionResult CrearPersona([FromBody] Persona nuevaPersona)
    {
        nuevaPersona.Id = Repositorio.Personas.Count + 1; // Generar ID simple
        Repositorio.Personas.Add(nuevaPersona);
        return CreatedAtAction(nameof(ObtenerPersona), new { id = nuevaPersona.Id }, nuevaPersona);
    }

    [HttpGet]
    public IActionResult ObtenerPersonas()
    {
        return Ok(Repositorio.Personas);
    }

    // Obtener una persona por ID
    [HttpGet("{id}")]
    public IActionResult ObtenerPersona(int id)
    {
        var persona = Repositorio.Personas.FirstOrDefault(p => p.Id == id);
        if (persona == null)
            return NotFound();

        return Ok(persona);
    }
}