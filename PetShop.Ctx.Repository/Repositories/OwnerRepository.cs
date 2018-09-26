using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entity;
using PetShop.Core.RepositoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Ctx.Repository.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private PetShopContext _ctx;

        public OwnerRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }

        public Owner Create(Owner owner)
        {
            var addedOwner = _ctx.Add(owner).Entity;
            _ctx.SaveChanges();
            return addedOwner;
        }

        public Owner Delete(int id)
        {
            var owner = _ctx.Remove(new Owner { id = id }).Entity;
            _ctx.SaveChanges();
            return owner;
        }

        public Owner Get(int id)
        {
            return _ctx.Owners.Include(p => p.pets).FirstOrDefault(o => o.id == id);
        }

        public IEnumerable<Owner> GetAll()
        {
            return _ctx.Owners.Include(p => p.pets);
        }

        public Owner Update(Owner ownerUpdate)
        {
            var addedOwner = _ctx.Update(ownerUpdate).Entity;
            _ctx.SaveChanges();
            return addedOwner;
        }
    }
}
