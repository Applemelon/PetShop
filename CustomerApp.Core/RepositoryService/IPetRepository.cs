using PetShop.Core.Entity;
using System;
using System.Collections.Generic;

namespace PetShop.Core.RepositoryService
{
    public interface IPetRepository
    {
        Pet Create(Pet pet);

        Pet ReadById(int id);

        IEnumerable<Pet> ReadAll();

        IEnumerable<PetType> ReadAllPetTypes();

        Pet Update(Pet petUpdate);

        Pet Delete(int id);
    }
}
