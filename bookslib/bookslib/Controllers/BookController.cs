using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using bookslib.Models;
using bookslib.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bookslib.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();

            return View(data);
        }
        [Route("book-details/{id}", Name ="bookDetailsRoute")]
        public async Task< ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);

        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBooks(bookName, authorName);
        }

        public ViewResult AddNewBook(bool isSuccees, int bookId = 0)
        {
            var model = new BookModel()
            {
                Language = "English"
            };
            ViewBag.Language = new SelectList( new List<string>() { "Hindi", "English", "Dutch" });
            ViewBag.IsSuccees = isSuccees;
            ViewBag.BookId = bookId;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel) 
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccees = true, bookId = id });
                }
            }
            ViewBag.Language = new SelectList(new List<string>() { "Hindi", "English", "Dutch" });

            //ViewBag.IsSuccees = false;
            //ViewBag.BookId = 0;
            ModelState.AddModelError("", "This is my custom error message");
            return View();
        }
    }
}
