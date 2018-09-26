using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Ctx.Repository
{
    public class DBInit
    {

        public static void StartUp(PetShopContext ctx)
        {
            Owner per = new Owner
            {
                name = "Per Tygesen",
            };

            Owner frederik = new Owner
            {
                name = "Frederik Hansen"
            };

            Pet hans = new Pet
            {
                owner = per,
                name = "Hans",
                type = PetType.BIRD,
                birthday = DateTime.Now,
                solddate = DateTime.Now,
                color = "Rød, Grøn",
                price = 59.99
            };

            Pet gogge = new Pet
            {
                owner = frederik,
                name = "Gogge",
                type = PetType.HAMSTER,
                birthday = DateTime.Now,
                solddate = DateTime.Now,
                color = "Hvid",
                price = 500
            };

            Pet viggo = new Pet
            {
                owner = per,
                name = "Viggo",
                type = PetType.BIRD,
                birthday = DateTime.Now,
                solddate = DateTime.Now,
                color = "Hvid",
                price = 800000
            };

            ctx.Add(hans);
            ctx.Add(gogge);
            ctx.Add(viggo);
            ctx.Add(per);
            ctx.Add(frederik);

            ctx.SaveChanges();

        }
    }
}
