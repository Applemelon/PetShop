using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;
using PetShop.Core.RepositoryService;

namespace PetShop.Repository.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        public Owner Create(Owner owner)
        {
            owner.id = FakeDB.ownerId++;
            FakeDB.ownerList.Add(owner);
            return owner;
        }

        public Owner Delete(int id)
        {
            var owner = Get(id);
            if(owner != null)
            {
                FakeDB.ownerList.Remove(owner);
                return owner;
            }
            return null;
        }

        public Owner Get(int id)
        {
            Owner owner = FakeDB.ownerList.Find(Owner => Owner.id == id);
            if (owner != null)
            {
                return owner;
            }
            return null;
        }

        public IEnumerable<Owner> GetAll()
        {
            return FakeDB.ownerList;
        }

        public Owner Update(Owner ownerUpdate)
        {
            Owner owner = FakeDB.ownerList.Find(Owner => Owner.id == ownerUpdate.id);
            owner.name = ownerUpdate.name;
            return owner;
        }
    }
}
