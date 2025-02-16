using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.API.Models;

namespace Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        //CREATE > POST
        //READ > GET
        //UPDATE > PUT
        //DELETE > DELETE

        // In memory storage
        private static readonly List<TodoItem> _todoItems = [];


        //GET api/tasks
        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> Get()
        {
            // var item = _todoDbContext
            return Ok(_todoItems);
        }

        //Get api/tasks/1
        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            var todoItem = _todoItems.FirstOrDefault(x => x.Id == id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return Ok(todoItem);
        }

        //POST api/tasks
        [HttpPost]
        public ActionResult Post([FromBody] TodoItem todoItem)
        {
            _todoItems.Add(todoItem);
            return CreatedAtAction(nameof(Get), new { id = todoItem.Id }, todoItem);
        }

        //PUT api/tasks/1
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            var todoItemToUpdate = _todoItems.FirstOrDefault(x => x.Id == id);
            if (todoItemToUpdate == null)
            {
                return NotFound();
            }

            todoItemToUpdate.Title = todoItem.Title;
            todoItemToUpdate.Task = todoItem.Task;
            todoItemToUpdate.IsCompleted = todoItem.IsCompleted;

            return NoContent();
        }

        //Delete api/tasks/1
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var todoItemToDelete = _todoItems.FirstOrDefault(x => x.Id == id);
            if (todoItemToDelete == null)
            {
                return NotFound();
            }

            _todoItems.Remove(todoItemToDelete);

            return NoContent();
        }
    }
}
