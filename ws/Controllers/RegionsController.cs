using System;
using ORM;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
