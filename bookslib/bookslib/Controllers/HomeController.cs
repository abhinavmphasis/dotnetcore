using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using bookslib.Models;

namespace bookslib.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {

            return View();
        }

        public ViewResult AboutUS()
        {
            ViewData["property1"] = "Abhinav";
            return View();
        }

        public ViewResult ContactUS()
        {
            return View();
        }
    }
}
