using Refit;
using System.Reflection;

namespace WebAppRefitREST.Application.User.Interface
{
    public interface IUsersClient
    {
        [Get("/users")]
        Task<IEnumerable<Model.User>> GetAll();

        [Get("/users/{id}")]
        Task<Model.User> GetUser(int id);
        [Post("/users")]
        Task<Model.User> CreateUser([Body] Model.User user);
        [Put("/users/{id}")]
        Task<Model.User> UpdateUser(int id, [Body] Model.User user);

        [Delete("/users/{id}")]
        Task DeleteUser(int id);
    }
}
