using PetShop.Core.Entity;
using PetShop.Core.RepositoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetShop.Ctx.Repository.Repositories
{
    public class ColorRepository : IColorRepository
    {
        private PetShopContext _ctx;

        public ColorRepository(PetShopContext ctx)
        {
            _ctx = ctx;
        }

        public Color Create(Color color)
        {
            var addedColor = _ctx.Add(color).Entity;
            _ctx.SaveChanges();
            return addedColor;
        }

        public Color Delete(int id)
        {
            var color = _ctx.Remove(new Color { id = id }).Entity;
            _ctx.SaveChanges();
            return color;
        }

        public Color Get(int id)
        {
            var color = _ctx.Colors.FirstOrDefault(c => c.id == id);
            return color;
        }

        public IEnumerable<Color> GetAll()
        {
            return _ctx.Colors;
        }

        public Color Update(Color colorUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
