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

        [Required(ErrorMessageResourceType = typeof(Localization.es_DO), ErrorMessageResourceName = "LocalityNameRequiredError")]
        [DataType(DataType.Text)]
        [Display(Name = "LocalityName", ResourceType = typeof(@Localization.es_DO), Description = "LocalityNameDescription")]
        [StringLength(50, MinimumLength = 3, ErrorMessageResourceType = typeof(@Localization.es_DO), ErrorMessageResourceName = "LocalityNameLengthError")]
        public string LocalityName { get; set; }

        [Required]
        [ForeignKey("RegionId")]
        public Region Region { get; set; }

        public Guid RegionId { get; set; }
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

        [Required(ErrorMessageResourceType = typeof(Localization.es_DO), ErrorMessageResourceName = "AssignedToUserIdRequiredError")]
        [DataType(DataType.Text)]
        [Display(Name = "AssignedToUserId", ResourceType = typeof(Localization.es_DO), Description = "AssignedToUserIdDescription")]
        public Guid AssignedToUserId { get; set; }
        
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
