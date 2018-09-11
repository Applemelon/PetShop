using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.RepositoryService
{
    public interface IOwnerRepository
    {
        Owner Create(Owner owner);

        IEnumerable<Owner> GetAll();

        Owner Get(int id);

        Owner Update(Owner ownerUpdate);

        Owner Delete(int id);
    }
}
