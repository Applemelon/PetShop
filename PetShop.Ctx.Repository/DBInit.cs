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

            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);

            User user = new User
            {
                Username = "User",
                PasswordHash = passwordHashJoe,
                PasswordSalt = passwordSaltJoe,
                IsAdmin = false
            };

            User admin = new User
            {
                Username = "Admin",
                PasswordHash = passwordHashJoe,
                PasswordSalt = passwordSaltJoe,
                IsAdmin = true
            };

            ctx.Add(user);
            ctx.Add(admin);

            ctx.SaveChanges();

        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
