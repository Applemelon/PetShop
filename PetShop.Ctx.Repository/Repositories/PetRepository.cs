using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entity;
using PetShop.Core.RepositoryService;
using PetShop.Core.UIService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Ctx.Repository.Repositories
{
    public class PetRepository : IPetRepository
    {
        private PetShopContext _ctx;
        private IOwnerService _ownerService;

        public PetRepository(PetShopContext ctx, IOwnerService ownerService)
        {
            _ctx = ctx;
            _ownerService = ownerService;
        }

        public Pet Create(Pet pet)
        {
            if(pet.owner != null)
            {
                pet.owner = _ctx.Owners.FirstOrDefault(o => o.id == pet.owner.id);
            }
            var addedPet =_ctx.Add(pet).Entity;
            _ctx.SaveChanges();
            return pet;
        }

        public Pet Delete(int id)
        {
            var pet = _ctx.Remove(new Pet { id = id }).Entity;
            _ctx.SaveChanges();
            return pet;
        }

        public IEnumerable<Pet> ReadAll()
        {
            var pets = _ctx.Pets.Include(p => p.owner);
            foreach (var pet in pets)
            {
                if (pet.owner != null)
                {
                    pet.owner.pets.Clear();
                }
            }
            return pets;
        }

        public IEnumerable<PetType> ReadAllPetTypes()
        {
            return Enum.GetValues(typeof(PetType)).Cast<PetType>();
        }

        public Pet ReadById(int id)
        {
            var pet = _ctx.Pets.Include(p => p.owner).FirstOrDefault(p => p.id == id);
            if (pet.owner != null)
            {
                pet.owner.pets.Clear();
            }
            return pet;
        }

        public Pet Update(Pet petUpdate)
        {
            if (petUpdate.owner != null)
            {
                petUpdate.owner = _ctx.Owners.FirstOrDefault(o => o.id == petUpdate.owner.id);
            }
            var addedPet = _ctx.Update(petUpdate).Entity;
            _ctx.SaveChanges();
            return petUpdate;
        }
    }
}
