using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entity
{
    public class Color
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<PetColorLine> pets { get; set; }
    }
}
