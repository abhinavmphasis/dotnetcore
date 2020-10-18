using bookslib.Data;
using bookslib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace bookslib.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                LanguageId = model.LanguageId,

                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow,
                coverImageUrl = model.CoverImageUrl

            };

            var gallery = new List<BookGallery>();
            foreach (var file in model.Gallery)
            {
                gallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL

                }) ;
            }
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;

        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if (allbooks?.Any() == true)
            {
                foreach (var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        Id = book.Id,
                        LanguageId = book.LanguageId,
                        Language = book.Language.Name,
                        Title = book.Title,
                        TotalPages = book.TotalPages
                    });
          
                }
            }
            return books;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            return await _context.Books.Where(x => x.Id == id)
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                    CoverImageUrl = book.coverImageUrl,
                    Gallery = book.BookGallery.Select(g=> new galleryModel() { 
                    Id = g.Id,
                    Name = g.Name,
                    URL = g.URL
                    }).ToList()
                }).FirstOrDefaultAsync();


        }

        public List<BookModel> SearchBooks(string title, string author)
        {
            return null;
        }


    }
}
