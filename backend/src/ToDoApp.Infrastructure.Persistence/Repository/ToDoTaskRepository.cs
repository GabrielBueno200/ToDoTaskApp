using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.Interfaces.Repositories;
using ToDoApp.Domain.Models;
using ToDoApp.Infrastructure.Persistence.DbContext;

namespace ToDoApp.Infrastructure.Persistence.Repository;

public class ToDoTaskRepository : IToDoTaskRepository
{
    private readonly AppDbContext _context;

    public ToDoTaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task DeleteToDoTaskAsync(int taskId)
    {
        var taskToDelete = await _context
            .ToDoTasks
            .FirstOrDefaultAsync(t => t.Id == taskId);

        _context.ToDoTasks.Remove(taskToDelete);
        await _context.SaveChangesAsync();
    }

    public async Task<IList<ToDoTask>> GetAllToDoTasksAsync()
    {
        return await _context.ToDoTasks.ToListAsync();
    }

    public async Task<ToDoTask> GetTaskById(int id)
    {
        return await _context.ToDoTasks.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<ToDoTask> SaveToDoTaskAsync(ToDoTask task)
    {
        _context.ToDoTasks.Add(task);
        await _context.SaveChangesAsync();

        return task;
    }

    public async Task UpdateToDoTask(ToDoTask updatedTask)
    {
        var taskToUpdate = await _context
            .ToDoTasks
            .FirstOrDefaultAsync(t => t.Id == updatedTask.Id);

        taskToUpdate.Description = updatedTask.Description;
        taskToUpdate.IsFinished = updatedTask.IsFinished;

        await _context.SaveChangesAsync();
    }
}
