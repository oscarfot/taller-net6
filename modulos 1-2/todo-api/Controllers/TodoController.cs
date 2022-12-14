using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using todo_api.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace todo_api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {

        private readonly ILogger<TodoController> _logger;
        private readonly TodoContext _context;

        private List<TodoItem> list = new List<TodoItem>();

        public TodoController(ILogger<TodoController> logger, TodoContext context) {
            _logger = logger;
            _context = context;
        }


        [HttpGet]
        public List<TodoItem> Get()
        {
            return _context.TodoItem.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public TodoItem? Get(int id)
        {
            return _context.TodoItem.FirstOrDefault(x => x.Id == id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] TodoItem todoItem)
        {
            _context.TodoItem.Add(todoItem);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TodoItem todoItem)
        {
            _context.TodoItem.Update(todoItem);
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item=_context.TodoItem.FirstOrDefault(x => x.Id == id);
            if (item != null) {
                _context.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}

