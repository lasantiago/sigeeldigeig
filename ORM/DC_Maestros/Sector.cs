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
