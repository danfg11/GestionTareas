using GestionTareas.Models;

namespace GestionTareas.Services
{
    public interface ITareaService
    {
        Task<List<TareaItem>> GetTasksAsync(int pageNumber, int pageSize);
        Task<int> GetTaskCountAsync();
        Task AddTaskAsync(TareaItem tarea);
        Task UpdateTaskAsync(TareaItem tareaActualizada);
        Task DeleteTaskAsync(int id);
    }
}
