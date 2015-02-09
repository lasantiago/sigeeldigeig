using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Sector
    {
        public Sector()
        {

        }

        public Sector(string sectorname)
        {
            this.SectorId = Guid.NewGuid();
            this.SectorName = sectorname;
        }

        public Sector(string id, string sectorname)
        {
            this.SectorId = new Guid(id);
            this.SectorName = sectorname;

        }

        public Sector(string id, string sectorname, DateTime dateentered, DateTime datemodified, string createdbyuserid, string modifiedbyuserid)
        {
            this.SectorId = new Guid(id);
            this.SectorName = sectorname;
            this.DateEntered = dateentered;
            this.DateModified = datemodified;
            this.CreatedByUserId = new Guid(createdbyuserid);
            this.ModifiedByUserId = new Guid(modifiedbyuserid);
        }

        [Key]
        public Guid SectorId { get; set; }

        [Required]
        public string SectorName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateEntered { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateModified { get; set; }
        public Guid CreatedByUserId { get; set; }
        public Guid ModifiedByUserId { get; set; }

        public IEnumerable<Sector> GetAll(SIGEeLDBContext e)
        {
            return (from c in e.Sectors
                    orderby c.SectorName ascending
                    select c);
        }

        public Sector GetSectorById(SIGEeLDBContext e, string id)
        {
            var query = (from c in e.Sectors
                         where c.SectorId == new Guid(id)
                         select c).FirstOrDefault();

            return query;
        }

        public Sector GetSectorByName(SIGEeLDBContext e, string name)
        {
            var query = (from c in e.Sectors
                         where c.SectorName == name
                         select c).FirstOrDefault();

            return query;
        }
    }
}
