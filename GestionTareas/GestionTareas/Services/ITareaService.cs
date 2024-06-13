using GestionTareas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionTareas.Services
{
    public interface ITareaService
    {
        Task<List<TareaItem>> GetTasksAsync(int pageNumber, int pageSize);
        Task<int> GetTaskCountAsync();
        Task<TareaItem> GetTaskByIdAsync(int id);
        Task AddTaskAsync(TareaItem tarea);
        Task UpdateTaskAsync(TareaItem tareaActualizada);
        Task DeleteTaskAsync(int id);
    }
}
