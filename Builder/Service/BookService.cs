using Builder.Dtos;
using Builder.Models;

namespace Builder.Service
{
    public class BookService
    {
        public Task<BookDto> Create()
        {
            var book = new Book() { Id = Guid.NewGuid(), Name = "水浒传", Type = "名著/经典/历史", Price = 100 };
            var result = new BookDto
            {
                Id = book.Id,
                Name = book.Name,
                Type = book.Type,
                Price = book.Price,
            };
            return Task.FromResult(result);
        }
    }
}
