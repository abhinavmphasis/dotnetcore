using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using bookslib.Models;
using Microsoft.Extensions.Configuration;

namespace bookslib.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        public HomeController(IConfiguration _configuration)
        {
            configuration =  _configuration;
        }
        public ViewResult Index()
        {
            //var value = _messageRepository.GetName();

            //var newBook = configuration.GetSection("NewBookAlert");
            //var result = newBook.GetValue<bool>("DisplayNewBookAlert");
            //var bookName = newBook.GetValue<string>("BookName");

            var result = configuration["AppName"];
            var key1 = configuration["infoObj:key1"];
            var key2 = configuration["infoObj:key2"];
            var key3 = configuration["infoObj:key3:key3obj1"];


            return View();
        }
        public ViewResult AboutUS(int id)
        {
            return View();
        }
        public ViewResult ContactUS()
        {
            return View();
        }
    }
}
