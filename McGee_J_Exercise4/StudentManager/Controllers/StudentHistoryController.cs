using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManager.Models;
using StudentManager;

namespace StudentManager.Controllers
{
    public class StudentHistoryController : Controller
    {
        private McGeeJEx4DBContext shistorycontext { get; set; }
        public StudentHistoryController(McGeeJEx4DBContext shistoryctx)
        {
            shistorycontext = shistoryctx;
        }

        public IActionResult History()
        {
             var history = shistorycontext.StudentHistory
             .OrderBy(h => h.FirstName).ToList();



            return View(history);
        }


    }
}
