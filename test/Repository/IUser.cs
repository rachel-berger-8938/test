using test.Models;

namespace test.Repository
{
    public interface IUser
    {
        Task<User> CreateUser(User user);
        Task<User> DeleteUser(int userId);
        bool ValidateUser(string userName, string Password);
    }
}
