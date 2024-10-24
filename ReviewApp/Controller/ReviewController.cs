using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.DTO;
using ReviewApp.Interface;
using ReviewApp.Models;

namespace ReviewApp.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewInterface reviewInterface;
        private readonly IMapper mapper;

        public ReviewController(IReviewInterface reviewInterface, IMapper mapper)
        {
            this.reviewInterface = reviewInterface;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        [ProducesResponseType(404)]
        public IActionResult GetReviews()
        {
            var reviews = mapper.Map<List<ReviewDto>>(reviewInterface.GetAllReviews());

            // Check if the book list is null or empty and return NotFound if so
            if (reviews == null || reviews.Count == 0)
            {
                return NotFound("not found");
            }

            return Ok(reviews);
        }

        [HttpGet("{reviewId}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(404)]
        public IActionResult GetReview(int reviewId)
        {
            // Check if the book exists
            if (!reviewInterface.ReviewExists(reviewId))
            {
                return NotFound("not found");
            }

            var review = mapper.Map<ReviewDto>(reviewInterface.GetReview(reviewId));

            if (!ModelState.IsValid)
            {
                return BadRequest("bad request");
            }

            return Ok(review);
        }





    }
}
