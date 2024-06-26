﻿using GestionTareas.Models;
using GestionTareas.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionTareas.Services
{
    public class TareaService : ITareaService
    {
        private readonly ApplicationDbContext _context;

        public TareaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TareaItem>> GetTasksAsync(int pageNumber, int pageSize)
        {
            try
            {
                return await _context.TareasItems
                                     .OrderBy(t => t.Id)
                                     .Skip((pageNumber - 1) * pageSize)
                                     .Take(pageSize)
                                     .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error fetching tasks: {ex.Message}");
                return new List<TareaItem>();
            }
        }

        public async Task<int> GetTaskCountAsync()
        {
            try
            {
                return await _context.TareasItems.CountAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error counting tasks: {ex.Message}");
                return 0;
            }
        }

        public async Task<TareaItem> GetTaskByIdAsync(int id)
        {
            try
            {
                return await _context.TareasItems.FindAsync(id);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error fetching task by ID: {ex.Message}");
                return null;
            }
        }

        public async Task AddTaskAsync(TareaItem tarea)
        {
            try
            {
                _context.TareasItems.Add(tarea);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error adding task: {ex.Message}");
            }
        }

        public async Task UpdateTaskAsync(TareaItem tareaActualizada)
        {
            try
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
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error updating task: {ex.Message}");
            }
        }

        public async Task DeleteTaskAsync(int id)
        {
            try
            {
                var tarea = await _context.TareasItems.FindAsync(id);
                if (tarea != null)
                {
                    _context.TareasItems.Remove(tarea);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error deleting task: {ex.Message}");
            }
        }
    }
}
