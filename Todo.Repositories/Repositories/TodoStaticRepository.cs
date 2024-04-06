using TodoList.Domain;
using Todolist.Models;
using TodoList.Domain.Interface;

namespace Todolist.Repositories
{
    public class TodoStaticRepository : ITodoRepository
    {
        private static List<ToDo> todoList;
        public TodoStaticRepository()
        {
            todoList =
            [
                new ToDo
                {
                    Category = Category.Adventure,
                    Description = "Test",
                    DueDate = DateTime.Now.AddDays(4),
                    Id = 1,
                    Status = Status.New,
                },
            ];
        }
        public ToDo Add(ToDo toDo)
        {
            todoList.Add(toDo);
            return toDo;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return 0;
        }

        public IEnumerable<ToDo> GetAll()
        {
            return todoList;
        }

        public Task<ToDo> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public ToDo Update(ToDo toDo)
        {
            throw new NotImplementedException();
        }
    }
}
