using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StudentManager.Models;
using StudentManager.Controllers;
using StudentManager;
using System.Threading.Tasks;

namespace StudentManager.Controllers;

    public class HomeController : Controller
    {
        private StudentManager.Models.McGeeJEx4DBContext context { get; set; }
    
        public HomeController(StudentManager.Models.McGeeJEx4DBContext ctx)
    {
        context = ctx;
    }

    public async Task<IActionResult> Index(string search)
    {
        var student = from s in context.Student
                      .OrderBy(s => s.FirstName)
                      select s;

        if(!string.IsNullOrEmpty(search))
        {
            student = student.Where(s => s.LastName!.Contains(search));
        }
        return View(await student.ToListAsync());
    }

    }


