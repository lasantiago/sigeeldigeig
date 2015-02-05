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
        /// Creates a new country and asigns a new guid automatically
        /// </summary>
        /// <param name="c"></param>
        public Country(string c)
        {
            this.CountryName = c;
            this.CountryId = Guid.NewGuid();
        }


        public Country(string c, string guid)
        {
            this.CountryName = c;
            this.CountryId = new Guid(guid);
        }

        [Key]
        public Guid CountryId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(50)]
        public string CountryName { get; set; }

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
