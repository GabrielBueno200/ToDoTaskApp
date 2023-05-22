using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.Models;

namespace ToDoApp.Infrastructure.Persistence.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<ToDoTask> ToDoTasks { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var databaseFilePath = Path.Combine(Directory.GetCurrentDirectory(), "todotasks.db");

        if (!File.Exists(databaseFilePath))
        {
            File.Create(databaseFilePath).Dispose();
        }

        optionsBuilder.UseSqlite($"Data Source={databaseFilePath}");
    }
}