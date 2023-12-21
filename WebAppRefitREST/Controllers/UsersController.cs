using Microsoft.AspNetCore.Mvc;
using WebAppRefitREST.Application.User.Interface;
using WebAppRefitREST.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAppRefitREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersClient _usersClient;

        public UsersController(IUsersClient usersClient) 
        {
            _usersClient = usersClient;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            // read all users.
            var users = await _usersClient.GetAll();
            return users;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            // read user.
            return await _usersClient.GetUser(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<int> Post([FromBody] User user)
        {
            // create user.
            var userId = (await _usersClient.CreateUser(user)).Id;
            return userId;
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<User> Put(int id, [FromBody] User user)
        {
            var updatedUser = await _usersClient.UpdateUser(id, user);
            return updatedUser;
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _usersClient.DeleteUser(id);
        }
    }
}
