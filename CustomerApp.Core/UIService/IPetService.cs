using PetShop.Core.Entity;
using System;
using System.Collections.Generic;

namespace PetShop.Core.UIService
{
    public interface IPetService
    {
        Pet New(string name, PetType type, DateTime birthday, string color, string previousowner, double price);

        Pet Create(Pet pet);

        Pet GetById(int id);

        List<Pet> GetAll();

        List<PetType> GetAllTypes();

        Pet Update(Pet petUpdate);

        Pet Delete(int id);
    }
}
