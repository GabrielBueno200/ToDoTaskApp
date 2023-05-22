using ToDoApp.Domain.Models;

namespace ToDoApp.Domain.Interfaces.Repositories;

public interface IToDoTaskRepository
{
    public Task<IList<ToDoTask>> GetAllToDoTasksAsync();
    public Task<ToDoTask> GetTaskById(int id);
    public Task<ToDoTask> SaveToDoTaskAsync(ToDoTask task);
    public Task DeleteToDoTaskAsync(int taskId);
    public Task UpdateToDoTask(ToDoTask updatedTask);
}
