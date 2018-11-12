using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.RepositoryService
{
    public interface IUserRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        User Add(User user, string password);
        void Edit(T entity);
        User Delete(int id);
    }
}
