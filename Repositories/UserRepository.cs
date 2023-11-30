using Entities;
using Microsoft.EntityFrameworkCore;
using Repository;
using System.Text.Json;

namespace Repositories
{
    public class UserRepository :  IUserRepository
    {
        private readonly AdoNet1Context _DbContext;
        public UserRepository(AdoNet1Context dbContext)
        {
            _DbContext = dbContext;
        }
        //string FilePath = ".\\users.txt";

        public async Task<User> GetUserByUserNameAndPassword(string userName = "", string password ="")
        {
            return await _DbContext.Users.Where(user => user.Email == userName && user.Password == password).FirstOrDefaultAsync();

        }
        public async Task<User> UpdateUser(int id, User userToUpdate)
        {
            userToUpdate.UserId = id;
            _DbContext.Users.Update(userToUpdate);
            await _DbContext.SaveChangesAsync();

            return userToUpdate;
        }
        public async Task<User> Post(User user)
        {
            await _DbContext.Users.AddAsync(user);
            await _DbContext.SaveChangesAsync();
    
            return user;
        }
    }
}