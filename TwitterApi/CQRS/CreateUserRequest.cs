using MediatR;
using System.ComponentModel.DataAnnotations;

namespace TwitterApi.Contract
{
    public class CreateUserRequest : IRequest<int>
    {
        [Required, Length(2, 100)]
        public required string FirstName { get; set; }
        [Required, Length(3, 100)]
        public required string LastName { get; set; }
        [Required, Length(3, 100)]
        public required string NickName { get; set; }
    }
}
