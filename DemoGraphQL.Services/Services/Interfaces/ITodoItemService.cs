using System.Collections.Generic;
using System.Threading.Tasks;
using DemoGraphQL.Domain.Models;

namespace DemoGraphQL.Domain.Services.Interfaces
{
    public interface ITodoItemService
    {
        Task<TodoItemViewModel> GetByIdAsync(int id);
        Task<List<TodoItemViewModel>> GetAllAsync(int pageSize = 10, int offset = 0);
        Task<TodoItemViewModel> CreateAsync(TodoItemViewModel input);
        Task<TodoItemViewModel> UpdateAsync(TodoItemViewModel input);
        Task<TodoItemViewModel> DeleteAsync(int id);
    }
}
