﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entity
{
    public class Pet
    {
        public int id { get; set; }

        public string name { get; set; }

        public PetType type { get; set; }

        public DateTime birthday { get; set; }

        public DateTime solddate { get; set; }

        public double price { get; set; }
        
        public Owner owner { get; set; }

        public List<PetColorLine> colors { get; set; }

        override
        public string ToString()
        {
            string typeString = type.ToString();
            string birthString = birthday.ToString("MM/dd/yyyy HH:mm:ss.fff");
            string soldString = solddate.ToString("MM/dd/yyyy HH:mm:ss.fff");

            return ("Id: " + id + ", Name: " + name + ", Type: " + typeString + ", Birth Date: " + birthString + ", Sold Date: " + soldString + ", Price: " + price);
        }
    }
}
