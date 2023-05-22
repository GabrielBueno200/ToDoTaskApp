using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Domain.Common;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }
}
