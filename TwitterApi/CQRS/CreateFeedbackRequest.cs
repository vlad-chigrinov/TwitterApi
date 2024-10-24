using MediatR;

namespace TwitterApi.Contract
{
    public class CreateFeedbackRequest : IRequest<int>
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
    }
}
