using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using TwitterApi.Contract.Query.GetPostById;
using TwitterApi.Contract.Request.CreatePost;
using TwitterApi.Entity;

namespace TwitterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        //[HttpGet]
        //public IEnumerable<Post> GetAll()
        //{
        //    _logger.LogInformation("Get all posts");
        //    List<Post> result = new();
        //    using (var connection = _dataContext.GetConnection())
        //    {
        //        result = connection.GetCollection<Post>().FindAll().ToList();
        //    }
        //    return result;
        //}

        //[HttpGet("by-user/{userId:guid}")]
        //public ActionResult<IEnumerable<Post>> GetAllByUserId([FromRoute] Guid userId)
        //{
        //    List<Post> result = new();
        //    using (var connection = _dataContext.GetConnection())
        //    {
        //        var user = connection.GetCollection<User>().FindById(userId);

        //        if (user != null)
        //        {
        //            result = connection.GetCollection<Post>().Find(p => p.UserId == userId).ToList();
        //        }
        //        else
        //        {
        //            result = null;
        //        }
        //    }

        //    if(result != null)
        //    {
        //        _logger.LogInformation($"Get all posts by userId {userId}");
        //        return result;
        //    }
        //    else
        //    {
        //        var error = $"User with id {userId} not found";
        //        _logger.LogWarning(error);
        //        return NotFound(error);
        //    }
        //}

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Post>> GetById([FromRoute] Guid id)
        {
            return await _mediator.Send(new GetPostByIdRequest { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody, Required] CreatePostRequest request)
        {
            return await _mediator.Send(request);
        }

        //[HttpPut("{id:guid}")]
        //public ActionResult<Post> Update([FromRoute] Guid id, [FromBody] CreatePostRequest request)
        //{
        //    Post post = null;
        //    using (var connection = _dataContext.GetConnection())
        //    {
        //        post = connection.GetCollection<Post>().FindById(id);
        //    }

        //    if (post != null)
        //    {
        //        User user = null;
        //        using (var connection = _dataContext.GetConnection())
        //        {
        //            user = connection.GetCollection<User>().FindById(request.UserId);
        //        }

        //        if(user != null)
        //        {
        //            post.UserId = request.UserId;
        //            post.Title = request.Title;
        //            post.Content = request.Content;
        //            using (var connection = _dataContext.GetConnection())
        //            {
        //                connection.GetCollection<Post>().Update(post);
        //            }
        //            _logger.LogInformation($"Update post with id {id}");
        //            return post;
        //        }
        //        else
        //        {
        //            var error = $"User with id {request.UserId} not found";
        //            _logger.LogWarning(error);
        //            return NotFound(error);
        //        }
        //    }
        //    else
        //    {
        //        var error = $"Post with id {id} not found";
        //        _logger.LogWarning(error);
        //        return NotFound(error);
        //    }
        //}

        //[HttpDelete("{id:guid}")]
        //public ActionResult Delete([FromRoute] Guid id)
        //{
        //    var result = false;
        //    using (var connection = _dataContext.GetConnection())
        //    {
        //        result = connection.GetCollection<Post>().Delete(id);
        //    }
        //    if (result)
        //    {
        //        _logger.LogInformation($"Delete post with id {id}");
        //        return Ok();
        //    }
        //    else
        //    {
        //        var error = $"Post with id {id} not found";
        //        _logger.LogWarning(error);
        //        return NotFound(error);
        //    }
        //}
    }
}
