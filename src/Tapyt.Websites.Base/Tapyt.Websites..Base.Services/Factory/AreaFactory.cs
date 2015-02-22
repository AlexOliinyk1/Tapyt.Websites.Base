using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapyt.Websites.Base.DAL;
using Tapyt.Websites.Base.Services.Domain.Area;

namespace Tapyt.Websites.Base.Services.Factory
{
    public class AreaFactory
    {
        public Area Create(DbArea dbArea)
        {
            return new Area()
            {
                Alias = dbArea.Alias,
                Title = dbArea.Title,
                Id = dbArea.Id,
                Text = dbArea.Text
            };
        }

        public List<Area> Create(List<DbArea> dbAreas)
        {
            return dbAreas.Select(Create).ToList();
        }
    }
}
