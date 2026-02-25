using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.Controllers
{
    public class HomeController : Controller
    {
        private ToDoContext context;

        public HomeController(ToDoContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index(string id)
        {
            var filters = new Filters(id);

            ViewBag.Filter = filters;
            ViewBag.FilterString = id; // 🔥 Important

            ViewBag.Categories = context.Categories.ToList();
            ViewBag.Statuses = context.Statuses.ToList();

            ViewBag.DueFilters = new Dictionary<string, string>
            {
                { "future", "Future" },
                { "past", "Past" },
                { "today", "Today" }
            };

            IQueryable<ToDo> query = context.ToDos
                .Include(t => t.Category)
                .Include(t => t.Status);

            if (filters.HasCategory)
                query = query.Where(t => t.CategoryId == filters.CategoryId);

            if (filters.HasStatus)
                query = query.Where(t => t.StatusId == filters.StatusId);

            if (!filters.HasDue)
            {
                return View(query.ToList());
            }
            if (filters.Due == "future")
                query = query.Where(t => t.DueDate > DateTime.Today);

            if (filters.Due == "past")
                query = query.Where(t => t.DueDate < DateTime.Today);

            if (filters.Due == "today")
                query = query.Where(t => t.DueDate == DateTime.Today);

            return View(query.ToList());
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join("-", filter);
            return RedirectToAction("Index", new { id });
        }

        public IActionResult Add()
        {
            ViewBag.Categories = context.Categories.ToList();
            ViewBag.Statuses = context.Statuses.ToList();
            return View(new ToDo());
        }

        [HttpPost]
        public IActionResult Add(ToDo task)
        {
            if (ModelState.IsValid)
            {
                context.ToDos.Add(task);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = context.Categories.ToList();
            ViewBag.Statuses = context.Statuses.ToList();
            return View(task);
        }

        [HttpPost]
        public IActionResult MarkComplete(int id, string idFilter)
        {
            var task = context.ToDos.Find(id);
            if (task != null)
            {
                task.StatusId = "closed";
                context.SaveChanges();
            }

            return RedirectToAction("Index", new { id = idFilter });
        }

        [HttpPost]
        public IActionResult DeleteComplete(string id)
        {
            var completed = context.ToDos
                .Where(t => t.StatusId == "closed");

            context.ToDos.RemoveRange(completed);
            context.SaveChanges();

            return RedirectToAction("Index", new { id });
        }
    }
}