using PetShop.Core.Entity;
using PetShop.Core.RepositoryService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShop.Core.UIService
{
    public class PetService : IPetService
    {
        readonly IPetRepository petRepo;

        public PetService(IPetRepository petRepository)
        {
            petRepo = petRepository;
        }

        public Pet New(string name, PetType type, DateTime birthday, double price)
        {
            var pet = new Pet()
            {
                id = 0,
                name = name,
                type = type,
                birthday = birthday,
                solddate = (DateTime.Parse(DateTime.Now.ToString("h:mm:ss tt"))),
                price = price,
            };

            return pet;
        }

        public Pet Create(Pet pet)
        {
            return petRepo.Create(pet);
        }

        public Pet GetById(int id)
        {
            return petRepo.ReadById(id);
        }

        public List<Pet> GetAll()
        {
            return petRepo.ReadAll().ToList();
        }

        public List<PetType> GetAllTypes()
        {
            return petRepo.ReadAllPetTypes().ToList();
        }

        public List<Pet> GetAllByFirstName(string name)
        {
            var list = petRepo.ReadAll();
            var queryContinued = list.Where(pet => pet.name.Equals(name));
            queryContinued.OrderBy(pets => pets.name);
            return queryContinued.ToList();
        }

        public Pet Update(Pet petUpdate)
        {
            return petRepo.Update(petUpdate);
        }

        public Pet Delete(int id)
        {
            return petRepo.Delete(id);
        }
    }
}
