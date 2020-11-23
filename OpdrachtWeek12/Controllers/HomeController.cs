using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpdrachtWeek12.Data;
using OpdrachtWeek12.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OpdrachtWeek12.Controllers
{
    public class HomeController : Controller
    {

        private MijnContext context;
        public HomeController(MijnContext context_)
        {
            context = context_;
        }

        public IActionResult Index()
        {
            
            return View(context.Studenten.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
    }
}
