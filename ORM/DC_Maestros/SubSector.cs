using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ORM.DC_Maestros
{
    public class SubSector
    {
        [Key]
        public Guid SubSectorId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string SubSectorName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateEntered { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateModified { get; set; }
        public Guid CreatedByUserId { get; set; }
        public Guid ModifiedByUserId { get; set; }
        public SubSector()
        {

        }

        public SubSector(string subsectorname)
        {
            this.SubSectorId = Guid.NewGuid();
            this.SubSectorName = subsectorname;
        }

        public SubSector(string id, string subsectorname)
        {
            this.SubSectorId = new Guid(id);
            this.SubSectorName = subsectorname;

        }

        public SubSector(string id, string subsectorname, DateTime dateentered, DateTime datemodified, string createdbyuserid, string modifiedbyuserid)
        {
            this.SubSectorId = new Guid(id);
            this.SubSectorName = subsectorname;
            this.DateEntered = dateentered;
            this.DateModified = datemodified;
            this.CreatedByUserId = new Guid(createdbyuserid);
            this.ModifiedByUserId = new Guid(modifiedbyuserid);
        }

        public IEnumerable<SubSector> GetAll(SIGEeLDBContext e)
        {
            return (from c in e.SubSectors
                    orderby c.SubSectorName ascending
                    select c);
        }

        public SubSector GetSubSectorById(SIGEeLDBContext e, string id)
        {
            var query = (from c in e.SubSectors
                         where c.SubSectorId == new Guid(id)
                         select c).FirstOrDefault();

            return query;
        }

        public SubSector GetSubSectorByName(SIGEeLDBContext e, string name)
        {
            var query = (from c in e.SubSectors
                         where c.SubSectorName == name
                         select c).FirstOrDefault();

            return query;
        }
    }
}
