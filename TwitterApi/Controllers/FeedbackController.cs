using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TwitterApi.Contract;
using TwitterApi.Entity;

namespace TwitterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController(DataContext context) : ControllerBase
    {
        readonly DataContext _context = context;

        [HttpPost("like")]
        public ActionResult<int> AddLike([FromBody] CreateFeedbackRequest request)
        {
            using(var connection = _context.GetConnection())
            {
                var feedbacks = connection.GetCollection<Feedback>();
                feedbacks.Insert(new Feedback
                {
                    Id = Guid.NewGuid(),
                    UserId = request.UserId,
                    PostId = request.PostId,
                    Date = DateTime.Now,
                    Type = Feedback.FeedbackType.Like
                });
                return feedbacks.Count(f => f.Type == Feedback.FeedbackType.Like);
            }
        }
        [HttpPost("dislike")]
        public ActionResult<int> AddDislike([FromBody] CreateFeedbackRequest request)
        {
            using (var connection = _context.GetConnection())
            {
                var feedbacks = connection.GetCollection<Feedback>();
                feedbacks.Insert(new Feedback
                {
                    Id = Guid.NewGuid(),
                    UserId = request.UserId,
                    PostId = request.PostId,
                    Date = DateTime.Now,
                    Type = Feedback.FeedbackType.Dislike
                });
                return feedbacks.Count(f => f.Type == Feedback.FeedbackType.Dislike);
            }
        }
    }
}
