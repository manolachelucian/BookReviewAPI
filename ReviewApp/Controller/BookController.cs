using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.DTO;
using ReviewApp.Interface;
using ReviewApp.Models;




namespace ReviewApp.Controller
{
    [ApiController]
    [Route("api/[controller]")]

    public class BookController : ControllerBase
    {
        private readonly IBookInterface _bookInterface;
        private readonly IMapper mapper;

        public BookController(IBookInterface bookInterface,IMapper mapper)
        {
            _bookInterface = bookInterface;
            this.mapper = mapper;
            
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        [ProducesResponseType(404)]

        public IActionResult GetBooks()
        {
            var books = mapper.Map<List<BookDto>>(_bookInterface.GetBooks());

            // Check if the book list is null or empty and return NotFound if so
            if (books == null || books.Count == 0)
            {
                return NotFound("No books found.");
            }

            return Ok(books);


        }


        [HttpGet("{bookId}")]
        [ProducesResponseType(200, Type = typeof(Book))]
        [ProducesResponseType(404)]
        public IActionResult GetBook(int bookId)
        {
            // Check if the book exists
            if (!_bookInterface.BookExists(bookId))
            {
                return NotFound("Book not found.");
            }

            var book =mapper.Map<BookDto>(_bookInterface.GetBook(bookId));


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(book);
        }


        [HttpGet("{bookId}/rating")]
        [ProducesResponseType(200, Type = typeof(Book))]
        [ProducesResponseType(404)]
        public IActionResult GetBookRating(int bookId)
        {
            // Check if the book exists
            if (!_bookInterface.BookExists(bookId))
            {
                return NotFound("Book not found.");
            }

            var rating = _bookInterface.GetBookRating(bookId);

            return Ok(rating);
        }

    }
}
