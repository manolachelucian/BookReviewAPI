using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.DTO;
using ReviewApp.Interface;
using ReviewApp.Models;

namespace ReviewApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface userInterface;
        private readonly IMapper mapper;

        public UserController(IUserInterface userInterface, IMapper mapper)
        {
            this.userInterface = userInterface;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]

        public IActionResult GetUsers()
        {
            var users = mapper.Map<List<UserDto>>(userInterface.GetUsers());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(users);
        }


        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(404)]
        public IActionResult GetUser(int userId)
        {
            if (!userInterface.UserExists(userId))
            {
                return NotFound("Author not found.");
            }

            var user = mapper.Map<UserDto>(userInterface.GetUser(userId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(user);
        }

        [HttpGet("review/{userId}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(400)]


        public IActionResult GetReviewsByUser(int userId)
        {
            if (!userInterface.UserExists(userId))
            {
                return NotFound("User not found.");
            }

            var reviews = mapper.Map<List<ReviewDto>>(userInterface.GetReviewsByUser(userId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(reviews);
        }   






    }
}
