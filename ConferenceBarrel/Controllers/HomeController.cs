using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceBarrel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConferenceBarrel.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext ctx = new ApplicationDbContext();
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Technical Exam";

            return View();
        }

        public IActionResult CreateData()
        {
            ViewData["Message"] = "Create New Data";

            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Hello! Message me if you have any question.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult CreateInterviewData()
        {
            var interviewData = new InterviewData {
                supplier="A",
                year=2015,
                spend=100000,
                quantity=10000,
                no_of_products=4459
            };

            ctx.InterviewDatas.Add(interviewData);
            ctx.SaveChanges();

            // var sessionTitles = new List<String> {
            //     ".Net Core"
            // };

            // foreach(var title in sessionTitles){
            //     var session = new Session {
            //         Title=title,
            //         InterviewData=interviewData
            //     };
            // }

            return RedirectToAction("ViewInterviewData");
        }

        public IActionResult ViewInterviewData()
        {
            var interviewData = ctx.InterviewDatas.First();
            return View(interviewData);

            // using (var context = new ApplicationDbContext())
            // {
            //     // This will load ALL professors in memory
            //     context.InterviewDatas.Load();
 
            //     // Now that professors are loaded in memory 
            //     // we can use the Local property
            //     var model = from p in context.InterviewDatas.Local
            //     select p.supplier;
 
            //     return View(model);
            // }
        
        }
    }
}
