using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.DTO;
using ReviewApp.Interface;
using ReviewApp.Models;

namespace ReviewApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthorController : ControllerBase
    {
        private readonly IAuthorInterface authorInterface;
        private readonly IMapper mapper;

        public AuthorController(IAuthorInterface authorInterface, IMapper mapper)
        {
            this.authorInterface = authorInterface;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Author>))]
        public IActionResult GetAuthors()
        {
            var authors = mapper.Map<List<AuthorDto>>(authorInterface.GetAuthors());


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(authors);
        }


        [HttpGet("{authorId}")]
        [ProducesResponseType(200, Type = typeof(Author))]
        [ProducesResponseType(404)]

        public IActionResult GetAuthor(int authorId)
        {
            if (!authorInterface.AuthorExists(authorId))
            {
                return NotFound("Author not found.");
            }

            var author = mapper.Map<AuthorDto>(authorInterface.GetAuthor(authorId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(author);
        }

        [HttpGet("books/{authorId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Author>))]
        [ProducesResponseType(404)]

        public IActionResult GetAuthorByBook(int authorId)
        {
            if (!authorInterface.AuthorExists(authorId))
            {
                return NotFound("Author not found.");
            }

            var books = mapper.Map<List<BookDto>>(authorInterface.GetAuthorByBook(authorId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(books);
        }


    }
}
