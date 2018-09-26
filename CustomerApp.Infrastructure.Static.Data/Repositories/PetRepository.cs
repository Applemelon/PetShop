using PetShop.Core.Entity;
using PetShop.Core.RepositoryService;
using PetShop.Core.UIService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Repository
{
    public class PetRepository: IPetRepository
    {
        private IOwnerService _ownerService;

        public PetRepository(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        public Pet Create(Pet pet)
        {
            pet.id = FakeDB.petId++;
            FakeDB.petList.Add(pet);
            return pet;
        }

        public IEnumerable<Pet> ReadAll()
        {
            return FakeDB.petList;
        }

        public IEnumerable<PetType> ReadAllPetTypes()
        {
            return Enum.GetValues(typeof(PetType)).Cast<PetType>();
        }

        public Pet ReadById(int id)
        {
            Pet pet = FakeDB.petList.Find(Pet => Pet.id == id);
            if (pet != null)
            {
                return pet;
            }
            return null;
        }
        
        public Pet Update(Pet petUpdate)
        {
            Pet pet = FakeDB.petList.Find(Pet => Pet.id == petUpdate.id);
            if (pet != null)
            {
                pet.name = petUpdate.name;
                pet.type = petUpdate.type;
                pet.birthday = petUpdate.birthday;
                pet.solddate = petUpdate.solddate;
                pet.price = petUpdate.price;
                return pet;
            }
            return null;
        }

        public Pet Delete(int id)
        {
            var pet = this.ReadById(id);
            if (pet != null)
            {
                FakeDB.petList.Remove(pet);
                return pet;
            }
            return null;
        }
    }
}
