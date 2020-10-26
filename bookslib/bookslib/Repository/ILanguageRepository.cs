using bookslib.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace bookslib.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}