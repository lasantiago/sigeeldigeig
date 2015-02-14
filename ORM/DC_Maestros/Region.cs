using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ORM.DC_Maestros
{
    public class Region
    {
        [Key]
        public Guid RegionId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string RegionName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateEntered { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateModified { get; set; }

        [Required]
        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        public Guid CountryId { get; set; }

        public Guid CreatedByUserId { get; set; }
        public Guid ModifiedByUserId { get; set; }
        public Region()
        {

        }

        public Region(string regionname, Country c)
        {
            this.RegionId = Guid.NewGuid();
            this.RegionName = regionname;
            this.DateEntered = DateTime.Now;
            this.DateModified = DateTime.Now;
        }

        public Region(string id, string regioname, DateTime dateentered, DateTime datemodified, Country c)
        {
            this.RegionId = new Guid(id);
            this.RegionName = regioname;
            this.DateEntered = dateentered;
            this.DateModified = datemodified;
            this.Country = c;
            this.CountryId = this.Country.CountryId;
        }

        public Region(string id, string regionname, DateTime dateentered, DateTime datemodified, Country c, string createdbyuserid, string modifiedbyuserid)
        {
            this.RegionId = new Guid(id);
            this.RegionName = regionname;
            this.DateEntered = dateentered;
            this.DateModified = datemodified;
            this.CreatedByUserId = new Guid(createdbyuserid);
            this.ModifiedByUserId = new Guid(modifiedbyuserid);
            this.Country = c;
            this.CountryId = this.Country.CountryId;
        }

        public IEnumerable<Region> GetAll(SIGEeLDBContext e)
        {
            return (from c in e.Regions
                    orderby c.RegionName ascending
                    select c);
        }

        public Region GetRegionById(SIGEeLDBContext e, string id)
        {
            var query = (from c in e.Regions
                         where c.RegionId == new Guid(id)
                         select c).FirstOrDefault();

            return query;
        }

        public Region GetRegionByName(SIGEeLDBContext e, string name)
        {
            var query = (from c in e.Regions
                         where c.RegionName == name
                         select c).FirstOrDefault();

            return query;
        }
    }
}
