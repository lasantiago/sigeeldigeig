using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ORM.DC_Maestros
{
    /// <summary>
    /// Ejecutivo, Legislativo, Judicial, Constitucional, etc...
    /// </summary>
    public class StatePower
    {
        [Key]
        public Guid StatePowerId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string StatePowerName { get; set; }

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
        public StatePower()
        {

        }

        public StatePower(string statepowername)
        {
            this.StatePowerId = Guid.NewGuid();
            this.StatePowerName = statepowername;
        }

        public StatePower(string id, string statepowername)
        {
            this.StatePowerId = new Guid(id);
            this.StatePowerName = statepowername;
        }

        public StatePower(string id, string statepowername, DateTime dateentered, DateTime datemodified, string createdbyuserid, string modifiedbyuserid)
        {
            this.StatePowerId = new Guid(id);
            this.StatePowerName = statepowername;
            this.DateEntered = dateentered;
            this.DateModified = datemodified;
            this.CreatedByUserId = new Guid(createdbyuserid);
            this.ModifiedByUserId = new Guid(modifiedbyuserid);
        }

        public IEnumerable<StatePower> GetAll(SIGEeLDBContext e)
        {
            return (from c in e.StatePowers
                    orderby c.StatePowerName ascending
                    select c);
        }

        public StatePower GetStatePowerById(SIGEeLDBContext e, string id)
        {
            var query = (from c in e.StatePowers
                         where c.StatePowerId == new Guid(id)
                         select c).FirstOrDefault();

            return query;
        }
    }
}
