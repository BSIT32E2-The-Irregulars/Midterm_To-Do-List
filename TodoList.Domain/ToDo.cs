using Todolist.Models;

namespace TodoList.Domain;

public class ToDo
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public DateTime? DueDate { get; set; }
    public Category Category { get; set; } = Category.Adventure;
    public bool IsActive { get; set; } = true;
    public Status Status { get; set; } = Status.New;

}