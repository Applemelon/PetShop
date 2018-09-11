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
            Pet hans = new Pet
            {
                id = 0,
                name = "Hans",
                type = PetType.BIRD,
                birthday = (DateTime.Parse(DateTime.Now.ToString("h:mm:ss tt"))),
                solddate = (DateTime.Parse(DateTime.Now.ToString("h:mm:ss tt"))),
                color = "Rød, Grøn",
                previousowner = "Grethe Hansen",
                price = 59.99
            };

            Pet gogge = new Pet
            {
                id = 0,
                name = "Gogge",
                type = PetType.HAMSTER,
                birthday = (DateTime.Parse(DateTime.Now.ToString("h:mm:ss tt"))),
                solddate = (DateTime.Parse(DateTime.Now.ToString("h:mm:ss tt"))),
                color = "Hvid",
                previousowner = "Karl Jensen",
                price = 500
            };

            hans.id = petId++;
            petList.Add(hans);

            gogge.id = petId++;
            petList.Add(gogge);


            Owner per = new Owner
            {
                id = 0,
                name = "Per Tygesen"
            };

            Owner frederik = new Owner
            {
                id = 0,
                name = "Frederik Hansen"
            };

            per.id = ownerId++;
            ownerList.Add(per);

            frederik.id = ownerId++;
            ownerList.Add(frederik);
        }
    }
}
