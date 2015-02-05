using System;
using ORM;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ws.Controllers
{
    public class CountriesController : ApiController
    {
        Country c = new Country();
        SIGEeLDBContext s = new SIGEeLDBContext();
        public IEnumerable<Country> GetAllCountries()
        {
            return c.GetAll(s);
        }

        public Country GetCountryById(string id)
        {
            return c.GetCountryById(s, id);
        }

        public Country GetRegionByName(string name)
        {
            return c.GetCountryByName(s, name);
        }
    }
}
