using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.UIService
{
    public interface IOwnerService
    {
        Owner New(string name);

        Owner Create(Owner owner);

        Owner Get(int id);

        List<Owner> GetAll();

        Owner Update(Owner ownerUpdate);

        Owner Delete(int id);
    }
}
