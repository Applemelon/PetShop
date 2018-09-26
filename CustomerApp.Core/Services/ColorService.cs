using System;
using System.Collections.Generic;
using System.Text;
using PetShop.Core.Entity;
using PetShop.Core.RepositoryService;

namespace PetShop.Core.UIService
{
    public class ColorService : IColorService
    {
        readonly IColorRepository colorRepo;

        public ColorService(IColorRepository colorRepository)
        {
            colorRepo = colorRepository;
        }

        public Color Create(Color color)
        {
            throw new NotImplementedException();
        }

        public Color Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Color Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Color> GetAll()
        {
            throw new NotImplementedException();
        }

        public Color New(string name)
        {
            Color color = new Color()
            {
                name = name
            };

            return color;
        }

        public Color Update(Color colorUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
