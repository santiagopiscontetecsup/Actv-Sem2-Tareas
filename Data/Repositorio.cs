using System.Collections.Generic;
using Actv_Sem2_TareaGestion.Models;

namespace Actv_Sem2_TareaGestion.Data
{
    public static class Repositorio
    {
        public static List<Persona> Personas { get; set; } = new List<Persona>();
        public static List<Tarea> Tareas { get; set; } = new List<Tarea>();
    }
}