using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ConferenceBarrel.Models;
using System.Linq;

namespace ConferenceBarrel.Controllers
{
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        public ToDoController()
        {

            if (ctx.InterviewDatas.Count() == 0)
            {
                ctx.InterviewDatas.Add(new InterviewData { supplier = "Item1" });
                ctx.SaveChanges();
            }
        }  

        [HttpGet]
        public IEnumerable<InterviewData> GetAll()
        {
            return ctx.InterviewDatas.ToList().AsEnumerable();
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public IActionResult GetById(long id)
        {
            var item = ctx.InterviewDatas.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }


        [HttpPost]
        public IActionResult Create([FromBody] InterviewData item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            ctx.InterviewDatas.Add(item);
            ctx.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] InterviewData item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var todo = ctx.InterviewDatas.FirstOrDefault(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            todo.supplier = item.supplier;
            todo.year = item.year;
            todo.spend = item.spend;
            todo.quantity = item.quantity;
            todo.no_of_products = item.no_of_products;

            ctx.InterviewDatas.Update(todo);
            ctx.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = ctx.InterviewDatas.First(t => t.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            ctx.InterviewDatas.Remove(todo);
            ctx.SaveChanges();
            return new NoContentResult();
        }
    }
}