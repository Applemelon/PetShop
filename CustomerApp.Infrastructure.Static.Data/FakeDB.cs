using PetShop.Core.Entity;
using System;
using System.Collections.Generic;

namespace PetShop.Repository
{
    public class FakeDB
    {
        public static readonly List<Pet> petList = new List<Pet>();
        public static int petId = 1;

        public static readonly List<Owner> ownerList = new List<Owner>();
        public static int ownerId = 1;

        public static void StartUp()
        {
            Owner per = new Owner
            {
                id = 0,
                name = "Per Tygesen",
            };

            Owner frederik = new Owner
            {
                id = 0,
                name = "Frederik Hansen"
            };

            Pet hans = new Pet
            {
                id = 0,
                owner = per,
                name = "Hans",
                type = PetType.BIRD,
                birthday = DateTime.Now,
                solddate = DateTime.Now,
                price = 59.99
            };

            Pet gogge = new Pet
            {
                id = 0,
                owner = frederik,
                name = "Gogge",
                type = PetType.HAMSTER,
                birthday = DateTime.Now,
                solddate = DateTime.Now,
                price = 500
            };

            Pet viggo = new Pet
            {
                id = 0,
                owner = per,
                name = "Viggo",
                type = PetType.BIRD,
                birthday = DateTime.Now,
                solddate = DateTime.Now,
                price = 800000
            };

            hans.id = petId++;
            petList.Add(hans);

            gogge.id = petId++;
            petList.Add(gogge);

            viggo.id = petId++;
            petList.Add(viggo);

            per.id = ownerId++;
            ownerList.Add(per);

            frederik.id = ownerId++;
            ownerList.Add(frederik);
        }
    }
}
