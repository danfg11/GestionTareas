using System.ComponentModel.DataAnnotations;

namespace GestionTareas.Models
{
    public class TareaItem
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public EstadoTareas Status { get; set; }

        public bool IsBlocked { get; set; }
    }
}
