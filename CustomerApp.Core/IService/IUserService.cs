using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.IService
{
    public interface IUserService
    {
        List<User> GetAll();

        User New(UserTemp userTemp);

        User Delete(int id);
    }
}
