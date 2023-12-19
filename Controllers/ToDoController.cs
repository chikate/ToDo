using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Context;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext _context;

        public ToDoController(ToDoContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(SarcinaModel todo)
        {
            var sarcini = await _context.Sarcina.ToListAsync();

            if (ModelState.IsValid)
            {
                _context.Sarcina.Add(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(todo);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var todo = await _context.Sarcina.FindAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(SarcinaModel todo)
        {
            var sarcini = await _context.Sarcina.ToListAsync();

            if (ModelState.IsValid)
            {
                _context.Update(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(todo);
        }
        [HttpPut]
        public async Task<IActionResult> Delete(int id)
        {
            var sarcini = await _context.Sarcina.FindAsync(id);

            if (sarcini == null)
            {
                return NotFound();
            }

            _context.Sarcina.Remove(sarcini);
            await _context.SaveChangesAsync();
            return Ok("Sters");
        }
    }
}