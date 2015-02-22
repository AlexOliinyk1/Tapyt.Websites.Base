using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapyt.Websites.Base.DAL;
using Tapyt.Websites.Base.Services.Domain.Area;
using Tapyt.Websites.Base.Services.Factory;
using Tapyt.Websites.Base.Services.Utils;

namespace Tapyt.Websites.Base.Services.Services
{
    public class AreaService
    {
        private AreaFactory _areaFactory;
        public AreaService()
        {
            _areaFactory = new AreaFactory();
        }

        public Area GetAreaById(Guid id)
        {
            using (var tapyt = new TapytEntities())
            {
                var dbTapyt = tapyt.DbArea.FirstOrDefault(c => c.Id == id);

                if (dbTapyt == null)
                {
                    throw new ArgumentException("No area with this ID");
                }

                var entry = _areaFactory.Create(dbTapyt);
                return entry;
            }
        }

        public Area Create(Area area)
        {
            var newId = Guid.NewGuid();
            using (var tapyt = new TapytEntities())
            {
                var dbArea = new DbArea()
                {
                    Alias = Helpers.GenerateSlug(area.Title),
                    Title = area.Title,
                    Id = newId,
                    Text = area.Text
                };
                tapyt.DbArea.Add(dbArea);
                tapyt.SaveChanges();
            }

            return GetAreaById(newId);
        }

        public List<Area> GetAreaBySpecification(AreaSpecification spec)
        {
            using (var tapyt = new TapytEntities())
            {
                IQueryable<DbArea> areas = tapyt.DbArea;

                if (spec.Alias.Any())
                {
                    areas = areas.Where(c => spec.Alias.Contains(c.Alias));
                }

                var ent = _areaFactory.Create(areas.OrderByDescending(c=>c.Id).Skip(spec.Skip).Take(spec.Take).ToList());
                return ent;
            }
        }
    }
}
