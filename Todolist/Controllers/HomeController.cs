using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Service;
using TodoList.Domain;
using Todolist.Models;
using TodoList.Domain.Interface;

namespace TodoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITodoService _service;
        private readonly ToDoContext _context;

        public HomeController(ITodoService service, ToDoContext context)
        {
            _service = service;
            _context = context;
        }

        public IActionResult Index(string id)
        {
            var temp = _service.GetAll();
            var model = new TodoModel(Category.Adventure);

            ViewBag.Categories = Enum.GetValues(typeof(Category));
            ViewBag.Statuses = Enum.GetValues(typeof(Status));

            var query = _service.GetAll();

            // Add your filtering logic here using the query variable

            var tasks = query.OrderBy(t => t.DueDate).ToList();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = _service.GetCategories().Result;
            ViewBag.Statuses = _service.GetStatuses().Result;
            var task = new ToDo { StatusId = "open" };
            return View(task);
        }

        [HttpPost]
        public IActionResult Add(ToDo task)
        {
            if (ModelState.IsValid)
            {
                _context.ToDoS.Add(task);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = _context.Categories.ToList();
                ViewBag.Statuses = _context.Statuses.ToList();
                return View(task);
            }
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join("-", filter);
            return RedirectToAction("Index", new { ID = id });
        }

        [HttpPost]
        public IActionResult MarkComplete([FromRoute] string id, ToDo selected)
        {
            selected = _context.ToDoS.Find(selected.Id);

            if (selected != null)
            {
                selected.StatusId = "closed";
                _context.SaveChanges();
            }
            return RedirectToAction("Index", new { ID = id });
        }

        [HttpPost]
        public IActionResult DeleteComplete(string id)
        {
            var toDelete = _context.ToDoS.Where(t => t.StatusId == "closed").ToList();

            foreach (var task in toDelete)
            {
                _context.ToDoS.Remove(task);
            }
            _context.SaveChanges();

            return RedirectToAction("Index", new { ID = id });
        }
    }
}