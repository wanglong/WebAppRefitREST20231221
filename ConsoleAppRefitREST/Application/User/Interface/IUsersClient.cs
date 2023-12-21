using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppRefitREST.Model;

namespace ConsoleAppRefitREST.Application.User.Interface
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
