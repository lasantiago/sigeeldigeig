using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class StatePower
    {
        public StatePower()
        {

        }

        public StatePower (string statepowerame)
        {
            this.StatePowerId = Guid.NewGuid();
            this.StatePowerName = statepowerame;
        }

        [Key]
        public Guid StatePowerId { get; set; }

        [Required]
        public string StatePowerName { get; set; }

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
