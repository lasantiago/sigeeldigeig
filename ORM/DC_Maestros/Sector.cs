using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ORM.DC_Maestros
{
    /// <summary>
    /// Categorización de las instituciones en relación a los sectores temáticos. Ej.: Agua, Economía, Salud, entre otros.
    /// </summary>
    public class Sector
    {
        [Key]
        public Guid SectorId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string SectorName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateEntered { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateModified { get; set; }
        public Guid CreatedByUserId { get; set; }
        public Guid ModifiedByUserId { get; set; }
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
