﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using bookslib.Models;
using bookslib.Repository;
using Microsoft.AspNetCore.Mvc;

namespace bookslib.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public ViewResult GetAllBooks()
        {
            var data = _bookRepository.GetAllBooks();

            return View(data);
        }
        [Route("book-details/{id}", Name ="bookDetailsRoute")]
        public ViewResult GetBook(int id)
        {
            var data = _bookRepository.GetBookById(id);
            return View(data);

        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBooks(bookName, authorName);
        }

        public ViewResult AddNewBook(bool isSuccees, int bookId = 0)
        {
            ViewBag.IsSuccees = isSuccees;
            ViewBag.BookId = bookId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel) 
        {
           int id = await _bookRepository.AddNewBook(bookModel);
            if (id > 0)
            {
                return RedirectToAction(nameof(AddNewBook), new { isSuccees = true, bookId = id });
            }
            return View();
        }
    }
}
