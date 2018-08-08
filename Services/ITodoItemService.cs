using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreToDo.Models;

namespace AspNetCoreToDo.Services
{
    public interface ITodoItemService
    {
        Task<IEnumerable<TodoItem>> GetIncompleteItemsAsync();
        Task<bool> AddItemAsync(NewTodoItem newItem);
        Task<bool> MarkDoneAsync(Guid id);
    }
}