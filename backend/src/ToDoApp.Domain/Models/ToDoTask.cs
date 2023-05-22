using ToDoApp.Domain.Common;

namespace ToDoApp.Domain.Models;

public class ToDoTask : BaseEntity
{
    public string? Description { get; set; }
    public bool IsFinished { get; set; } = false;
}
