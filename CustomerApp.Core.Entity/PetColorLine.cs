using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entity
{
    public class PetColorLine
    {
        
        public int colorId { get; set; }
        public Color color { get; set; }

        public int petId { get; set; }
        public Pet pet { get; set; }
    }
}
