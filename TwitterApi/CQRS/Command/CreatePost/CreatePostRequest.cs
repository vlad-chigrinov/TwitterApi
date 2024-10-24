using MediatR;
using System.ComponentModel.DataAnnotations;

namespace TwitterApi.Contract.Request.CreatePost
{
    public class CreatePostRequest : IRequest<Guid>
    {
        [Required]
        public required Guid UserId { get; set; }
        [Required]
        public required string Title { get; set; }
        [Required]
        public required string Content { get; set; }
    }
}
