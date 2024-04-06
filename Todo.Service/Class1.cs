using Todolist.Models;

namespace Todo.Service;

public interface ITodoService
{
    Task<bool> Delete(int id);
    Task<bool> MarkAsDone(int id);
    IEnumerable<TodoModel> GetAll();
    Task<int> Add(AddTodoModel model);
    Task<int> UpdateDescription(int id, string description);
    
}

public record TodoModel
{
    public int? Id { get; init; }
    public string Description { get; init; } = string.Empty;
    public DateTime? DueDate { get; init; }
    public Category Category { get; init; } = Category.Adventure;
    public bool IsActive { get; init; } = true;
    public Status Status { get; init; } = Status.New;
    public bool Overdue => this.Status == Status.InProgress && DueDate < DateTime.Today;
}

public record AddTodoModel
{
    public string Description { get; init; } = string.Empty;
    public DateTime? DueDate { get; init; }
    public Category Category { get; init; } = Category.Adventure;
}