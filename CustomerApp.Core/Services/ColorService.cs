using System;
using System.Collections.Generic;
using System.Linq;
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
            return colorRepo.Create(color);
        }

        public Color Delete(int id)
        {
            return colorRepo.Delete(id);
        }

        public Color Get(int id)
        {
            return colorRepo.Get(id);
        }

        public List<Color> GetAll()
        {
            return colorRepo.GetAll().ToList();
        }

        public Color New(string name, string hexcode)
        {
            Color color = new Color()
            {
                name = name,
                hexcode = hexcode
            };

            return color;
        }

        public Color Update(Color colorUpdate)
        {
            return colorRepo.Update(colorUpdate);
        }
    }
}
