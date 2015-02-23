using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ORM.DC_Maestros
{
    /// <summary>
    /// Categorización de las instituciones en relación a su tipo. Ej.: Ministerios, Direcciones, Departamentos, Consejos, entre otros.
    /// </summary>
    public class InstitutionType
    {
        [Required]
        [Key]
        public Guid InstitutionTypeId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Localization.es_DO), ErrorMessageResourceName = "InstitutionTypeNameRequiredError")]
        [DataType(DataType.Text)]
        [Display(Name = "Name", ResourceType = typeof(Localization.es_DO), Description = "InstitutionTypeNameDescription")]
        [StringLength(50, MinimumLength = 4, ErrorMessageResourceType = typeof(@Localization.es_DO), ErrorMessageResourceName = "InstitutionTypeNameLengthError")]
        public string InstitutionTypeName { get; set; }

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
        
        public InstitutionType()
        {

        }

        public InstitutionType(string institutiontypename)
        {
            this.InstitutionTypeId = Guid.NewGuid();
            this.InstitutionTypeName = institutiontypename;
        }

        public InstitutionType(string id, string institutiontypename)
        {
            this.InstitutionTypeId = new Guid(id);
            this.InstitutionTypeName = institutiontypename;
        }

        public InstitutionType(string id, string institutiontypename, DateTime dateentered, DateTime datemodified, string createdbyuserid, string modifiedbyuserid)
        {
            this.InstitutionTypeId = new Guid(id);
            this.InstitutionTypeName = institutiontypename;
            this.DateEntered = dateentered;
            this.DateModified = datemodified;
            this.CreatedByUserId = new Guid(createdbyuserid);
            this.ModifiedByUserId = new Guid(modifiedbyuserid);
        }

        public IEnumerable<InstitutionType> GetAll(SIGEeLDBContext e)
        {
            return (from c in e.InstitutionTypes
                    orderby c.InstitutionTypeName ascending
                    select c);
        }

        public InstitutionType GetInstitutionTypeById(SIGEeLDBContext e, string id)
        {
            var query = (from c in e.InstitutionTypes
                         where c.InstitutionTypeId == new Guid(id)
                         select c).FirstOrDefault();

            return query;
        }

        public InstitutionType GetInstitutionTypeByName(SIGEeLDBContext e, string name)
        {
            var query = (from c in e.InstitutionTypes
                         where c.InstitutionTypeName == name
                         select c).FirstOrDefault();

            return query;
        }
    }
}
