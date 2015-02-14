using ORM;
using ORM.DC_Maestros;
using System.Collections.Generic;
using System.Web.Http;

namespace ws.Controllers
{
    public class InstitutionTypesController : ApiController
    {
        InstitutionType c = new InstitutionType();
        SIGEeLDBContext s = new SIGEeLDBContext();
        public IEnumerable<InstitutionType> GetAllInstitutionTypes()
        {
            return c.GetAll(s);
        }

        public InstitutionType GetInstitutionTypeById(string id)
        {
            return c.GetInstitutionTypeById(s, id);
        }

        public InstitutionType GetInstitutionTypeByName(string name)
        {
            return c.GetInstitutionTypeByName(s, name);
        }
    }
}
