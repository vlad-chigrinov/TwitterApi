using MediatR;
using TwitterApi.Entity;
using TwitterApi.Exceptions;

namespace TwitterApi.Contract.Query.GetPostById
{
    public class GetPostByIdQuery(DataContext context) : IRequestHandler<GetPostByIdRequest, Post>
    {
        private readonly DataContext _context = context;

        public async Task<Post> Handle(GetPostByIdRequest request, CancellationToken cancellationToken)
        {
            using (var connection = _context.GetConnection())
            {
                var result = connection.GetCollection<Post>().FindById(request.Id);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    throw new NotFoundException(nameof(Post), request.Id.ToString());
                }
            }
        }
    }
}
