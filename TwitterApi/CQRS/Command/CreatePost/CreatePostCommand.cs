using MediatR;
using TwitterApi.Entity;
using TwitterApi.Exceptions;

namespace TwitterApi.Contract.Request.CreatePost
{
    public class CreatePostCommand(DataContext context) : IRequestHandler<CreatePostRequest, Guid>
    {
        private readonly DataContext _context = context;
        public async Task<Guid> Handle(CreatePostRequest request, CancellationToken cancellationToken)
        {
            var newPost = new Post
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Title = request.Title,
                Content = request.Content
            };

            using (var connection = _context.GetConnection())
            {
                if (connection.GetCollection<User>().Exists(u => u.Id == request.UserId) == false)
                {
                    throw new NotFoundException(nameof(User), request.UserId.ToString());
                }
                connection.GetCollection<Post>().Insert(newPost);
            }
            return newPost.Id;
        }
    }
}
