using MediatR;
using TwitterApi.Entity;

namespace TwitterApi.Contract.Query.GetPostById
{
    public class GetPostByIdRequest : IRequest<Post>
    {
        public Guid Id { get; set; }
    }
}
