using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entity;
using PetShop.Core.RepositoryService;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Ctx.Repository.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly PetShopContext db;

        public UserRepository(PetShopContext context)
        {
            db = context;
        }

        //Unused methods
        #region
        public User Get(long id)
        {
            return db.Users.FirstOrDefault(b => b.Id == id);
        }

        public void Edit(User entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
        #endregion

        public IEnumerable<User> GetAll()
        {
            return db.Users.ToList();
        }

        public User Add(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            db.Users.Add(user);
            db.SaveChanges();

            return user;
        }

        public User Delete(int id)
        {
            var user = db.Users.FirstOrDefault(b => b.Id == id);
            db.Users.Remove(user);
            db.SaveChanges();

            return user;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
