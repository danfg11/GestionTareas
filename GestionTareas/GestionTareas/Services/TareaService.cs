using GestionTareas.Models;
using GestionTareas.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionTareas.Services
{
    public class TareaService
    {
        private readonly ApplicationDbContext _context;

        public TareaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TareaItem>> GetTasksAsync(int pageNumber, int pageSize)
        {
            return await _context.TareasItems
                                 .Skip((pageNumber - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }

        public async Task<int> GetTaskCountAsync()
        {
            return await _context.TareasItems.CountAsync();
        }

        public async Task AddTaskAsync(TareaItem tarea)
        {
            tarea.Id = _context.TareasItems.Any() ? _context.TareasItems.Max(t => t.Id) + 1 : 1;
            _context.TareasItems.Add(tarea);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(TareaItem tareaActualizada)
        {
            var tarea = await _context.TareasItems.FindAsync(tareaActualizada.Id);
            if (tarea != null)
            {
                tarea.Name = tareaActualizada.Name;
                tarea.Description = tareaActualizada.Description;
                tarea.Status = tareaActualizada.Status;
                tarea.IsBlocked = tareaActualizada.IsBlocked;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTaskAsync(int id)
        {
            var tarea = await _context.TareasItems.FindAsync(id);
            if (tarea != null)
            {
                _context.TareasItems.Remove(tarea);
                await _context.SaveChangesAsync();
            }
        }
    }
}
