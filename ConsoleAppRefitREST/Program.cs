using ConsoleAppRefitREST.Application.User.Interface;
using ConsoleAppRefitREST.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;

namespace ConsoleAppRefitREST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Refit World !");
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                {
                    services.AddRefitClient<IUsersClient>()
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/"));
                }).Build();
            
            RefitMethod(host).Wait();

            Console.ReadKey();
        }

        private static async Task RefitMethod(IHost host)
        {
            var usersClient = host.Services.GetRequiredService<IUsersClient>();

            // read all users.
            var users = await usersClient.GetAll();
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }

            Console.ReadKey();

            var userInfo = new User
            {
                Name = "John Doe",
                Email = "john.doe@test.com"
            };

            // create user.
            var userId = (await usersClient.CreateUser(userInfo)).Id;
            Console.WriteLine($"User with Id: {userId} created");

            // read user.
            var existingUser = await usersClient.GetUser(1);

            // update user.
            existingUser.Email = "john.doe@gmail.com";
            var updatedUser = await usersClient.UpdateUser(existingUser.Id, existingUser);
            Console.WriteLine($"User email updated to {updatedUser.Email}");
            // delete user.
            await usersClient.DeleteUser(userId);

            // read all users.
            users = await usersClient.GetAll();
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
        }
    }
}