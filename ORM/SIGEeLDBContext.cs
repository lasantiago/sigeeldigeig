using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class SIGEeLDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Locality> Localities { get; set; }
        public DbSet<StatePower> StatePowers { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<SubSector> SubSectors { get; set; }
        public DbSet<InstitutionType> InstitutionTypes { get; set; }

    }
}
