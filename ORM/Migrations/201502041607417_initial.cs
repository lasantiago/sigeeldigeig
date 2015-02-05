namespace ORM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Guid(nullable: false),
                        CountryName = c.String(nullable: false, maxLength: 50),
                        Language_LanguageId = c.Guid(),
                    })
                .PrimaryKey(t => t.CountryId)
                .ForeignKey("dbo.Languages", t => t.Language_LanguageId)
                .Index(t => t.Language_LanguageId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        LanguageId = c.Guid(nullable: false),
                        ISO6391 = c.String(nullable: false),
                        LanguageName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LanguageId);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        RegionId = c.Guid(nullable: false),
                        RegionName = c.String(nullable: false),
                        Country_CountryId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.RegionId)
                .ForeignKey("dbo.Countries", t => t.Country_CountryId, cascadeDelete: true)
                .Index(t => t.Country_CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Regions", "Country_CountryId", "dbo.Countries");
            DropForeignKey("dbo.Countries", "Language_LanguageId", "dbo.Languages");
            DropIndex("dbo.Regions", new[] { "Country_CountryId" });
            DropIndex("dbo.Countries", new[] { "Language_LanguageId" });
            DropTable("dbo.Regions");
            DropTable("dbo.Languages");
            DropTable("dbo.Countries");
        }
    }
}
