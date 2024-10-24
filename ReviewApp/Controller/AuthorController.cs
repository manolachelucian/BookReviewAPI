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


        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorController"/> class.
        /// </summary>
        /// <param name="authorInterface">The interface for author operations.</param>
        /// <param name="mapper">The mapper for DTO conversions.</param>
        public AuthorController(IAuthorInterface authorInterface, IMapper mapper)
        {
            this.authorInterface = authorInterface;
            this.mapper = mapper;
        }



        /// <summary>
        /// Retrieves all authors.
        /// </summary>
        /// <returns>A list of authors wrapped in a <see cref="IActionResult"/>.</returns>
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

        /// <summary>
        /// Retrieves an author by their ID.
        /// </summary>
        /// <param name="authorId">The ID of the author to retrieve.</param>
        /// <returns>The author if found, otherwise a 404 status code.</returns>
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

        /// <summary>
        /// Retrieves all books associated with a given author by author ID.
        /// </summary>
        /// <param name="authorId">The ID of the author whose books to retrieve.</param>
        /// <returns>A list of books written by the author.</returns>
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

        /// <summary>
        /// Creates a new author.
        /// </summary>
        /// <param name="AuthorName">The name of the author to create.</param>
        /// <param name="AuthorCreate">The DTO containing author details.</param>
        /// <returns>A success message or a validation error message.</returns>
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateAuthor([FromQuery] string AuthorName ,[FromBody] AuthorDto AuthorCreate)
        {
            if (AuthorCreate == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(AuthorName == null)
            {
                ModelState.AddModelError("AuthorName", "The Author Name is required.");
                return BadRequest(ModelState);
            }

            var newAuthor = new Author
            {
                Name = AuthorName
            };  

            if (!authorInterface.CreateAuthor(newAuthor))
            {
                ModelState.AddModelError("", $"Something went wrong saving the author {newAuthor.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok("Author Created Successfully.");
        }

        /// <summary>
        /// Updates an existing author.
        /// </summary>
        /// <param name="authorId">The ID of the author to update.</param>
        /// <param name="AuthorUpdate">The DTO containing updated author details.</param>
        /// <returns>A success message or validation error message.</returns>
        [HttpPut("{authorId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAuthor(int authorId,[FromBody] AuthorDto AuthorUpdate)
        {
            if (AuthorUpdate == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!authorInterface.AuthorExists(authorId))
            {
                return NotFound("Author not found.");
            }
            if(AuthorUpdate.Name == null)
            {
                ModelState.AddModelError("AuthorName", "The Author Name is required.");
                return BadRequest(ModelState);
            }

            var author = mapper.Map<Author>(AuthorUpdate);

            if (!authorInterface.UpdateAuthor(author))
            {
                ModelState.AddModelError("", $"Something went wrong updating the author {author.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully updated");
        }




        /// <summary>
        /// Deletes an author by their ID.
        /// </summary>
        /// <param name="authorId">The ID of the author to delete.</param>
        /// <returns>A success message or validation error message.</returns>
        [HttpDelete("{authorId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteAuthor(int authorId)
        {
            if (!authorInterface.AuthorExists(authorId))
            {
                return NotFound("Author not found.");
            }

            var author = authorInterface.GetAuthor(authorId);

            if (!authorInterface.DeleteAuthor(author))
            {
                ModelState.AddModelError("", $"Something went wrong deleting the author {author.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok("Author Deleted Successfully.");
        }



    }
}
