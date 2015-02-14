using System.Data.Entity;

namespace ORM
{
    public class SIGEeLDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        #region DC_Maestros

        public DbSet<ORM.DC_Maestros.Country> Countries { get; set; }
        public DbSet<ORM.DC_Maestros.Region> Regions { get; set; }
        public DbSet<ORM.DC_Maestros.Locality> Localities { get; set; }
        public DbSet<ORM.DC_Maestros.StatePower> StatePowers { get; set; }
        public DbSet<ORM.DC_Maestros.Sector> Sectors { get; set; }
        public DbSet<ORM.DC_Maestros.SubSector> SubSectors { get; set; }
        public DbSet<ORM.DC_Maestros.InstitutionType> InstitutionTypes { get; set; }
        public DbSet<ORM.DC_Maestros.Institution> Institutions { get; set; }

        #endregion

    }
}
