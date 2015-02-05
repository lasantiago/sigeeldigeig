using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Locality
    {
        public Locality()
        {

        }

        public Locality(string regioname, Region c)
        {
            this.LocalityId = Guid.NewGuid();
            this.LocalityName = regioname;
            this.Region = c;

        }

        public Locality(string id, string localityname, Region c)
        {
            this.LocalityId = new Guid(id);
            this.LocalityName = localityname;
            this.Region = c;

        }

        [Key]
        public Guid LocalityId { get; set; }

        [Required]
        public string LocalityName { get; set; }

        [Required]
        [ForeignKey("RegionId")]
        public Region Region { get; set; }

        public Guid RegionId { get; set; }

        public IEnumerable<Locality> GetAll(SIGEeLDBContext e)
        {
            return (from c in e.Localities
                    orderby c.LocalityName ascending
                    select c);
        }

        public Locality GetLocalityById(SIGEeLDBContext e, string id)
        {
            var query = (from c in e.Localities
                         where c.LocalityId == new Guid(id)
                         select c).FirstOrDefault();

            return query;
        }

        public IEnumerable<Locality> GetLocalitiesByRegionId(SIGEeLDBContext e, string id)
        {
            var query = (from c in e.Localities
                         where c.Region.RegionId == new Guid(id)
                         select c);

            return query;
        }
    }
}
