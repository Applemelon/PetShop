using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.UIService
{
    public interface IColorService
    {
        Color New(string name);

        Color Create(Color color);

        Color Get(int id);

        List<Color> GetAll();

        Color Update(Color colorUpdate);

        Color Delete(int id);
    }
}
