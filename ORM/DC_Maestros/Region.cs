using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ORM.DC_Maestros
{
    /// <summary>
    /// Entidades subnacionales del Estado.
    /// </summary>
    public class Region
    {
        [Key]
        public Guid RegionId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Localization.es_DO), ErrorMessageResourceName = "RegionNameRequiredError")]
        [DataType(DataType.Text)]
        [Display(Name = "RegionName", ResourceType = typeof(@Localization.es_DO), Description = "RegionNameDescription")]
        [StringLength(50, MinimumLength = 3, ErrorMessageResourceType = typeof(@Localization.es_DO), ErrorMessageResourceName = "RegionNameLengthError")]
        public string RegionName { get; set; }

        [Required]
        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        [Display(Name = "CountryName", ResourceType = typeof(@Localization.es_DO), Description = "CountryNameDescription")]
        public Guid CountryId { get; set; }

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
