using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ORM.DC_Maestros
{
    /// <summary>
    /// Entidades administrativas que puede agrupar una sola localidad o varias, que puede hacer referencia a una ciudad, pueblo o aldea.
    /// </summary>
    public class Locality
    {
        [Key]
        public Guid LocalityId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string LocalityName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateEntered { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateModified { get; set; }

        [Required]
        [ForeignKey("RegionId")]
        public Region Region { get; set; }

        public Guid RegionId { get; set; }
        public Guid CreatedByUserId { get; set; }
        public Guid ModifiedByUserId { get; set; }
        public Locality()
        {

        }

        public Locality(string localityname, Region r)
        {
            this.LocalityId = Guid.NewGuid();
            this.LocalityName = localityname;
            this.Region = r;

        }

        public Locality(string id, string localityname, Region r)
        {
            this.LocalityId = new Guid(id);
            this.LocalityName = localityname;
            this.Region = r;
            this.RegionId = this.Region.RegionId;

        }

        public Locality(string id, string localityname, DateTime dateentered, DateTime datemodified, Region r, string createdbyuserid, string modifiedbyuserid)
        {
            this.LocalityId = new Guid(id);
            this.LocalityName = localityname;
            this.DateEntered = dateentered;
            this.DateModified = datemodified;
            this.CreatedByUserId = new Guid(createdbyuserid);
            this.ModifiedByUserId = new Guid(modifiedbyuserid);
            this.Region = r;
            this.RegionId = this.Region.RegionId;
        }

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
