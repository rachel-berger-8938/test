using System;
using test.Models;

namespace test.Repository.Services
{

    public class UserService : IUser
    {
        private readonly myDBContext appDbContext;

        public UserService(myDBContext appDbContext)

        {
            this.appDbContext = appDbContext;
        }
        public async Task<User> CreateUser(User user)
        {
            appDbContext.Add(user);
            await appDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUser(int userId)
        {
            User userToDelete = appDbContext.Users.Where(x => x.Equals(userId)).FirstOrDefault();
            appDbContext.Remove(userToDelete);
            await appDbContext.SaveChangesAsync();
            return userToDelete;
        }

        public bool ValidateUser(string userName, string password)
        {
            User? user = appDbContext.Users.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();
            if (user == null)
                return true;
            else
                return false;
        }
    }
}
