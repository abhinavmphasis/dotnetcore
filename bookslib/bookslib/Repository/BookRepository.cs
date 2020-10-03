using bookslib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookslib.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
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
                new BookModel(){Id= 4, Title="Azure", Author="Jatin", Description="This is Azure server book",Category="Cloud database", Language="English",TotalPages=500},
                new BookModel(){Id= 5, Title="MS Sql Server", Author="Sam", Description="This is migration  book",Category="Database code", Language="English",TotalPages=700},
                new BookModel(){Id= 6, Title="Full Stack", Author="Nitish", Description="The all code trip",Category="Cloud database", Language="English",TotalPages=900},
            };
        }
    }
}
