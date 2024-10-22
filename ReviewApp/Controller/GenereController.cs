using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.DTO;
using ReviewApp.Interface;
using ReviewApp.Models;

namespace ReviewApp.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class GenereController : ControllerBase
    {
        private readonly IGenereInterface genereInterface;
        private readonly IMapper mapper;

        public GenereController(IGenereInterface genereInterface, IMapper mapper)
        {
            this.genereInterface = genereInterface;
            this.mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Generes>))]
        public IActionResult GetGenere()
        {
            var generes = mapper.Map<List<GenereDto>>(genereInterface.GetGeneres());
            return Ok(generes);
        }

        [HttpGet("{genereId}")]
        [ProducesResponseType(200, Type = typeof(Generes))]
        [ProducesResponseType(404)]
        public IActionResult GetGenere(int genereId)
        {
            if (!genereInterface.GenereExists(genereId))
            {
                return NotFound("Genere not found.");
            }

            var genere = mapper.Map<GenereDto>(genereInterface.GetGenere(genereId));
            return Ok(genere);
        }

        [HttpGet("{genereId}/books")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Book>))]
        [ProducesResponseType(404)]
        public IActionResult GetBooksForGenere(int genereId)
        {
            if (!genereInterface.GenereExists(genereId))
            {
                return NotFound("Genere not found.");
            }

            var books = mapper.Map<List<BookDto>>(genereInterface.GetBooksForGenere(genereId));
            return Ok(books);
        }


    }
}
