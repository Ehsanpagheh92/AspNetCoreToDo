using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreToDo.Services;
using System.Threading.Tasks;
using AspNetCoreToDo.Models;

namespace AspNetCoreToDo.Controllers
{
    public class ToDoController:Controller
    {
        private readonly ITodoItemService _todoItemService;

        public ToDoController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }
        public async Task<IActionResult> Index()
        {
            var todoItems = await  _todoItemService.GetIncompleteItemsAsync();
            var model = new TodoViewModel()
            {
                Items = todoItems
            };
            return View(model);
        }
        public async Task<IActionResult> AddItem(NewTodoItem newItem)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            var successful = await _todoItemService.AddItemAsync(newItem);
            if(!successful) return BadRequest(new { error = "Could not add item" });
            return Ok();
        }
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();
            var successful = await _todoItemService.MarkDoneAsync(id);
            if (!successful) return BadRequest();
            return Ok();
        }
    }
}