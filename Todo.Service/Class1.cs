using Todolist.Models;

namespace Todo.Service;

public interface ITodoService
{
    Task<bool> Delete(int id);
    Task<bool> MarkAsDone(int id);
    IEnumerable<TodoModel> GetAll();
    Task<int> Add(AddTodoModel model);
    Task<int> UpdateDescription(int id, string description);

    Task<IEnumerable<Category>> GetCategories();
    Task<IEnumerable<Status>> GetStatuses();


}

public record TodoModel
{
    private Category adventure;

    public TodoModel()
    {
    }

    public TodoModel(Category adventure)
    {
        this.adventure = adventure;
    }

    public int? Id { get; init; }
    public string Description { get; init; } = string.Empty;
    public DateTime? DueDate { get; init; }
    public Category Category { get; init; } = Category.Adventure;
    public bool IsActive { get; init; } = true;
    public Status Status { get; init; } = Status.New;
    public bool Overdue => this.Status == Status.InProgress && DueDate < DateTime.Today;

    public bool IsNew() => this.Status == Status.New;

    public bool IsNotSaved() => this.Id.HasValue || this.Id > 0;
}

public record AddTodoModel
{
    public string Description { get; init; } = string.Empty;
    public DateTime? DueDate { get; init; }
    public Category Category { get; init; } = Category.Adventure;

    public bool IsActive { get; init; }
    public Status Status { get; init; }

}