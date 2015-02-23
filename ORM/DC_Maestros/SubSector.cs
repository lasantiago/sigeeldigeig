using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ORM.DC_Maestros
{
    /// <summary>
    /// Sub-categorización de las instituciones en relación a los sectores temáticos
    /// </summary>
    public class SubSector
    {
        [Key]
        public Guid SubSectorId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string SubSectorName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Localization.es_DO), ErrorMessageResourceName = "DateEnteredRequiredError")]
        [DataType(DataType.DateTime)]
        [Display(Name = "DateEntered", ResourceType = typeof(@Localization.es_DO), Description = "DateEnteredDescription")]
        public DateTime DateEntered { get; set; }

        [Required(ErrorMessageResourceType = typeof(Localization.es_DO), ErrorMessageResourceName = "DateModifiedRequiredError")]
        [DataType(DataType.DateTime)]
        [Display(Name = "DateModified", ResourceType = typeof(@Localization.es_DO), Description = "DateModifiedDescription")]
        public DateTime DateModified { get; set; }

        [Required(ErrorMessageResourceType = typeof(Localization.es_DO), ErrorMessageResourceName = "CreatedByUserIdRequiredError")]
        [DataType(DataType.Text)]
        [Display(Name = "CreatedByUserId", ResourceType = typeof(Localization.es_DO), Description = "CreatedByUserIdDescription")]
        public Guid CreatedByUserId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Localization.es_DO), ErrorMessageResourceName = "ModifiedByUserIdRequiredError")]
        [DataType(DataType.Text)]
        [Display(Name = "ModifiedByUserId", ResourceType = typeof(Localization.es_DO), Description = "ModifiedByUserIdDescription")]
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
