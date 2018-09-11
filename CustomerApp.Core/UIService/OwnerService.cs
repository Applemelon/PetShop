using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;
using PetShop.Core.RepositoryService;
using System.Linq;

namespace PetShop.Core.UIService
{
    class OwnerService : IOwnerService
    {

        readonly IOwnerRepository ownerRepo;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            ownerRepo = ownerRepository;
        }

        public Owner New(string name)
        {
            Owner owner = new Owner
            {
                id = 0,
                name = name
            };

            return owner;
        }

        public Owner Create(Owner owner)
        {
            return ownerRepo.Create(owner);
        }

        public Owner Delete(int id)
        {
            return ownerRepo.Delete(id);
        }

        public Owner Get(int id)
        {
            return ownerRepo.Get(id);
        }

        public List<Owner> GetAll()
        {
            return ownerRepo.GetAll().ToList();
        }

        public Owner Update(Owner ownerUpdate)
        {
            return ownerRepo.Update(ownerUpdate);
        }
    }
}
