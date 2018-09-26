using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;

namespace PetShop.Core.RepositoryService
{
    public interface IColorRepository
    {
        Color Create(Color color);

        IEnumerable<Color> GetAll();

        Color Get(int id);

        Color Update(Color colorUpdate);

        Color Delete(int id);
    }
}
