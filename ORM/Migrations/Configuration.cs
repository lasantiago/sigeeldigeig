namespace ORM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ORM.SIGEeLDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ORM.SIGEeLDBContext context)
        {

            #region Country
            //Country c = new Country("Rep�blica Dominicana", "0e6f4647-e983-403d-af17-062dbf9021e4") ;
            //context.Countries.AddOrUpdate(co => co.CountryName, c);

            #endregion

            #region Regions
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("36538b54-ed1a-8704-7f3a-5256cfbef59d", "Altagracia", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("4270074d-5e7a-55c7-d6a3-5256cf25c071", "Azua", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("507dfd4f-0857-be81-b68b-5256cf1c670b", "Bahoruco", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("609ab191-e2f2-e550-7ca0-5256cfa9bb28", "Barahona", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("6caea519-7bec-34be-449b-5256cfe7e341", "Dajab�n", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("2516e95e-8877-f720-6df7-5256cfcfeaea", "Distrito Nacional", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("78d4de14-ef8c-d5fa-24ad-5256cf6f6298", "Duarte", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("84f1f020-67c8-073a-6722-5256cf654bf6", "El Seibo", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("9102b71d-7a58-0a48-f2bd-5256cfd6257d", "Elias Pi�a", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("9d1f37c0-d69c-cbe6-f10b-5256cf6456db", "Espaillat", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("a92edf91-d65b-e3de-8d7e-5256cff402d6", "Hato Mayor", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("3e0a2cbf-19cf-1ada-3c6d-5256cf999f85", "Hermanas Mirabal", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("b54c3dbf-24fe-dce5-e4d5-5256cf59a811", "Independencia", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("c15af755-ed1e-0819-0eaa-5256cf67e23a", "La Romana", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("d1797b1c-6777-2d56-c60a-5256cf33e2b0", "La Vega", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("dd872718-cff6-49bf-412c-5256cf483e1e", "Mar�a Trinidad S�nchez", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("e9ae396c-b33f-f2d7-b303-5256cfdcbe98", "Monse�or Nouel", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("dae10512-80db-2c3d-f2de-5256cffac887", "Monte Plata", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("19df059d-5287-62b9-bca8-5256cffa92f9", "Montecristi", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("19c9085f-2da0-9b77-0449-5256cfa99cb8", "Pedernales", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("25db66c3-be2b-0ed5-9a6c-5256cf551dd0", "Peravia", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("31f78a39-87fc-d712-0a3c-5256cf8abd2e", "Puerto Plata", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("4a24988c-8d50-c251-2c3d-5256cfb1da60", "Saman�", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("56355c75-f9ef-a34a-568f-5256cf4257b7", "San Crist�bal", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("c721733a-ecd0-3e1a-f64f-5256cfea1c23", "San Jos� de Ocoa", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("6252f600-694a-412a-778c-5256cf7ffc65", "San Juan de la Maguana", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("6e612a7a-5ecf-d2b4-25d1-5256cf5be2d5", "San Pedro de Macoris", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("7bb58279-70be-f9a6-c4ba-5256cf4ce4f9", "S�nchez Ram�rez", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("8e9e12de-9c28-30cd-4bc5-5256cf0fc1e4", "Santiago de los Caballeros", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("9aba9d41-3d30-fd20-47c2-5256cf05bfaf", "Santiago Rodr�guez", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("e740c3bf-2835-925e-4da9-5256cf73feaa", "Santo Domingo", new Country().GetCountryByName(context, "Rep�blica Dominicana")));
            context.Regions.AddOrUpdate(h => h.RegionName, new Region("a6f5174d-b955-edc7-688b-5256cf72115e", "Valverde", new Country().GetCountryByName(context, "Rep�blica Dominicana")));

            #endregion

            #region Localities

            #region Altagracia
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("ccf1e50a-e2ad-968b-0e38-5256d5ac9a12", "BAYAHIBE (DM)", new Region().GetRegionByName(context, "Altagracia")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("50ca0956-6a22-5587-c1de-5256d5e66372", "BOCA DE YUMA (DM)", new Region().GetRegionByName(context, "Altagracia")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("35731f6e-3426-6429-3664-5256d5ac1712", "HIGUEY", new Region().GetRegionByName(context, "Altagracia")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("4ab4e778-003c-3052-6f5b-5256d56b8a1b", "LA LAGUNA DE NISIBON (DM)", new Region().GetRegionByName(context, "Altagracia")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("e23ad7ec-f40e-8619-e18e-5256d5dacfeb", "LA OTRA BANDA (DM)", new Region().GetRegionByName(context, "Altagracia")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("b5ddd5fd-6d2e-6d31-7d8f-5256d5425426", "SAN RAFAEL DEL YUMA", new Region().GetRegionByName(context, "Altagracia")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("1a64e831-01af-c5ac-b2d3-5256d5ee4374", "TURISTICO VERON PUNTA CANA (DM)", new Region().GetRegionByName(context, "Altagracia")));
            #endregion

            #region Azua

            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("5e123721-88c6-1455-768d-5256d5c07c81", "AMIAMA GOMEZ (DM)", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("7908d8d8-adc4-a512-f9e5-5256d540dc56", "AZUA", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("cfc845fb-39bd-c312-b9ef-5256d55cda29", "BARRERAS (DM)", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("309efefd-6b1a-4a41-4536-5256d5ba971b", "BARRO ARRIBA (DM)", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("7a11ece8-b4ba-444c-c27d-5256d5e43171", "DO�A EMMA BALAGUER VDA. VALLEJO", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("c7e76f00-edbd-ac27-dcb7-5256d544ac4a", "EL ROSARIO (DM)", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("be330a95-4828-2ba7-b31a-5256d509195d", "ESTEBANIA", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("a763efd3-b385-9b39-4190-5256d5328626", "GUAYABAL", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("214105cb-cec7-0689-a8b3-5256d5dbbed1", "HATO NUEVO CORTES (DM)", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("a37fb37c-2f5e-fffa-deb4-5256d5493122", "LA SIEMBRA (DM)", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("dd656e67-ee14-79a7-1ea8-5256d59948cf", "LAS BARIAS-LA ESTANCIA (DM)", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("24ff578b-ed9a-eb89-547d-5256d594ceec", "LAS CHARCAS", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("94e2e281-23c5-f723-e302-5256d56c306d", "LAS CLAVELLINAS (DM)", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("8c6c30f4-b66c-9e1a-a96b-5256d57c98a0", "LAS LAGUNAS (DM)", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("e50ea1b0-017c-8c47-9598-5256d5a70e97", "LAS LOMAS (DM)", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("d3b0cd19-d875-98bf-c69b-5256d5a166dd", "LAS YAYAS DE VIAJAMA", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("4d9d29c6-bdd1-abaf-eab7-5256d5954b2a", "LOS FRIOS (DM)", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("57060d6d-7084-fa07-274d-5256d5740181", "LOS JOVILLOS (DM)", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("66934289-1202-7762-42af-5256d5d32525", "LOS TOROS (DM)", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("c0240002-ac38-9bef-b175-5256d5827dc4", "MONTE BONITO (DM)", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("90218ef9-c9ea-961a-fcfc-5256d5dc9ff7", "PADRE LAS CASAS", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("514bcd59-5c87-9a11-769d-5256d579b721", "PALMAR DE OCOA (DM)", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("b8b2c639-a8d1-5c41-ddeb-5256d570be5e", "PERALTA", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("978f61db-69ef-1a6c-f05c-5256d5cac365", "PROYECTO #4 (DM)", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("385bc73c-da76-660c-1c1c-5256d5ce3d11", "PROYECTO 2-C (DM)", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("b1111563-c2aa-9c92-e280-5256d5d29fb2", "PROYECTO D-1 GANADERO (DM)", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("3a3cb13a-df9b-679f-3151-5256d5b567cd", "PUEBLO VIEJO", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("648bdcf6-0bab-4fd8-d7b3-5256d5e11aeb", "PUERTO VIEJO-LOS NEGROS (DM)", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("be72eb67-65f1-be67-6c37-5256d5509d7b", "SABANA YEGUA", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("771e96db-d686-2b6c-47c2-5256d5e967b9", "TABARA ABAJO (DM)", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("eac9d6e9-5860-51fd-633b-5256d5d39e7b", "TABARA ARRIBA", new Region().GetRegionByName(context, "Azua")));
            context.Localities.AddOrUpdate(h => h.LocalityName, new Locality("63cc260c-3dca-2cbf-aab8-5256d58bb065", "VILLARPANDO (DM)", new Region().GetRegionByName(context, "Azua")));
            #endregion
            


            #endregion


            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
