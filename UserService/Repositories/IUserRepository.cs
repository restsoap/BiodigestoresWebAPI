using UserService.DTOs;
using UserService.Models;

namespace UserService.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();

        User createUser(User user);

        User GetUserById(string id);
    }
}
