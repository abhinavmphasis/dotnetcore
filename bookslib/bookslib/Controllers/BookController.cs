using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using bookslib.Models;
using bookslib.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace bookslib.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository = null;
        private readonly ILanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public BookController(IBookRepository bookRepository, 
            ILanguageRepository languageRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;

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

        public async Task<ViewResult> AddNewBook(bool isSuccees =false, int bookId = 0)
        {

            var model = new BookModel();
       

            var languages =  new SelectList(await _languageRepository.GetLanguages(),"Id","Name");


            ViewBag.IsSuccees = isSuccees;
            ViewBag.BookId = bookId;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel) 
        {
            if (ModelState.IsValid)
            {
                if (bookModel.CoverPhoto != null)
                {
                    string folder = "books/cover/";
                    bookModel.CoverImageUrl = await UploadImage(folder, bookModel.CoverPhoto);
                    //await UploadImage(folder, bookModel.CoverPhoto);
                }

                if (bookModel.GalleryFiles != null)
                {
                    string folder = "books/gallery/";

                    bookModel.Gallery = new List<galleryModel>();

                    foreach (var file in bookModel.GalleryFiles)
                    {
                        var gallery = new galleryModel()
                        {
                            Name = file.FileName,
                            URL = await UploadImage(folder, file)
                        };
                        bookModel.Gallery.Add(gallery);
                    }

                }
                if (bookModel.BookPdf != null)
                {
                    string folder = "books/pdf/";
                    bookModel.BookPdfUrl = await Uploadfile(folder, bookModel.CoverPhoto);
                    //await UploadImage(folder, bookModel.CoverPhoto);
                }
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccees = true, bookId = id });
                }
            }

            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");
            return View();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/" + folderPath;
        }
        private async Task<string> Uploadfile(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/" + folderPath;
        }
    }
}
