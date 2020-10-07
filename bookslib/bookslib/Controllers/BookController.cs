﻿using System;
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
                Language = "2"
            };

            var group1 = new SelectListGroup() { Name = "Group1" };
            var group2 = new SelectListGroup() { Name = "Group2" };
            var group3 = new SelectListGroup() { Name = "Group3" };
            ViewBag.Language =  new List<SelectListItem>()
            {

                new SelectListItem(){Text="Hindi",Value="1", Group = group1},
                new SelectListItem(){Text="English",Value="2",Group = group1},
                new SelectListItem(){Text="Dutch",Value="3",Group = group2},
                new SelectListItem(){Text="Tamil",Value="4",Group = group2},
                new SelectListItem(){Text="German",Value="5",Group = group3},
                new SelectListItem(){Text="Dutch",Value="6",Group = group3},

            };

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
            ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");

            return View();
        }
        private List<LanguageModel> GetLanguage()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel(){Id=1, Text="Hindi"},
                new LanguageModel(){Id=2, Text="English"},
                new LanguageModel(){Id=1, Text="Dutch"},
            };
        }
    }
}
