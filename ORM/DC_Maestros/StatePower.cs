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

        [Required(ErrorMessageResourceType = typeof(Localization.es_DO), ErrorMessageResourceName = "StatePowerNameRequiredError")]
        [DataType(DataType.Text)]
        [Display(Name = "Name", ResourceType = typeof(@Localization.es_DO), Description = "StatePowerNameDescription")]
        [StringLength(50, MinimumLength = 3, ErrorMessageResourceType = typeof(@Localization.es_DO), ErrorMessageResourceName = "StatePowerNameLengthError")]
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

        [Required(ErrorMessageResourceType = typeof(Localization.es_DO), ErrorMessageResourceName = "AssignedToUserIdRequiredError")]
        [DataType(DataType.Text)]
        [Display(Name = "AssignedToUserId", ResourceType = typeof(Localization.es_DO), Description = "AssignedToUserIdDescription")]
        public Guid AssignedToUserId { get; set; }

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

        public StatePower(string id, string statepowername, DateTime dateentered, DateTime datemodified, string createdbyuserid, string modifiedbyuserid, string assignedtouserid)
        {
            this.StatePowerId = new Guid(id);
            this.StatePowerName = statepowername;
            this.DateEntered = dateentered;
            this.DateModified = datemodified;
            this.CreatedByUserId = new Guid(createdbyuserid);
            this.ModifiedByUserId = new Guid(modifiedbyuserid);
            this.AssignedToUserId = new Guid(assignedtouserid);

            //this.CreatedByUser = new User().GetUserById(context, createdbyuserid);
            //this.ModifiedByUser = new User().GetUserById(context, modifiedbyuserid);
            //this.AssignedToUser = new User().GetUserById(context, AssignedToUserId);
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
