namespace GestionTareas.Models
{
    public class TareaItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public EstadoTareas Status { get; set; }
        public bool IsBlocked { get; set; }
    }
}
