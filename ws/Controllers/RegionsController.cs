using ORM;
using ORM.DC_Maestros;
using System.Collections.Generic;
using System.Web.Http;

namespace ws.Controllers
{
    public class RegionsController : ApiController
    {
        Region r = new Region();
        SIGEeLDBContext s = new SIGEeLDBContext();
        public IEnumerable<Region> GetAllRegions()
        {
            return r.GetAll(s);
        }

        public Region GetRegionById(string id)
        {
            return r.GetRegionById(s, id);
        }

        public Region GetRegionByName(string name)
        {
            return r.GetRegionByName(s, name);
        }
    }
}
