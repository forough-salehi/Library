using Domain.Models;

namespace Application.Abstraction
{
    public interface IBookRepository
    {
        IList<Book> Get();
        Book GetSingle(string id);
    }
}
