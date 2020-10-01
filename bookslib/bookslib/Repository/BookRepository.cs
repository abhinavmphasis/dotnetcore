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
                new BookModel(){Id= 1, Title="MVC", Author="Abhinav"},
                new BookModel(){Id= 2, Title="PHP", Author="Abhishek"},
                new BookModel(){Id= 3, Title="Angular", Author="Nitin"},
                new BookModel(){Id= 4, Title="Azure", Author="Jatin"},
            };
        }
    }
}
