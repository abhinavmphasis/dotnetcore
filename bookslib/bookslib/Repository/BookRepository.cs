using bookslib.Data;
using bookslib.Models;
using Microsoft.EntityFrameworkCore;
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
                Title=model.Title,
                TotalPages=model.TotalPages.HasValue?model.TotalPages.Value:0,
                UpdatedOn=DateTime.UtcNow

        };
            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;

        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if (allbooks?.Any() == true)
            {
                foreach(var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        Id = book.Id,
                        Language = book.Language,
                        Title = book.Title,
                        TotalPages = book.TotalPages
                    });
                }
            }
            return books;
        }

        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book!= null)
            {
                var bookdetails = new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    Language = book.Language,
                    Title = book.Title,
                    TotalPages = book.TotalPages
                };
                return bookdetails;

            }
            return null;
            //return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBooks(string title, string author)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(author)).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id= 1, Title="MVC", Author="Abhinav", Description="This is MVC5 version book", Category="Architecture", Language="English",TotalPages=134},
                new BookModel(){Id= 2, Title="PHP", Author="Abhishek", Description="This is PHP version book",Category="Programming", Language="English",TotalPages=1200},
                new BookModel(){Id= 3, Title="Angular", Author="Nitin", Description="This is Angular 8 version book",Category="Client side code", Language="English",TotalPages=200},
              
            };
        }
    }
}
