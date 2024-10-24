using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using TwitterApi.Contract;
using TwitterApi.Entity;

namespace TwitterApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(ILogger<UsersController> logger, DataContext dataContext) : ControllerBase
    {
        private readonly ILogger<UsersController> _logger = logger;
        private readonly DataContext _dataContext = dataContext;

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            _logger.LogInformation("Get all users");
            List<User> result = new();
            using (var connection = _dataContext.GetConnection())
            {
                result = connection.GetCollection<User>().FindAll().ToList();
            }
            return result;
        }
        [HttpGet("{id:guid}")]
        public ActionResult<User> GetById([FromRoute] Guid id)
        {
            User result = null;

            using (var connection = _dataContext.GetConnection())
            {
                result = connection.GetCollection<User>().FindById(id);
            }

            if (result != null)
            {
                _logger.LogInformation($"Get user with id {id}");
                return result;
            }
            else
            {
                var error = $"Not found user with id {id}";
                _logger.LogWarning(error);
                return NotFound(error);
            }

        }
        [HttpPost]
        public User Create([FromBody, Required] CreateUserRequest request)
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                NickName = request.NickName
            };
            using (var connection = _dataContext.GetConnection())
            {
                connection.GetCollection<User>().Insert(newUser);
            }
            _logger.LogInformation($"Create user with id {newUser.Id}");

            return newUser;
        }
        [HttpPut("{id:guid}")]
        public ActionResult<User> Update([FromRoute] Guid id, [FromBody] CreateUserRequest request)
        {
            var user = new User
            {
                Id = id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                NickName = request.NickName
            };

            var result = false;
            using (var connection = _dataContext.GetConnection())
            {
                result = connection.GetCollection<User>().Update(user);
            }
            if (result)
            {
                _logger.LogInformation($"Update user with id {id}");
                return user;
            }
            else
            {
                var error = $"User with id {id} not found";
                _logger.LogWarning(error);
                return NotFound(error);
            }
        }
        [HttpDelete("{id:guid}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            var result = false;
            using (var connection = _dataContext.GetConnection())
            {
                result = connection.GetCollection<User>().Delete(id);
            }
            if (result)
            {
                using (var connection = _dataContext.GetConnection())
                {
                    connection.GetCollection<Post>().DeleteMany(p=>p.UserId == id);
                    _logger.LogInformation($"Delete posts with userId {id}");
                }

                _logger.LogInformation($"Delete user with id {id}");
                return Ok();
            }
            else
            {
                var error = $"User with id {id} not found";
                _logger.LogWarning(error);
                return NotFound(error);
            }
        }
    }
}
