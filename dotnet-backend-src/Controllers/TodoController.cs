using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_backend_src.data;
using dotnet_backend_src.data.models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_backend_src.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly DataContext dbContext;
        public TodoController(DataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<Todo> Get()
        {
            return dbContext.Todos;
        }

        [HttpGet("{id}")]
        public async Task<Todo> Get(int id)
        {
            return await dbContext.Todos.FindAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Todo model)
        {
            dbContext.Todos.Add(model);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Todo model)
        {
            if (model.Status == TodoStatus.Closed && model.ClosedAt == null) { model.ClosedAt = DateTime.Now; }
            dbContext.Update(model);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            dbContext.Todos.Remove(dbContext.Todos.Find(id));
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
