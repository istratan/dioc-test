using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DigitalOceanTest.Models;

namespace DigitalOceanTest.Controllers
{
    // [Route("[controller]")]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if(_context.TodoItems.Count() == 0){
                _context.TodoItems.Add(new TodoItem {
                    Name = "Sex",
                    IsComplete = false
                });

                _context.SaveChanges();
            }
        }

        public IActionResult Index()
        {
            var items = _context.TodoItems.ToList();

            return View(items);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}