using bookslib.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bookslib.Repository
{
    public interface IBookRepository
    {
        Task<int> AddNewBook(BookModel model);
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBookById(int id);
        Task<List<BookModel>> GetTopBooksAsync(int count);
        List<BookModel> SearchBooks(string title, string author);

        string GetAppName();
    }
}