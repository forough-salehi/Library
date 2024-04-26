using Application.Abstraction;
using Domain;
using Domain.Models;

namespace Application.Concrete
{
    public class BookRepository : IBookRepository
    {
        /* FAKE DATA IS STORED in MEMORY with inital 1000 registry */

        private readonly List<Book> fakeDataStore = RandomFactory.Repeat(1000);
        public IList<Book> Get()
        {
            return fakeDataStore;
        }

        public Book GetSingle(string id)
        {
            return fakeDataStore.FirstOrDefault(x => x.Id == id);
        }
    }
}
