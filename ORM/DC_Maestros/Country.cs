using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ORM.DC_Maestros
{
    /// <summary>
    /// Área geográfica bien delimitada, y una entidad políticamente independiente, con su propio gobierno, administración, leyes, y la mayor parte de las veces una constitución, una fuerza policial, fuerzas armadas, leyes tributarias, y un grupo humano.
    /// </summary>
    public class Country
    {

        [Key]
        public Guid CountryId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string CountryName { get; set; }

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
        
        public Country()
        {
        }
        /// <summary>
        /// Creates a new country and asigns a new guid automatically. To be used when inserting a new country to the database
        /// </summary>
        /// <param name="countryname">Name of the country</param>
        /// <param name="userid">User that creates the country</param>
        public Country(string countryname, string userid)
        {
            this.CountryId = Guid.NewGuid();
            this.CountryName = countryname;
            this.DateEntered = DateTime.Now;
            this.DateModified = DateTime.Now;
            this.CreatedByUserId = new Guid(userid);
            this.ModifiedByUserId = new Guid(userid);
            this.AssignedToUserId = new Guid(userid); 
        }

        /// <summary>
        /// Creates a new country and asigns an existing GUID. To be used when retrieving a country from the database
        /// </summary>
        /// <param name="id">ID of the country</param>
        /// <param name="countryname">Name of the country</param>
        /// <param name="userid">User that creates the country</param>
        /// <param name="s">DBContext</param>
        public Country(string id, string countryname, DateTime dateentered, DateTime datemodified, string userid)
        {
            this.CountryId = new Guid(id);
            this.CountryName = countryname;
            this.DateEntered = dateentered;
            this.DateModified = datemodified;
            this.CreatedByUserId = new Guid(userid);
            this.ModifiedByUserId = new Guid(userid);
            this.AssignedToUserId = new Guid(userid);
        }

        public Country(string id, string countryname, DateTime dateentered, DateTime datemodified, string createdbyuserid, string modifiedbyuserid, string assignedtouserid)
        {
            this.CountryId = new Guid(id);
            this.CountryName = countryname;
            this.DateEntered = dateentered;
            this.DateModified = datemodified;
            this.CreatedByUserId = new Guid(createdbyuserid);
            this.ModifiedByUserId = new Guid(modifiedbyuserid);
            this.AssignedToUserId = new Guid(assignedtouserid);
        }

        public IEnumerable<Country> GetAll(SIGEeLDBContext e)
        {
            return (from c in e.Countries
                    orderby c.CountryName ascending
                    select c);
        }

        public Country GetCountryById(SIGEeLDBContext e, string id)
        {
            var query = (from c in e.Countries
                         where c.CountryId == new Guid(id)
                         select c).FirstOrDefault();

            return query;
        }

        public Country GetCountryByName(SIGEeLDBContext e, string name)
        {
            var query = (from c in e.Countries
                         where c.CountryName == name
                         select c).FirstOrDefault();

            return query;
        }
    }
}
