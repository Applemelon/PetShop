using PetShop.Core.Entity;
using PetShop.Core.IService;
using PetShop.Core.RepositoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Core.Services
{
    public class UserService : IUserService
    {
        readonly IUserRepository<User> userRepo;

        public UserService(IUserRepository<User> userRepository)
        {
            userRepo = userRepository;
        }

        public User Delete(int id)
        {
            return userRepo.Delete(id);
        }

        public List<User> GetAll()
        {
            return userRepo.GetAll().ToList();
        }

        public User New(UserTemp userTemp)
        {
            User user = new User
            {
                Username = userTemp.username,
                IsAdmin = userTemp.isAdmin
            };

            return userRepo.Add(user, userTemp.password);
        }
    }
}
