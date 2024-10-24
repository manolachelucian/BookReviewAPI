using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.DTO;
using ReviewApp.Interface;
using ReviewApp.Models;

namespace ReviewApp.Controller
{
    /// <summary>
    /// The UserController handles API endpoints related to user operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface userInterface;
        private readonly IMapper mapper;


        /// <summary>
        /// Constructor for the UserController class.
        /// </summary>
        /// <param name="userInterface">Service interface for managing users.</param>
        /// <param name="mapper">AutoMapper instance for object mapping.</param>
        public UserController(IUserInterface userInterface, IMapper mapper)
        {
            this.userInterface = userInterface;
            this.mapper = mapper;
        }


        /// <summary>
        /// Gets all users.
        /// </summary>
        /// <returns>A list of users.</returns>
        /// <response code="200">Returns the list of users.</response>
        /// <response code="400">If the model state is invalid.</response>

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

        /// <summary>
        /// Gets a specific user by ID.
        /// </summary>
        /// <param name="userId">The ID of the user to retrieve.</param>
        /// <returns>The user with the given ID.</returns>
        /// <response code="200">Returns the user with the specified ID.</response>
        /// <response code="404">If the user is not found.</response>
        /// <response code="400">If the model state is invalid.</response>
        [HttpGet("{userId}")]
        [ProducesResponseType(200, Type = typeof(User))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
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


        /// <summary>
        /// Gets reviews written by a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user whose reviews are being retrieved.</param>
        /// <returns>A list of reviews written by the user.</returns>
        /// <response code="200">Returns the list of reviews.</response>
        /// <response code="404">If the user is not found.</response>
        /// <response code="400">If the model state is invalid.</response>
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

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="newUsername">The username for the new user.</param>
        /// <param name="user">The UserDto object containing new user details.</param>
        /// <returns>A confirmation message that the user was created.</returns>
        /// <response code="201">If the user is successfully created.</response>
        /// <response code="400">If the input is invalid.</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromQuery] string newUsername, [FromBody] UserDto user)
        {
            if (user == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (newUsername == null)
            {
                ModelState.AddModelError("new Username", "The Username is required.");
                return BadRequest(ModelState);
            }

            var newUser = new User
            {
                Username = newUsername
            };


            if (!userInterface.CreateUser(newUser))
            {
                ModelState.AddModelError("", $"Something went wrong saving the new user {newUser.Username}");
                return StatusCode(500, ModelState);
            }

            return Ok("New User has been Created Successfully.");
        }

        /// <summary>
        /// Deletes a user by ID.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        /// <returns>A confirmation message if the user is successfully deleted.</returns>
        /// <response code="204">If the user is successfully deleted.</response>
        /// <response code="404">If the user is not found.</response>
        /// <response code="400">If the model state is invalid.</response>
        [HttpDelete("{userId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult DeleteUser(int userId)
        {
            if (!userInterface.UserExists(userId))
            {
                return NotFound("User not found.");
            }

            var user = userInterface.GetUser(userId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!userInterface.DeleteUser(user))
            {
                ModelState.AddModelError("", $"Something went wrong deleting the user {user.Username}");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully deleted user");
        }

        /// <summary>
        /// Updates a user's details.
        /// </summary>
        /// <param name="userId">The ID of the user to update.</param>
        /// <param name="UserUpdate">The updated user details.</param>
        /// <returns>A confirmation message if the user is successfully updated.</returns>
        /// <response code="204">If the user is successfully updated.</response>
        /// <response code="404">If the user is not found.</response>
        /// <response code="400">If the input is invalid.</response>
        [HttpPut("{userId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult UpdateUser(int userId, [FromBody] UserDto UserUpdate)
        {
            if (UserUpdate == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!userInterface.UserExists(userId))
            {
                return NotFound("User not found.");
            }
            if (UserUpdate.Username == null)
            {
                ModelState.AddModelError("Username", "The Username is required.");
                return BadRequest(ModelState);
            }

            var user = mapper.Map<User>(UserUpdate);

            if (!userInterface.UpdateUser(user))
            {
                ModelState.AddModelError("", $"Something went wrong updating the author {user.Username}");
                return StatusCode(500, ModelState);
            }

            return Ok("User has been  Succesfully updated");
        }






    }
}
