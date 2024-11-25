using Microsoft.AspNetCore.Mvc;
using TodoListApp.Data;
using TodoListApp.Models;

namespace TodoListApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TodoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var todos = _context.Todos.ToList();
            return View(todos);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Todo todo)
        {
            if (ModelState.IsValid)
            {
                _context.Todos.Add(todo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var todo = _context.Todos.Find(id);
            if (todo == null) return NotFound();
            return View(todo);
        }

        [HttpPost]
        public IActionResult Edit(Todo todo)
        {
            if (ModelState.IsValid)
            {
                _context.Todos.Update(todo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var todo = _context.Todos.Find(id);
            if (todo == null) return NotFound();
            return View(todo);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var todo = _context.Todos.Find(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        }
}
