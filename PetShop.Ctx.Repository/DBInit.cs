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

            Color yellow = new Color
            {
                name = "Yellow",
                hexcode = "#FFFF00"
            };

            Color brown = new Color
            {
                name = "Brown",
                hexcode = "#D2691E"
            };

            Color black = new Color
            {
                name = "Black",
                hexcode = "#000000"
            };

            Pet hans = new Pet
            {
                owner = per,
                name = "Hans",
                type = PetType.BIRD,
                birthday = DateTime.Now,
                solddate = DateTime.Now,
                price = 59.99
            };

            Pet gogge = new Pet
            {
                owner = frederik,
                name = "Gogge",
                type = PetType.HAMSTER,
                birthday = DateTime.Now,
                solddate = DateTime.Now,
                price = 500
            };

            Pet viggo = new Pet
            {
                owner = per,
                name = "Viggo",
                type = PetType.BIRD,
                birthday = DateTime.Now,
                solddate = DateTime.Now,
                price = 800000
            };

            ctx.Add(hans);
            ctx.Add(gogge);
            ctx.Add(viggo);
            ctx.Add(per);
            ctx.Add(frederik);
            ctx.Add(yellow);
            ctx.Add(brown);
            ctx.Add(black);

            ctx.SaveChanges();

        }
    }
}
