using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class Country
    {

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
        }

        /// <summary>
        /// Creates a new country and asigns an existing GUID. To be used when retrieving a country from the database
        /// </summary>
        /// <param name="id">ID of the country</param>
        /// <param name="countryname">Name of the country</param>
        /// <param name="userid">User that creates the country</param>
        /// <param name="s">DBContext</param>
        public Country(string id, string countryname, DateTime dateentered, DateTime datemodified)
        {
            this.CountryId = new Guid(id);
            this.CountryName = countryname;
            this.DateEntered = dateentered;
            this.DateModified = datemodified;
        }

        public Country(string id, string countryname, DateTime dateentered, DateTime datemodified, string createdbyuserid, string modifiedbyuserid)
        {
            this.CountryId = new Guid(id);
            this.CountryName = countryname;
            this.DateEntered = dateentered;
            this.DateModified = datemodified;
            this.CreatedByUserId = new Guid(createdbyuserid);
            this.ModifiedByUserId = new Guid(modifiedbyuserid);
        }

        [Key]
        public Guid CountryId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string CountryName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateEntered { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateModified { get; set; }

        public Guid CreatedByUserId { get; set; }
        public Guid ModifiedByUserId { get; set; }


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
