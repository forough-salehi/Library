using Application.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromServices] IBookRepository bookRepository)
        {
            return Ok(bookRepository.Get());
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id, [FromServices] IBookRepository bookRepository)
        {
            return Ok(bookRepository.GetSingle(id));
        }
    }
}
