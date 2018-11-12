﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PetShop.Api
{
    public class JwtSecurityKey
    {
        private static byte[] secretBytes = Encoding.UTF8.GetBytes("A secret key value");

        public static SymmetricSecurityKey Key
        {
            get { return new SymmetricSecurityKey(secretBytes); }
        }

        public static void SetSecret(string secret)
        {
            secretBytes = Encoding.UTF8.GetBytes(secret);
        }
    }
}
