using Todolist.Models;

namespace TodoList.Domain.Interface;

public interface ITodoRepository
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    IEnumerable<ToDo> GetAll();
    Task<ToDo> GetByIdAsync(int id);
    ToDo Add(ToDo toDo);
    ToDo Update(ToDo toDo);
    bool Remove(int id);
}