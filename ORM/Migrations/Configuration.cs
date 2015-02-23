namespace ORM.Migrations
{
    using System;
    using ORM.DC_Maestros;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using System.Data.Entity.Validation;

    internal sealed class Configuration : DbMigrationsConfiguration<ORM.SIGEeLDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ORM.SIGEeLDBContext context)
        {
            DateTime dateentered = new DateTime(2012, 08, 26);

            #region Users

            // List of default users to be added
            var users = new List<User>
            {
                new User{UserId = new Guid("488b56d5-b52f-4d09-bc48-7f4b0743cbac"), UserName = "admin"} 
            };

            // Adds all base users to the context 
            users.ForEach(us => context.Users.AddOrUpdate(usr => usr.UserName, us));

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }

            #endregion

            // DEFAULT UserId for base records
            Guid createdbyuserid = new User().GetUserByUserName(context, "admin").UserId;
            Guid modifiedbyuserid = createdbyuserid;
            Guid assignedtouserid = createdbyuserid;

            #region Country

            var countries = new List<Country>
            {
                new Country{CountryId = new Guid("8EB0B763-D8F3-441B-A177-98E51179FA19"), CountryName = "República Dominicana", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid, AssignedToUserId = assignedtouserid} 
            };

            countries.ForEach(co => context.Countries.AddOrUpdate(country => country.CountryName, co));

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }

            #endregion

            // Default CountryId for base records
            Guid countryid = new Country().GetCountryByName(context, "República Dominicana").CountryId;

            #region Regions

            // Default list of base regions
            var regions = new List<Region>
            {
                new Region{RegionId = new Guid("36538b54-ed1a-8704-7f3a-5256cfbef59d"), RegionName = "Altagracia", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("4270074d-5e7a-55c7-d6a3-5256cf25c071"), RegionName = "Azua", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("507dfd4f-0857-be81-b68b-5256cf1c670b"), RegionName = "Bahoruco", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("609ab191-e2f2-e550-7ca0-5256cfa9bb28"), RegionName = "Barahona", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("6caea519-7bec-34be-449b-5256cfe7e341"), RegionName = "Dajabón", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("2516e95e-8877-f720-6df7-5256cfcfeaea"), RegionName = "Distrito Nacional", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("78d4de14-ef8c-d5fa-24ad-5256cf6f6298"), RegionName = "Duarte", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("84f1f020-67c8-073a-6722-5256cf654bf6"), RegionName = "El Seibo", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("9102b71d-7a58-0a48-f2bd-5256cfd6257d"), RegionName = "Elias Piña", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("9d1f37c0-d69c-cbe6-f10b-5256cf6456db"), RegionName = "Espaillat", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("a92edf91-d65b-e3de-8d7e-5256cff402d6"), RegionName = "Hato Mayor", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("3e0a2cbf-19cf-1ada-3c6d-5256cf999f85"), RegionName = "Hermanas Mirabal", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("b54c3dbf-24fe-dce5-e4d5-5256cf59a811"), RegionName = "Independencia", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("c15af755-ed1e-0819-0eaa-5256cf67e23a"), RegionName = "La Romana", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("d1797b1c-6777-2d56-c60a-5256cf33e2b0"), RegionName = "La Vega", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("dd872718-cff6-49bf-412c-5256cf483e1e"), RegionName = "María Trinidad Sánchez", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("e9ae396c-b33f-f2d7-b303-5256cfdcbe98"), RegionName = "Monseñor Nouel", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("dae10512-80db-2c3d-f2de-5256cffac887"), RegionName = "Monte Plata", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("19df059d-5287-62b9-bca8-5256cffa92f9"), RegionName = "Montecristi", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("19c9085f-2da0-9b77-0449-5256cfa99cb8"), RegionName = "Pedernales", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("25db66c3-be2b-0ed5-9a6c-5256cf551dd0"), RegionName = "Peravia", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("31f78a39-87fc-d712-0a3c-5256cf8abd2e"), RegionName = "Puerto Plata", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("4a24988c-8d50-c251-2c3d-5256cfb1da60"), RegionName = "Samaná", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("56355c75-f9ef-a34a-568f-5256cf4257b7"), RegionName = "San Cristóbal", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("c721733a-ecd0-3e1a-f64f-5256cfea1c23"), RegionName = "San José de Ocoa", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("6252f600-694a-412a-778c-5256cf7ffc65"), RegionName = "San Juan de la Maguana", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("6e612a7a-5ecf-d2b4-25d1-5256cf5be2d5"), RegionName = "San Pedro de Macoris", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("7bb58279-70be-f9a6-c4ba-5256cf4ce4f9"), RegionName = "Sánchez Ramírez", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("8e9e12de-9c28-30cd-4bc5-5256cf0fc1e4"), RegionName = "Santiago de los Caballeros", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("9aba9d41-3d30-fd20-47c2-5256cf05bfaf"), RegionName = "Santiago Rodríguez", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("e740c3bf-2835-925e-4da9-5256cf73feaa"), RegionName = "Santo Domingo", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Region{RegionId = new Guid("a6f5174d-b955-edc7-688b-5256cf72115e"), RegionName = "Valverde", CountryId = countryid,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid}
    
            };

            // Adds all base regions to the context 
            regions.ForEach(re => context.Regions.AddOrUpdate(reg => reg.RegionName, re));

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }

            #endregion

            #region Localities

            Guid regionidaltagracia = new Region().GetRegionByName(context, "Altagracia").RegionId;
            Guid regionidazua = new Region().GetRegionByName(context, "Azua").RegionId;
            Guid regionidbahoruco = new Region().GetRegionByName(context, "Bahoruco").RegionId;
            Guid regionidbarahona = new Region().GetRegionByName(context, "Barahona").RegionId;
            Guid regioniddajabon = new Region().GetRegionByName(context, "Dajabón").RegionId;
            Guid regioniddistritonacional = new Region().GetRegionByName(context, "Distrito Nacional").RegionId;
            Guid regionidduarte = new Region().GetRegionByName(context, "Duarte").RegionId;
            Guid regionidelseibo = new Region().GetRegionByName(context, "El Seibo").RegionId;
            Guid regionideliaspina = new Region().GetRegionByName(context, "Elias Piña").RegionId;
            Guid regionidespaillat = new Region().GetRegionByName(context, "Espaillat").RegionId;
            Guid regionidhatomayor = new Region().GetRegionByName(context, "Hato Mayor").RegionId;
            Guid regionidindependencia = new Region().GetRegionByName(context, "Independencia").RegionId;
            Guid regionidlaromana = new Region().GetRegionByName(context, "La Romana").RegionId;
            Guid regionidlavega = new Region().GetRegionByName(context, "La Vega").RegionId;
            Guid regionidmariatrinidadsanchez = new Region().GetRegionByName(context, "María Trinidad Sánchez").RegionId;
            Guid regionidmonsenornouel = new Region().GetRegionByName(context, "Monseñor Nouel").RegionId;
            Guid regionidmonteplata = new Region().GetRegionByName(context, "Monte Plata").RegionId;
            Guid regionidmontecristi = new Region().GetRegionByName(context, "Montecristi").RegionId;
            Guid regionidpedernales = new Region().GetRegionByName(context, "Pedernales").RegionId;
            Guid regionidperavia = new Region().GetRegionByName(context, "Peravia").RegionId;
            Guid regionidpuertoplata = new Region().GetRegionByName(context, "Puerto Plata").RegionId;
            Guid regionidsamana = new Region().GetRegionByName(context, "Samaná").RegionId;
            Guid regionidsancristobal = new Region().GetRegionByName(context, "San Cristóbal").RegionId;
            Guid regionidsanjosedeocoa = new Region().GetRegionByName(context, "San José de Ocoa").RegionId;
            Guid regionidsanjuandelamaguana = new Region().GetRegionByName(context, "San Juan de la Maguana").RegionId;
            Guid regionidsanpedrodemacoris = new Region().GetRegionByName(context, "San Pedro de Macoris").RegionId;
            Guid regionidsanchezramirez = new Region().GetRegionByName(context, "Sánchez Ramírez").RegionId;
            Guid regionidsantiagodeloscaballeros = new Region().GetRegionByName(context, "Santiago de los Caballeros").RegionId;
            Guid regionidssantiagorodriguez = new Region().GetRegionByName(context, "Santiago Rodríguez").RegionId;
            Guid regionidvalverde = new Region().GetRegionByName(context, "Valverde").RegionId;

            var localities = new List<Locality>
            {

            #region Altagracia

                new Locality{LocalityId = new Guid("ccf1e50a-e2ad-968b-0e38-5256d5ac9a12"), LocalityName = "BAYAHIBE (DM)", RegionId = regionidaltagracia,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("50ca0956-6a22-5587-c1de-5256d5e66372"), LocalityName = "BOCA DE YUMA (DM)", RegionId = regionidaltagracia,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("35731f6e-3426-6429-3664-5256d5ac1712"), LocalityName = "HIGUEY", RegionId = regionidaltagracia,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("4ab4e778-003c-3052-6f5b-5256d56b8a1b"), LocalityName = "LA LAGUNA DE NISIBON (DM)", RegionId = regionidaltagracia,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("e23ad7ec-f40e-8619-e18e-5256d5dacfeb"), LocalityName = "LA OTRA BANDA (DM)", RegionId = regionidaltagracia,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("b5ddd5fd-6d2e-6d31-7d8f-5256d5425426"), LocalityName = "SAN RAFAEL DEL YUMA", RegionId = regionidaltagracia,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("1a64e831-01af-c5ac-b2d3-5256d5ee4374"), LocalityName = "TURISTICO VERON PUNTA CANA (DM)", RegionId = regionidaltagracia,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            
            #endregion

            #region Azua

                new Locality{LocalityId = new Guid("5e123721-88c6-1455-768d-5256d5c07c81"), LocalityName = "AMIAMA GOMEZ (DM)", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("7908d8d8-adc4-a512-f9e5-5256d540dc56"), LocalityName = "AZUA", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("cfc845fb-39bd-c312-b9ef-5256d55cda29"), LocalityName = "BARRERAS (DM)", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("309efefd-6b1a-4a41-4536-5256d5ba971b"), LocalityName = "BARRO ARRIBA (DM)", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("7a11ece8-b4ba-444c-c27d-5256d5e43171"), LocalityName = "DOÑA EMMA BALAGUER VDA. VALLEJO", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("c7e76f00-edbd-ac27-dcb7-5256d544ac4a"), LocalityName = "EL ROSARIO (DM)", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("be330a95-4828-2ba7-b31a-5256d509195d"), LocalityName = "ESTEBANIA", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("a763efd3-b385-9b39-4190-5256d5328626"), LocalityName = "GUAYABAL", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("214105cb-cec7-0689-a8b3-5256d5dbbed1"), LocalityName = "HATO NUEVO CORTES (DM)", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("a37fb37c-2f5e-fffa-deb4-5256d5493122"), LocalityName = "LA SIEMBRA (DM)", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("dd656e67-ee14-79a7-1ea8-5256d59948cf"), LocalityName = "LAS BARIAS-LA ESTANCIA (DM)", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("24ff578b-ed9a-eb89-547d-5256d594ceec"), LocalityName = "LAS CHARCAS", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("94e2e281-23c5-f723-e302-5256d56c306d"), LocalityName = "LAS CLAVELLINAS (DM)", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("8c6c30f4-b66c-9e1a-a96b-5256d57c98a0"), LocalityName = "LAS LAGUNAS (DM)", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("e50ea1b0-017c-8c47-9598-5256d5a70e97"), LocalityName = "LAS LOMAS (DM)", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("d3b0cd19-d875-98bf-c69b-5256d5a166dd"), LocalityName = "LAS YAYAS DE VIAJAMA", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("4d9d29c6-bdd1-abaf-eab7-5256d5954b2a"), LocalityName = "LOS FRIOS (DM)", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("57060d6d-7084-fa07-274d-5256d5740181"), LocalityName = "LOS JOVILLOS (DM)", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("66934289-1202-7762-42af-5256d5d32525"), LocalityName = "LOS TOROS (DM)", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("c0240002-ac38-9bef-b175-5256d5827dc4"), LocalityName = "MONTE BONITO (DM)", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("90218ef9-c9ea-961a-fcfc-5256d5dc9ff7"), LocalityName = "PADRE LAS CASAS", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("514bcd59-5c87-9a11-769d-5256d579b721"), LocalityName = "PALMAR DE OCOA (DM)", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("b8b2c639-a8d1-5c41-ddeb-5256d570be5e"), LocalityName = "PERALTA", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("978f61db-69ef-1a6c-f05c-5256d5cac365"), LocalityName = "PROYECTO #4 (DM)", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("385bc73c-da76-660c-1c1c-5256d5ce3d11"), LocalityName = "PROYECTO 2-C (DM)", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("b1111563-c2aa-9c92-e280-5256d5d29fb2"), LocalityName = "PROYECTO D-1 GANADERO (DM)", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("3a3cb13a-df9b-679f-3151-5256d5b567cd"), LocalityName = "PUEBLO VIEJO", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("648bdcf6-0bab-4fd8-d7b3-5256d5e11aeb"), LocalityName = "PUERTO VIEJO-LOS NEGROS (DM)", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("be72eb67-65f1-be67-6c37-5256d5509d7b"), LocalityName = "SABANA YEGUA", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("771e96db-d686-2b6c-47c2-5256d5e967b9"), LocalityName = "TABARA ABAJO (DM)", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("eac9d6e9-5860-51fd-633b-5256d5d39e7b"), LocalityName = "TABARA ARRIBA", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("63cc260c-3dca-2cbf-aab8-5256d58bb065"), LocalityName = "VILLARPANDO (DM)", RegionId = regionidazua,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            
            #endregion

            #region Bahoruco

                new Locality{LocalityId = new Guid("cc264d9e-1897-e0fc-6338-5256d5d81935"), LocalityName = "CABEZA DE TORO (DM)", RegionId = regionidbahoruco,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("5819b432-cfa8-e027-9fd7-5256d584efea"), LocalityName = "EL PALMAR (DM)", RegionId = regionidbahoruco,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("c1319121-0e9b-1426-3876-5256d5029468"), LocalityName = "EL SALADO", RegionId = regionidbahoruco,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("b6bf91d4-dcfa-aa78-6455-5256d516271c"), LocalityName = "GALVAN", RegionId = regionidbahoruco,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("6d6c47ac-5f51-5bdc-c1d2-5256d5b95a2a"), LocalityName = "LAS CLAVELLINAS (DM)", RegionId = regionidbahoruco,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("2bb47106-042d-39e4-355e-5256d5359c5e"), LocalityName = "LOS RIOS", RegionId = regionidbahoruco,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("aa41f963-be2e-3245-b63a-5256d51c35ce"), LocalityName = "MENA (DM)", RegionId = regionidbahoruco,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("9fd19bd4-2475-7650-a0aa-5256d53419d5"), LocalityName = "MONSERRAT (DM)", RegionId = regionidbahoruco,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("d689403d-7aea-8746-0ff6-5256d5f59c49"), LocalityName = "NEYBA", RegionId = regionidbahoruco,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("4127bd5d-1097-701f-11a4-5256d5aedd3c"), LocalityName = "SANTA BARBARA EL 6", RegionId = regionidbahoruco,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("848ffc37-854b-a0af-692a-5256d50437de"), LocalityName = "SANTANA (DM)", RegionId = regionidbahoruco,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("ed771232-d84b-dbad-ce84-5256d53c413e"), LocalityName = "TAMAYO", RegionId = regionidbahoruco,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("e3183a89-ae8b-454a-0004-5256d57a89a4"), LocalityName = "UVILLA (DM)", RegionId = regionidbahoruco,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("1309bab1-b244-6e81-8045-5256d5fbd9a2"), LocalityName = "VILLA JARAGUA", RegionId = regionidbahoruco,DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},

            #endregion
            
            #region Barahona

                new Locality{LocalityId = new Guid("8384edee-a1a7-1988-049f-5256d5e58cfa"), LocalityName = "ARROYO DULCE (DM)", RegionId = regionidbarahona, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("b3e0bdd9-12ae-06cc-d79a-5256d5e93623"), LocalityName = "BAHORUCO (DM)", RegionId = regionidbarahona, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("44c30984-dd52-1d13-9350-5256d5e44c62"), LocalityName = "BARAHONA", RegionId = regionidbarahona, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("3df831c3-7e3c-a144-6977-5256d51318a9"), LocalityName = "CABRAL", RegionId = regionidbarahona, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("c3bd0c65-dd9f-f622-7c78-5256d58ff699"), LocalityName = "CANOA (DM)", RegionId = regionidbarahona, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("e03d0ce5-4d82-3502-2ff3-5256d526c868"), LocalityName = "EL CACHON (DM)", RegionId = regionidbarahona, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("e039f58a-8024-9dc3-47c0-5256d5c4a531"), LocalityName = "EL PEÑON", RegionId = regionidbarahona, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("36bf403d-714c-acf2-1987-5256d5754a21"), LocalityName = "ENRIQUILLO", RegionId = regionidbarahona, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("6cb500bb-ff77-077a-1f44-5256d57d7931"), LocalityName = "FONDO NEGRO (DM)", RegionId = regionidbarahona, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("7bf3c2d8-f834-1e9a-932f-5256d5ce5334"), LocalityName = "FUNDACION", RegionId = regionidbarahona, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("ea147890-6879-c312-3c41-5256d55e087a"), LocalityName = "JAQUIMEYES", RegionId = regionidbarahona, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("ae5d152e-3d31-d5cb-1cfe-5256d565c827"), LocalityName = "LA CIENAGA", RegionId = regionidbarahona, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("1f33de34-28c6-7dee-c469-5256d504f314"), LocalityName = "LA GUAZARA (DM)", RegionId = regionidbarahona, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("95b64df6-81b1-db7d-6475-5256d55b0cec"), LocalityName = "LAS SALINAS", RegionId = regionidbarahona, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("405ef1b7-67d3-b245-8ceb-5256d5c09f68"), LocalityName = "LOS PATOS (DM)", RegionId = regionidbarahona, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("9bafc79d-0137-ad92-5cb0-5256d5bde885"), LocalityName = "PALO ALTO (DM)", RegionId = regionidbarahona, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("c95b62b1-8bad-0af9-219b-5256d5e6f5d2"), LocalityName = "PARAISO", RegionId = regionidbarahona, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("2ae39979-d3d8-205f-3760-5256d58aabc5"), LocalityName = "PESCADERIA (DM)", RegionId = regionidbarahona, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("64ff5351-49f6-0581-2080-5256d5d09569"), LocalityName = "POLO", RegionId = regionidbarahona, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("573a4b9a-3645-cb57-0ef3-5256d53d943c"), LocalityName = "QUITA CORAZA (DM)", RegionId = regionidbarahona, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("4fa87dc9-23e5-e76f-42cc-5256d5830a9d"), LocalityName = "VICENTE NOBLE", RegionId = regionidbarahona, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("18db0d1c-6897-4793-1b5b-5256d53f175b"), LocalityName = "VILLA CENTRAL", RegionId = regionidbarahona, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            
            #endregion

            #region Dajabón

                new Locality{LocalityId = new Guid("b3830f38-69f2-fe10-590f-5256d5907275"), LocalityName = "CAÑONGO (DM)", RegionId = regioniddajabon, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("13720a96-6b81-04c9-07e3-5256d546bdf6"), LocalityName = "CAPOTILLO (DM)", RegionId = regioniddajabon, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("8329cdc2-4aab-3d7f-5aa8-5256d5c20f53"), LocalityName = "DAJABON", RegionId = regioniddajabon, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("c8f8adc9-8ead-43e7-466e-5256d54c7db0"), LocalityName = "EL PINO", RegionId = regioniddajabon, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("9893438b-f4a5-6868-d3c9-5256d5cf35a6"), LocalityName = "LOMA DE CABRERA", RegionId = regioniddajabon, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("dfca6591-6e0c-12f5-cc67-5256d58319be"), LocalityName = "MANUEL BUENO (DM)", RegionId = regioniddajabon, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("1805e801-b05e-9b03-3c29-5256d59bce3a"), LocalityName = "PARTIDO", RegionId = regioniddajabon, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("6c4ca33b-4c87-631b-832a-5256d56791b3"), LocalityName = "RESTAURACION", RegionId = regioniddajabon, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("56ce6db7-4887-b2eb-72a7-5256d568f90b"), LocalityName = "SANTIAGO DE LA CRUZ (DM)", RegionId = regioniddajabon, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},

            #endregion

            #region Distrito Nacional

                new Locality{LocalityId = new Guid("9d50cc89-62ca-e36c-f1cf-5256d5d2be3e"), LocalityName = "DISTRITO NACIONAL", RegionId = regioniddistritonacional, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},

            #endregion

            #region Duarte

                new Locality{LocalityId = new Guid("baee0a76-6a6a-59aa-2048-5256d5fa56a0"), LocalityName = "AGUA SANTA DEL YUNA (DM)", RegionId = regionidduarte, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("8a435f8a-19b7-cad6-d099-5256d5a82739"), LocalityName = "ARENOSO", RegionId = regionidduarte, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("781db73c-a00f-ab48-8cee-5256d593c1d5"), LocalityName = "BARRAQUITO (DM)", RegionId = regionidduarte, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("5ddde709-b4d7-a483-af18-5256d599a408"), LocalityName = "CASTILLO", RegionId = regionidduarte, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("987a0d2f-3323-e859-e95a-5256d5fd83bf"), LocalityName = "CENOVI (DM)", RegionId = regionidduarte, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("d16319aa-3345-093a-54cc-5256d5ae2af7"), LocalityName = "CRISTO REY DE GUARAGUAO (DM)", RegionId = regionidduarte, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("2437b310-fd48-81c2-44c5-5256d5a954ff"), LocalityName = "DON ANTONIO GUZMAN FERNANDEZ (DM)", RegionId = regionidduarte, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("4afb405f-dbc1-8310-127e-5256d5d3fef8"), LocalityName = "EL AGUACATE (DM)", RegionId = regionidduarte, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("74ab6bd9-5d82-e47a-17b2-5256d5d30de9"), LocalityName = "EUGENIO MARIA DE HOSTOS", RegionId = regionidduarte, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("485f0d96-c9f4-d9a0-9b4a-5256d5d00a18"), LocalityName = "JAYA (DM)", RegionId = regionidduarte, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("e7524cb4-a5a3-727a-5ecf-5256d5c60ccd"), LocalityName = "LA PEÑA (DM)", RegionId = regionidduarte, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("35de3276-2464-3828-dc3c-5256d5424c26"), LocalityName = "LAS COLES (DM)", RegionId = regionidduarte, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("a0ffb1f4-c280-f37d-3179-5256d5b2fd60"), LocalityName = "LAS GUARANAS", RegionId = regionidduarte, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("1f838487-6ac1-e0eb-70f8-5256d51e7642"), LocalityName = "LAS TARANAS (DM)", RegionId = regionidduarte, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("31907daf-9db3-9d22-23ad-5256d5766c99"), LocalityName = "PIMENTEL", RegionId = regionidduarte, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("4c2357ca-c3d6-a5cc-46b8-5256d58d1d69"), LocalityName = "SABANA GRANDE (DM)", RegionId = regionidduarte, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("62326e32-90a5-45f5-4fc0-5256d57d8c22"), LocalityName = "SAN FRANCISCO DE MACORIS", RegionId = regionidduarte, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("5f2fad5e-abae-8542-c661-5256d5327cd2"), LocalityName = "VILLA RIVA", RegionId = regionidduarte, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},

            #endregion

            #region El Seibo

                new Locality{LocalityId = new Guid("b7cdeec0-b748-35d6-f75e-5256d5c9ea0c"), LocalityName = "EL JOVERO (EL CEDRO) (DM)", RegionId = regionidelseibo, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("8b77a406-8903-9c46-306f-5256d58161de"), LocalityName = "EL SEIBO", RegionId = regionidelseibo, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("e4111efb-e074-85e6-f7a5-5256d55328bd"), LocalityName = "LA GINA (DM)", RegionId = regionidelseibo, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("a1a89dc8-7ade-9ce3-0433-5256d5224336"), LocalityName = "MICHES", RegionId = regionidelseibo, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("6219042f-1e37-6235-94d2-5256d5e91913"), LocalityName = "PEDRO SANCHEZ (DM)", RegionId = regionidelseibo, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("754547de-9017-ee09-0e2d-5256d59ca06c"), LocalityName = "SAN FRANCISCO-VICENTILLO (DM)", RegionId = regionidelseibo, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("cdfef2c9-f593-1ece-5772-5256d5219276"), LocalityName = "SANTA LUCIA-LA HIGUERA (DM)", RegionId = regionidelseibo, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},

            #endregion

            #region Elias Piña

                new Locality{LocalityId = new Guid("327db873-20f4-4312-4aa5-5256d578fc8a"), LocalityName = "BANICA", RegionId = regionideliaspina, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("489b3077-e350-7d3a-9ca9-5256d58ee76a"), LocalityName = "COMENDADOR", RegionId = regionideliaspina, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("bb753701-657f-fe0d-5865-5256d5d96378"), LocalityName = "EL LLANO", RegionId = regionideliaspina, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("d1af06ba-e2ba-db7f-81ea-5256d51ece2e"), LocalityName = "GUANITO (DM)", RegionId = regionideliaspina, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("1c4d615d-5fff-f174-e7b6-5256d5b124a0"), LocalityName = "GUAYABO (DM)", RegionId = regionideliaspina, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("89605bfa-47af-3d03-dfcf-5256d5ddaaea"), LocalityName = "HONDO VALLE", RegionId = regionideliaspina, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("647edf35-19ba-bc97-1ff7-5256d524b6ce"), LocalityName = "JUAN SANTIAGO", RegionId = regionideliaspina, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("5ec72248-1a35-7753-569d-5256d5406a90"), LocalityName = "PEDRO SANTANA", RegionId = regionideliaspina, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("4e5a3f06-7f52-00c0-5b0c-5256d574b21e"), LocalityName = "RANCHO DE LA GUARDIA (DM)", RegionId = regionideliaspina, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("e7cf4747-7d13-78a2-bed7-5256d5de597f"), LocalityName = "RIO LIMPIO (DM)", RegionId = regionideliaspina, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("202225c7-52eb-ae10-5c5e-5256d5f5695c"), LocalityName = "SABANA CRUZ (DM)", RegionId = regionideliaspina, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("382fb8ad-3a73-e422-d5f7-5256d59d2aa7"), LocalityName = "SABANA HIGUERO (DM)", RegionId = regionideliaspina, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("9d500257-69c5-8209-6268-5256d5d07cdf"), LocalityName = "SABANA LARGA (DM)", RegionId = regionideliaspina, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},

            #endregion

            #region Espaillat

                new Locality{LocalityId = new Guid("35bd34ee-8b66-7c40-b89c-5256d5d58337"), LocalityName = "CANCA LA REYNA (DM)", RegionId = regionidespaillat, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("beb40ea8-571f-45a7-ff65-5256d55942a3"), LocalityName = "CAYETANO GERMOSEN", RegionId = regionidespaillat, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("a89b31dd-204c-6b3f-700f-5256d5164885"), LocalityName = "GASPAR HERNANDEZ", RegionId = regionidespaillat, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("e77d66c8-1730-1ee5-d8e9-5256d56631a4"), LocalityName = "HIGUERITO (DM)", RegionId = regionidespaillat, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("90df6f32-ed9c-9193-ca34-5256d55fabde"), LocalityName = "JAMAO AL NORTE", RegionId = regionidespaillat, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("bd9f80c2-05a9-017f-f264-5256d56dee31"), LocalityName = "JOBA ARRIBA (DM)", RegionId = regionidespaillat, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("7aa3d9ef-a299-39e6-d8e8-5256d51cca34"), LocalityName = "JOSE CONTRERAS (DM)", RegionId = regionidespaillat, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("d326d331-ddb9-122a-de80-5256d5676699"), LocalityName = "JUAN LOPEZ ABAJO (EL MAMEY) (DM)", RegionId = regionidespaillat, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("7e4166e6-27f6-cf30-6ebd-5256d57cb4a6"), LocalityName = "LAS LAGUNAS ABAJO (DM)", RegionId = regionidespaillat, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("945a2b2a-2bbc-88c4-bde1-5256d5143bef"), LocalityName = "MOCA", RegionId = regionidespaillat, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("97340b71-9274-99d4-9a2f-5256d5ef8304"), LocalityName = "MONTE DE LA JAGUA (DM)", RegionId = regionidespaillat, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("1fa8ce47-1f56-caf2-bd30-5256d5342b39"), LocalityName = "ORTEGA (DM)", RegionId = regionidespaillat, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("a6ff1ecf-1adf-933e-5a9d-5256d51a74b1"), LocalityName = "SAN VICTOR (DM)", RegionId = regionidespaillat, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("680c6b31-26f1-2f23-3c86-5256d5572d7a"), LocalityName = "VERAGUA (DM)", RegionId = regionidespaillat, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Locality{LocalityId = new Guid("501480f8-6881-9dba-fbca-5256d54ec3b2"), LocalityName = "VILLA MAGANTE (DM)", RegionId = regionidespaillat, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},

            #endregion

            #region Hato Mayor
            
            new Locality{LocalityId = new Guid("d6f59eb9-7c32-57fe-574f-5256d54de3bc"), LocalityName = "EL VALLE", RegionId = regionidhatomayor, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("f170090f-f357-7db4-98da-5256d57ce190"), LocalityName = "ELUPINA CORDERO DE LAS CAÑITAS (DM)", RegionId = regionidhatomayor, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("3b63b040-9993-77e6-2f0b-5256d5e608bc"), LocalityName = "GUAYABO DULCE (DM)", RegionId = regionidhatomayor, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("5b9fb0dd-8db6-2bbd-e0e1-5256d53910e9"), LocalityName = "HATO MAYOR", RegionId = regionidhatomayor, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("71c3329c-8356-285f-c637-5256d5e3e9a8"), LocalityName = "MATA PALACIO (DM)", RegionId = regionidhatomayor, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("253361f5-20bc-2181-434e-5256d5899ef2"), LocalityName = "SABANA DE LA MAR", RegionId = regionidhatomayor, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("ecff568b-7242-424b-d386-5256d56b1604"), LocalityName = "YERBA BUENA (DM)", RegionId = regionidhatomayor, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            
            #endregion
            
            #region Independencia

            new Locality{LocalityId = new Guid("32ff98cb-1ce6-0379-137c-5256d5405345"), LocalityName = "BATEY 8 (DM)", RegionId = regionidindependencia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("7b5ea40b-e249-4f26-8549-5256d5902df0"), LocalityName = "BOCA DE CACHON (DM)", RegionId = regionidindependencia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("ce80c7f5-ef2f-bde5-0f85-5256d597a565"), LocalityName = "CRISTOBAL", RegionId = regionidindependencia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("91b2cc12-f17d-d571-de42-5256d53331e5"), LocalityName = "DUVERGE", RegionId = regionidindependencia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("65695291-fde6-853a-5487-5256d5af16f8"), LocalityName = "EL LIMON (DM)", RegionId = regionidindependencia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("e4773055-50f5-c7cd-5815-5256d56a067e"), LocalityName = "GUAYABAL (DM)", RegionId = regionidindependencia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("1caa16ab-ccb1-1b77-49d8-5256d5ffd9b3"), LocalityName = "JIMANI", RegionId = regionidindependencia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("6b2902d5-013d-e5ef-05ef-5256d51d702e"), LocalityName = "LA COLONIA (DM)", RegionId = regionidindependencia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("a7a7c1ca-46ea-7914-0b0b-5256d54f19b7"), LocalityName = "LA DESCUBIERTA", RegionId = regionidindependencia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("b4631f72-05ea-e3ef-2ed8-5256d5a70ebf"), LocalityName = "MELLA", RegionId = regionidindependencia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("880fcc5e-0978-820a-b32f-5256d53c0817"), LocalityName = "POSTRER RIO", RegionId = regionidindependencia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("491c5262-82bc-cd53-b091-5256d5ef6774"), LocalityName = "VENGAN A VER (DM)", RegionId = regionidindependencia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},

            #endregion

            #region La Romana
            
            new Locality{LocalityId = new Guid("2489fa65-8f75-9877-ab7b-5256d514ccdb"), LocalityName = "CUMAYASA (DM)", RegionId = regionidlaromana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("be193889-6a14-d289-95b7-5256d57e2f1a"), LocalityName = "GUAYMATE", RegionId = regionidlaromana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("e216015b-53b7-fde6-c9f5-5256d5e5b933"), LocalityName = "LA CALETA (DM)", RegionId = regionidlaromana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("ec556987-cd9c-0f31-40d2-5256d53d8f7e"), LocalityName = "LA ROMANA", RegionId = regionidlaromana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("d60359be-c0c4-eb20-b9c5-5256d53b6b50"), LocalityName = "VILLA HERMOSA", RegionId = regionidlaromana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},

            #endregion

            #region La Vega

            new Locality{LocalityId = new Guid("b1655f5b-b1f5-2928-fe56-5256d59c6e53"), LocalityName = "BUENA VISTA (DM)", RegionId = regionidlaromana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("c7c80233-39b7-be0a-9545-5256d5a2bba0"), LocalityName = "CONSTANZA", RegionId = regionidlaromana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("f41ef67b-18c4-e54b-44f9-5256d55f6c23"), LocalityName = "EL RANCHITO (DM)", RegionId = regionidlaromana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("2e42facd-c64e-df66-3fed-5256d53385f4"), LocalityName = "JARABACOA", RegionId = regionidlaromana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("3a82ff20-0829-74b4-1818-5256d5043a8b"), LocalityName = "JIMA ABAJO", RegionId = regionidlaromana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("589c9240-e1f5-36de-48ab-5256d5107c0e"), LocalityName = "LA SABINA (DM)", RegionId = regionidlaromana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("15e669ab-acf6-112b-34d5-5256d5ef5179"), LocalityName = "LA VEGA", RegionId = regionidlaromana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("ddb27502-7018-cc5e-0f87-5256d55a3106"), LocalityName = "MANABAO (DM)", RegionId = regionidlaromana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("9b6c5ed7-7881-362e-d956-5256d5dd0eb5"), LocalityName = "RINCON (DM)", RegionId = regionidlaromana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("84481089-a78d-be28-b192-5256d5ada9f9"), LocalityName = "RIO VERDE ARRIBA (DM)", RegionId = regionidlaromana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("547b7415-2546-4ef7-8969-5256d5d4e8a4"), LocalityName = "TIREO ARRIBA (DM)", RegionId = regionidlaromana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            
            #endregion

            #region María Trinidad Sánchez

            new Locality{LocalityId = new Guid("f16568f0-739e-5660-bb9f-5256d57109d8"), LocalityName = "ARROYO AL MEDIO (DM)", RegionId = regionidmariatrinidadsanchez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("9ab7f3a5-7ddf-b56b-4fa4-5256d5bc6f95"), LocalityName = "ARROYO SALADO (DM)", RegionId = regionidmariatrinidadsanchez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("13ba5b46-38d6-d1c0-d55c-5256d5e41ec8"), LocalityName = "CABRERA", RegionId = regionidmariatrinidadsanchez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("6e5ad290-e25b-5035-2d71-5256d5c34e53"), LocalityName = "EL FACTOR", RegionId = regionidmariatrinidadsanchez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("400a5f16-63c0-2577-2d20-5256d5c0ca3d"), LocalityName = "EL POZO (DM)", RegionId = regionidmariatrinidadsanchez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("b146f874-46a9-bd30-72ea-5256d51db1f5"), LocalityName = "LA ENTRADA (DM)", RegionId = regionidmariatrinidadsanchez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("db9db37c-8e55-c7d3-7a06-5256d57c00cd"), LocalityName = "LAS GORDAS (DM)", RegionId = regionidmariatrinidadsanchez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("298978ef-f476-bdb0-c562-5256d5498cf1"), LocalityName = "NAGUA", RegionId = regionidmariatrinidadsanchez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("c6f8cda7-7331-759a-6120-5256d5ea42fb"), LocalityName = "RIO SAN JUAN", RegionId = regionidmariatrinidadsanchez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            new Locality{LocalityId = new Guid("84e31b98-2c32-3b12-e161-5256d5b8a7b2"), LocalityName = "SAN JOSE DE MATANZAS (DM)", RegionId = regionidmariatrinidadsanchez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
           

            #endregion

            #region Monseñor Nouel

             new Locality{LocalityId = new Guid("1d15bea5-e115-cd93-230b-5256d5e7de7a"), LocalityName = "ARROYO TORO-MASIPEDRO (DM)", RegionId = regionidmonsenornouel, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("b698ef79-5d0c-60fc-b03f-5256d5e229f5"), LocalityName = "BONAO", RegionId = regionidmonsenornouel, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("e2de2e80-eda3-91f4-6e00-5256d5323cc4"), LocalityName = "JAYACO (DM)", RegionId = regionidmonsenornouel, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("3393b41c-9f93-a4d2-8a12-5256d57d5df7"), LocalityName = "JUAN ADRIAN (DM)", RegionId = regionidmonsenornouel, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("cd17e8f1-e864-b281-7d50-5256d51e7eeb"), LocalityName = "JUMA BEJUCAL (DM)", RegionId = regionidmonsenornouel, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("74810048-ad48-7687-4a9a-5256d53d29b2"), LocalityName = "LA SALVIA-LOS QUEMADOS (DM)", RegionId = regionidmonsenornouel, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("55ddafe8-335e-22a9-fd5a-5256d5de85f1"), LocalityName = "MAIMON", RegionId = regionidmonsenornouel, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("6c657c25-f4a1-2c64-6a01-5256d51ed17d"), LocalityName = "PIEDRA BLANCA", RegionId = regionidmonsenornouel, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("a0bdc52f-bcf2-c3f3-2d80-5256d5ef8aba"), LocalityName = "SABANA DEL PUERTO (DM)", RegionId = regionidmonsenornouel, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("822904ff-ad74-a792-2e29-5256d5326f4d"), LocalityName = "VILLA SONADOR (DM)", RegionId = regionidmonsenornouel, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                        
            #endregion

            #region Monte Plata

             new Locality{LocalityId = new Guid("93460983-0888-b8e5-a60a-5256d5bc5fb5"), LocalityName = "BAYAGUANA", RegionId = regionidmonteplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("bf8c5212-d2fb-6d38-bd6b-5256d509ac1f"), LocalityName = "BOYA-EL CENTRO (DM)", RegionId = regionidmonteplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("e8bb7710-ced3-8384-adca-5256d568f08c"), LocalityName = "CHIRINO (DM)", RegionId = regionidmonteplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("523088bb-6f43-621b-d2ad-5256d5d0177d"), LocalityName = "DON JUAN (DM)", RegionId = regionidmonteplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("7e80bc81-42ae-6c64-82a2-5256d5ef40c3"), LocalityName = "GONZALO (DM)", RegionId = regionidmonteplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("9346c98a-2759-ec11-84f9-5256d5c56ecb"), LocalityName = "LOS BOTADOS (DM)", RegionId = regionidmonteplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("358e15a6-d62b-d816-ec31-5256d516faa9"), LocalityName = "MAJAGUAL (DM)", RegionId = regionidmonteplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("a8d2eb93-a330-df16-ec42-5256d5eeac49"), LocalityName = "MONTE PLATA", RegionId = regionidmonteplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("68ee6112-bc8b-06a3-67a6-5256d5f4b45f"), LocalityName = "PERALVILLO", RegionId = regionidmonteplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("3ca01b55-89e3-b7a7-f710-5256d50717de"), LocalityName = "SABANA GRANDE DE BOYA", RegionId = regionidmonteplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("200c4ae5-a573-0513-3f12-5256d59ff089"), LocalityName = "YAMASA", RegionId = regionidmonteplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             

            #endregion

            #region Montecristi

             new Locality{LocalityId = new Guid("cc5f8f8e-2698-1d38-00c6-5256d54a55dd"), LocalityName = "CANA CHAPETON (DM)", RegionId = regionidmontecristi, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("497078b9-d2b6-40ae-61dc-5256d5bcf832"), LocalityName = "CASTAÑUELAS", RegionId = regionidmontecristi, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("71e71647-a198-c361-fe78-5256d5e7ce13"), LocalityName = "GUAYUBIN", RegionId = regionidmontecristi, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("8a399cbb-a41b-fea3-6335-5256d5e9679c"), LocalityName = "HATILLO PALMA (DM)", RegionId = regionidmontecristi, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("5fd0b8ed-c1b9-51eb-87d6-5256d559217b"), LocalityName = "LAS MATAS DE SANTA CRUZ", RegionId = regionidmontecristi, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("20172113-8155-0f2e-ca4e-5256d59efc8c"), LocalityName = "MONTECRISTI", RegionId = regionidmontecristi, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("b681a85a-8c86-941a-014f-5256d5666e8c"), LocalityName = "PALO VERDE (EL AHOGADO) (DM)", RegionId = regionidmontecristi, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("a0056591-d750-1226-376c-5256d5b463fc"), LocalityName = "PEPILLO SALCEDO", RegionId = regionidmontecristi, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("75ab22c4-7026-ec44-0f74-5256d53cb435"), LocalityName = "VILLA ELISA (DM)", RegionId = regionidmontecristi, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
             new Locality{LocalityId = new Guid("a3a12a6d-899c-1d65-86cc-5256d501f3e3"), LocalityName = "VILLA VASQUEZ", RegionId = regionidmontecristi, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},

            #endregion

            #region Pedernales

             new Locality{LocalityId = new Guid("7ab002f8-74a3-d3d0-4d57-5256d5393ed0"), LocalityName = "JOSE FRANCISCO PEÑA GOMEZ (DM)", RegionId = regionidpedernales, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("903889f0-c97c-bf50-b84c-5256d55b059f"), LocalityName = "JUANCHO (DM)", RegionId = regionidpedernales, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("4c592e22-20b6-3ff7-c175-5256d540925f"), LocalityName = "OVIEDO", RegionId = regionidpedernales, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("63e7228d-2eac-aa9c-6bc6-5256d5eaa0cf"), LocalityName = "PEDERNALES", RegionId = regionidpedernales, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},

            #endregion

            #region Peravia

              new Locality{LocalityId = new Guid("210f0440-5b7d-8cdb-582e-5256d5d74b30"), LocalityName = "BANI", RegionId = regionidperavia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("d34de88d-46b4-8f75-f8b1-5256d59b4e50"), LocalityName = "EL CARRETON (DM)", RegionId = regionidperavia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("e8d5207b-1e98-b43e-babb-5256d5f5948c"), LocalityName = "EL LIMONAL (DM)", RegionId = regionidperavia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("bc8dc411-fa0c-6aef-c685-5256d52970cc"), LocalityName = "LA CATALINA (DM)", RegionId = regionidperavia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("b80a0179-6fb5-800e-7aa1-5256d594c636"), LocalityName = "LAS BARIAS (DM)", RegionId = regionidperavia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("4d5bdeec-a31d-c8f3-18e1-5256d5bc4e38"), LocalityName = "MATANZAS (DM)", RegionId = regionidperavia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("c0d7dc0d-59cc-e5a8-b00d-5256d531218a"), LocalityName = "NIZAO", RegionId = regionidperavia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("37d3aef2-d8b7-3207-76b8-5256d5adab7f"), LocalityName = "PAYA (DM)", RegionId = regionidperavia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("946d99b7-4020-ee08-1841-5256d58668f9"), LocalityName = "PIZARRETE (DM)", RegionId = regionidperavia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("79d2ef4d-a95b-81c2-856e-5256d537b6ea"), LocalityName = "SABANA BUEY (DM)", RegionId = regionidperavia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("aa0ee9bd-6569-500c-804a-5256d516318c"), LocalityName = "SANTANA (DM)", RegionId = regionidperavia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("641d845a-da05-6075-949a-5256d522e790"), LocalityName = "VILLA FUNDACION (DM)", RegionId = regionidperavia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("a6ff6cb4-ef91-1ba3-9769-5256d57f9178"), LocalityName = "VILLA SOMBRERO (DM)", RegionId = regionidperavia, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},

            #endregion

            #region Puerto Plata
              
              new Locality{LocalityId = new Guid("391ef668-56bd-b173-eb64-5256d5e29bbd"), LocalityName = "ALTAMIRA", RegionId = regionidpuertoplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("a050b255-ff02-2880-005a-5256d519d7c4"), LocalityName = "BELLOSO (DM)", RegionId = regionidpuertoplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("b7a1dac2-436d-57bd-cd98-5256d5404633"), LocalityName = "CABARETE (DM)", RegionId = regionidpuertoplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("be237c90-260a-cc5c-a157-5256d500941d"), LocalityName = "ESTERO HONDO (DM)", RegionId = regionidpuertoplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("53b55996-076e-d750-3cdf-5256d546f184"), LocalityName = "ESTRECHO DE LUPERON OMAR BROSS (DM)", RegionId = regionidpuertoplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("3ceb5a3c-146e-2d38-0f4d-5256d5c11d59"), LocalityName = "GUALEPE", RegionId = regionidpuertoplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("277004b5-d47e-7eaa-a842-5256d5b506e3"), LocalityName = "GUANANICO", RegionId = regionidpuertoplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("22a88177-27e5-d09d-2e34-5256d57305b2"), LocalityName = "IMBERT", RegionId = regionidpuertoplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("d37a1d1d-cb97-af2a-6612-5256d5864f9e"), LocalityName = "LA ISABELA (DM)", RegionId = regionidpuertoplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("ed355055-23e1-f9a6-4d31-5256d51b228c"), LocalityName = "LA JAIBA (DM)", RegionId = regionidpuertoplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("78c3f45c-93bb-ea6d-7138-5256d55ca0c6"), LocalityName = "LOS HIDALGOS", RegionId = regionidpuertoplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("4e728e28-0b12-e62a-0100-5256d57293ae"), LocalityName = "LUPERON", RegionId = regionidpuertoplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("69369e28-56b8-c9ac-001b-5256d509ad87"), LocalityName = "MAIMON (DM)", RegionId = regionidpuertoplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("108fe876-ab30-fba5-ae9e-5256d55fe7fc"), LocalityName = "NAVAS (DM)", RegionId = regionidpuertoplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("6ca401a8-014b-c0da-f7eb-5256d5c95b8a"), LocalityName = "PUERTO PLATA", RegionId = regionidpuertoplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("ce964299-c2af-6863-fe27-5256d5c7d676"), LocalityName = "RIO GRANDE (DM)", RegionId = regionidpuertoplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("840b4e3d-ce51-f8d7-fe0b-5256d519ca56"), LocalityName = "SABANETA DE YASICA (DM)", RegionId = regionidpuertoplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("636dd6ae-3122-a59f-4dfe-5256d553860a"), LocalityName = "SOSUA", RegionId = regionidpuertoplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("8dc6dba2-9a6a-caaa-69bd-5256d528333f"), LocalityName = "VILLA ISABELA", RegionId = regionidpuertoplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("a7342ae3-d047-1645-1a52-5256d51d9834"), LocalityName = "VILLA MONTELLANO", RegionId = regionidpuertoplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("e3fbcbb8-59da-7116-f87f-5256d54395be"), LocalityName = "YASICA ARRIBA (DM)", RegionId = regionidpuertoplata, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},

            #endregion

            #region Samaná

              new Locality{LocalityId = new Guid("c5046344-f091-21dc-c90e-5256d5a177c4"), LocalityName = "ARROYO BARRIL (DM)", RegionId = regionidsamana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("af925b9f-3b9c-c2f9-092f-5256d5c37d2a"), LocalityName = "EL LIMON (DM)", RegionId = regionidsamana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("98ae6b5c-c082-c418-83ad-5256d551a3e0"), LocalityName = "LAS GALERAS (DM)", RegionId = regionidsamana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("dbf620c7-4f57-93b9-fc20-5256d593e905"), LocalityName = "LAS TERRENAS", RegionId = regionidsamana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("6c6199a6-caaa-151b-e8e6-5256d597a5da"), LocalityName = "SAMANA", RegionId = regionidsamana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("8352e3f3-e7c7-144f-3935-5256d527e66c"), LocalityName = "SANCHEZ", RegionId = regionidsamana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},

            #endregion

            #region San Cristóbal
              
              new Locality{LocalityId = new Guid("406e21a7-04af-471c-5b3a-5256d53a1f1a"), LocalityName = "BAJOS DE HAINA", RegionId = regionidsancristobal, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("1f008395-cf64-c65b-ba68-5256d572df4a"), LocalityName = "CAMBITA EL PUEBLECITO (DM)", RegionId = regionidsancristobal, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("5de504d2-5755-be74-c48c-5256d56b5136"), LocalityName = "CAMBITA GARABITOS", RegionId = regionidsancristobal, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("5aa10b97-f129-d8f3-1f34-5256d5a04f74"), LocalityName = "EL CARRIL (DM)", RegionId = regionidsancristobal, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("ae5d9920-7267-036c-b7bf-5256d52612ec"), LocalityName = "HATO DAMAS (DM)", RegionId = regionidsancristobal, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("35ff106e-7693-636d-95e8-5256d55710b1"), LocalityName = "LA CUCHILLA (DM)", RegionId = regionidsancristobal, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("74d027b8-9958-7215-a954-5256d57f6c3d"), LocalityName = "LOS CACAOS", RegionId = regionidsancristobal, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("e0b9deb3-1a9d-69f5-848e-5256d5f5cc66"), LocalityName = "MEDINA (DM)", RegionId = regionidsancristobal, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("298b1426-4508-0aaf-2b85-5256d504772b"), LocalityName = "SABANA GRANDE DE PALENQUE", RegionId = regionidsancristobal, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("950b0473-2688-72ce-6074-5256d5a6e26e"), LocalityName = "SAN CRISTOBAL", RegionId = regionidsancristobal, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("4b4752fe-0185-cf54-b6dc-5256d5ee9e45"), LocalityName = "SAN GREGORIO DE NIGUA", RegionId = regionidsancristobal, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("c771321c-30ea-e935-442b-5256d5ec6766"), LocalityName = "SAN JOSE-PINO HERRADO-EL PUERTO(DM)", RegionId = regionidsancristobal, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("f14a5a65-dbc4-61f5-a911-5256d5789822"), LocalityName = "VILLA ALTAGRACIA", RegionId = regionidsancristobal, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("140bc507-da54-ce48-1ee1-5256d5ab24f3"), LocalityName = "YAGUATE", RegionId = regionidsancristobal, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            
            #endregion

            #region San José de Ocoa
             
              new Locality{LocalityId = new Guid("edac0887-4140-0a81-c146-5256d510489a"), LocalityName = "EL NARANJAL (DM)", RegionId = regionidsanjosedeocoa, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("c159311a-c04d-ca2d-cd5a-5256d56b6390"), LocalityName = "EL PINAR (DM)", RegionId = regionidsanjosedeocoa, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("1081eb8d-7ae8-97ae-83b4-5256d52cdd41"), LocalityName = "LA CIENAGA (DM)", RegionId = regionidsanjosedeocoa, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("a1dd21ef-9564-ba11-9adb-5256d5800303"), LocalityName = "NIZAO-LAS AUYAMAS (DM)", RegionId = regionidsanjosedeocoa, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("88e25e9e-bc4a-140d-051d-5256d5e25e0d"), LocalityName = "RANCHO ARRIBA", RegionId = regionidsanjosedeocoa, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("6f86725c-e2fc-50f1-8739-5256d5a9b4db"), LocalityName = "SABANA LARGA", RegionId = regionidsanjosedeocoa, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("d84c7446-7f3a-18d0-6c2b-5256d53d9a1a"), LocalityName = "SAN JOSE DE OCOA", RegionId = regionidsanjosedeocoa, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},

            #endregion

            #region San Juan de la Maguana
              
              new Locality{LocalityId = new Guid("ce416f6c-fb67-bccb-f0cd-5256d50167c0"), LocalityName = "ARROYO CANO (DM)", RegionId = regionidsanjuandelamaguana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("7610fccd-596b-eefb-41f7-5256d5c99f61"), LocalityName = "BATISTA (DM)", RegionId = regionidsanjuandelamaguana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("34ea065e-3b9e-d762-8736-5256d53b21a7"), LocalityName = "BOHECHIO", RegionId = regionidsanjuandelamaguana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("4e971751-41cd-d90c-414d-5256d5802a6f"), LocalityName = "CARRERA DE YEGUAS (DM)", RegionId = regionidsanjuandelamaguana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("224c160a-0b07-6f3f-7039-5256d51fa862"), LocalityName = "DERRUMBADERO (EL NUEVO BRAZIL) (DM)", RegionId = regionidsanjuandelamaguana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("778feae6-7c15-c7bc-5d98-5256d5f70773"), LocalityName = "EL CERCADO", RegionId = regionidsanjuandelamaguana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("8b6e3db9-1d82-c259-df24-5256d51e30b4"), LocalityName = "EL ROSARIO (DM)", RegionId = regionidsanjuandelamaguana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("e413c317-b16a-8cd7-1b21-5256d5ba7379"), LocalityName = "GUANITO (DM)", RegionId = regionidsanjuandelamaguana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("49c5170b-7d27-1dfc-5edb-5256d51aaa5a"), LocalityName = "HATO DEL PADRE (DM)", RegionId = regionidsanjuandelamaguana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("a26f73e3-0d56-b7fb-1a54-5256d54edfb9"), LocalityName = "JINOVA (DM)", RegionId = regionidsanjuandelamaguana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("cebda302-203e-c62f-c64a-5256d5370b3c"), LocalityName = "JORGILLO (DM)", RegionId = regionidsanjuandelamaguana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("8ea32901-c78d-b299-761c-5256d543147f"), LocalityName = "JUAN DE HERRERA", RegionId = regionidsanjuandelamaguana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("b7b7fcbe-964c-a6b9-cd5e-5256d5ba35b7"), LocalityName = "LA JAGUA (DM)", RegionId = regionidsanjuandelamaguana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("bec201d1-b8ec-d7e2-c866-5256d5c26f82"), LocalityName = "LA ZANJA", RegionId = regionidsanjuandelamaguana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("39444e52-cf15-6e5d-0495-5256d55327d8"), LocalityName = "LAS CHARCAS DE MARIA NOVAS (DM)", RegionId = regionidsanjuandelamaguana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("5f14aea9-f5c6-5094-8e0f-5256d544d7e9"), LocalityName = "LAS MAGUANAS-HATO NUEVO (DM)", RegionId = regionidsanjuandelamaguana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("dfef2f68-c49c-2b8d-005c-5256d5369995"), LocalityName = "LAS MATAS DE FARFAN", RegionId = regionidsanjuandelamaguana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("a3d353a4-ddf3-d25c-7487-5256d50af63f"), LocalityName = "MATAYAYA (DM)", RegionId = regionidsanjuandelamaguana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("b8ea6ef0-f1bd-bd6e-528f-5256d5ffa7c2"), LocalityName = "PEDRO CORTO (DM)", RegionId = regionidsanjuandelamaguana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("34b7ee5e-7c7b-c13a-0406-5256d59392d5"), LocalityName = "SABANA ALTA (DM)", RegionId = regionidsanjuandelamaguana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("e54692e7-735c-2c74-9e31-5256d5564dc1"), LocalityName = "SABANETA (DM)", RegionId = regionidsanjuandelamaguana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("1da26662-244a-5416-d5cb-5256d5698b87"), LocalityName = "SAN JUAN DE LA MAGUANA", RegionId = regionidsanjuandelamaguana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("624a9bdc-2448-99a0-dcb3-5256d53014fe"), LocalityName = "VALLEJUELO", RegionId = regionidsanjuandelamaguana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("6783047f-34e9-4f75-7427-5256d5922611"), LocalityName = "YAQUE (BUENA VISTA) (DM)", RegionId = regionidsanjuandelamaguana, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},

            #endregion

            #region San Pedro de Macoris

              new Locality{LocalityId = new Guid("b49a9c9d-4e3d-9788-1c8f-5256d53c47ec"), LocalityName = "CONSUELO", RegionId = regionidsanpedrodemacoris, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("2f946c91-92c8-8a76-88e9-5256d5b7a533"), LocalityName = "EL PUERTO (DM)", RegionId = regionidsanpedrodemacoris, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("88435b53-ae97-2335-59d1-5256d591a2c4"), LocalityName = "GAUTIER (DM)", RegionId = regionidsanpedrodemacoris, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("72e41c43-ed20-3063-0504-5256d5ababb1"), LocalityName = "GUAYACANES", RegionId = regionidsanpedrodemacoris, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("4688bab6-f2c8-04ae-f060-5256d596c54f"), LocalityName = "LOS LLANOS", RegionId = regionidsanpedrodemacoris, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("1a743754-d8a3-38c2-02f1-5256d5a4ceaa"), LocalityName = "QUISQUEYA", RegionId = regionidsanpedrodemacoris, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("5bf3f074-a772-621e-57c7-5256d5812879"), LocalityName = "RAMON SANTANA", RegionId = regionidsanpedrodemacoris, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("9f305d2d-753f-f896-7316-5256d50976cf"), LocalityName = "SAN PEDRO DE MACORIS", RegionId = regionidsanpedrodemacoris, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},

            #endregion

            #region Sánchez Ramírez
               
              new Locality{LocalityId = new Guid("4550132a-5f22-96e0-3033-5256d5afc543"), LocalityName = "ANGELINA (DM)", RegionId = regionidsanchezramirez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("dc6d7d2f-1a0e-2d24-52c1-5256d5ae63de"), LocalityName = "CABALLERO (DM)", RegionId = regionidsanchezramirez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("cb88c4a0-b02e-521f-e9f6-5256d5784946"), LocalityName = "CEVICOS", RegionId = regionidsanchezramirez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("aa053ad7-ece2-e12e-db18-5256d5add210"), LocalityName = "COMEDERO ARRIBA (DM)", RegionId = regionidsanchezramirez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("15f80829-8594-d476-3b6b-5256d592ee69"), LocalityName = "COTUI", RegionId = regionidsanchezramirez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("77acc044-d163-a5da-fcfd-5256d5c64fd3"), LocalityName = "FANTINO", RegionId = regionidsanchezramirez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("c31c52c4-954c-81b8-a244-5256d5652f1d"), LocalityName = "HERNANDO ALONZO (DM)", RegionId = regionidsanchezramirez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("1919b8fa-7233-0824-b1cf-5256d5c80f7e"), LocalityName = "LA BIJA (DM)", RegionId = regionidsanchezramirez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("e0e6e0a6-0842-dade-86cb-5256d541dac6"), LocalityName = "LA CUEVA (DM)", RegionId = regionidsanchezramirez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("90b8e61e-fd12-609f-ca48-5256d54f8556"), LocalityName = "PLATANAL (DM)", RegionId = regionidsanchezramirez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("5e667a49-5b32-5e3e-955a-5256d5319e27"), LocalityName = "QUITA SUEÑO (DM)", RegionId = regionidsanchezramirez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("3b0b0ae0-c16e-aded-67a5-5256d5017815"), LocalityName = "VILLA LA MATA", RegionId = regionidsanchezramirez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
            
            #endregion

            #region Santiago de los Caballeros

              new Locality{LocalityId = new Guid("8a5cdcf1-74f4-f3dd-bb12-5256d5f9c947"), LocalityName = "BAITOA (DM)", RegionId = regionidsantiagodeloscaballeros, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("1dd1a398-1530-1861-4cd4-5256d552fce7"), LocalityName = "CANABACOA ABAJO (DM)", RegionId = regionidsantiagodeloscaballeros, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("4a760f83-7e4d-2778-f5ba-5256d5bd8f22"), LocalityName = "CANCA LA PIEDRA (DM)", RegionId = regionidsantiagodeloscaballeros, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("dd8f5dfe-97bf-ae31-3c13-5256d596f180"), LocalityName = "EL CAIMITO (DM)", RegionId = regionidsantiagodeloscaballeros, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("ab310cd3-e658-c65f-5274-5256d56f1a66"), LocalityName = "EL LIMON (DM)", RegionId = regionidsantiagodeloscaballeros, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("bca91157-7fbe-2dd6-93a5-5256d5a7544f"), LocalityName = "EL RUBIO (DM)", RegionId = regionidsantiagodeloscaballeros, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("920d4b46-b6a3-1f47-c7fe-5256d5907657"), LocalityName = "GUAYABAL (DM)", RegionId = regionidsantiagodeloscaballeros, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("141794b0-8e5f-d067-7f18-5256d58cf45b"), LocalityName = "HATO DEL YAQUE (DM)", RegionId = regionidsantiagodeloscaballeros, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("8465e8e0-ff20-7d7f-5ad3-5256d5f7742b"), LocalityName = "JANICO", RegionId = regionidsantiagodeloscaballeros, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("d5e03217-a863-fd47-9df6-5256d59a66ff"), LocalityName = "JUNCALITO (DM)", RegionId = regionidsantiagodeloscaballeros, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("a38bd4c7-d07e-3832-b2d7-5256d56fb5cc"), LocalityName = "LA CANELA (DM)", RegionId = regionidsantiagodeloscaballeros, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("2d4ae486-acbf-8237-35b4-5256d590635a"), LocalityName = "LAS CUESTA (DM)", RegionId = regionidsantiagodeloscaballeros, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("c4659d35-2b4c-c420-6c09-5256d541b0e0"), LocalityName = "LAS PALOMAS (DM)", RegionId = regionidsantiagodeloscaballeros, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("46719457-040d-cab7-22c1-5256d5fb64c9"), LocalityName = "LAS PLACETAS (DM)", RegionId = regionidsantiagodeloscaballeros, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("5fb1c3d2-170e-e867-6b9a-5256d56e5e08"), LocalityName = "LICEY AL MEDIO", RegionId = regionidsantiagodeloscaballeros, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("57f14f7f-1e9f-8574-6fbf-5256d554f35f"), LocalityName = "PEDRO GARCIA (DM)", RegionId = regionidsantiagodeloscaballeros, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("78d7a4f3-7a9a-5ab9-6db2-5256d5987d4e"), LocalityName = "PUÑAL", RegionId = regionidsantiagodeloscaballeros, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("711f8c57-a88d-f85f-cc99-5256d5cbe08b"), LocalityName = "SABANA IGLESIA (DM)", RegionId = regionidsantiagodeloscaballeros, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("37fb658b-af22-6a3c-9503-5256d5ee107b"), LocalityName = "SAN FRANCISCO DE JACAGUA (DM)", RegionId = regionidsantiagodeloscaballeros, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("3ec2b008-b600-66a6-8b49-5256d55e9d98"), LocalityName = "SAN JOSE DE LAS MATAS", RegionId = regionidsantiagodeloscaballeros, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("520fd181-b89e-356c-a0aa-5256d58b3204"), LocalityName = "SANTIAGO DE LOS CABALLEROS", RegionId = regionidsantiagodeloscaballeros, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("6b66a486-0e52-a2c9-bbe8-5256d5769638"), LocalityName = "TAMBORIL", RegionId = regionidsantiagodeloscaballeros, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("9dc0a52f-a792-c8fc-3878-5256d5f09846"), LocalityName = "VILLA BISONO -NAVARRETE-", RegionId = regionidsantiagodeloscaballeros, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("20e288f6-fc65-51cf-6837-5256d5301c2a"), LocalityName = "VILLA GONZALEZ", RegionId = regionidsantiagodeloscaballeros, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},

            #endregion

            #region Santiago Rodríguez
             
              new Locality{LocalityId = new Guid("40094700-7920-5f98-9b46-5256d50eaea4"), LocalityName = "BLANCO (DM)", RegionId = regionidssantiagorodriguez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("ef3070ce-320f-ed21-6f87-5256d52b6560"), LocalityName = "MONCION", RegionId = regionidssantiagorodriguez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("2ab051aa-ac4b-1ae7-3830-5256d518d6b9"), LocalityName = "MONTE LLANO (JAMAO AFUERA) (DM)", RegionId = regionidssantiagorodriguez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("14577df0-da7d-4352-6c01-5256d52364e0"), LocalityName = "SALCEDO", RegionId = regionidssantiagorodriguez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("b6c529a8-b832-09c5-40ea-5256d54538fb"), LocalityName = "SAN IGNACIO DE SABANETA", RegionId = regionidssantiagorodriguez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("56f512d4-0e48-b4c6-3099-5256d5f7d39f"), LocalityName = "TENARES", RegionId = regionidssantiagorodriguez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("d4c91481-0eff-24ce-c25c-5256d5c55059"), LocalityName = "VILLA LOS ALMACIGOS", RegionId = regionidssantiagorodriguez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("f275a4fe-f4cc-0f6c-4046-5256d5277b73"), LocalityName = "VILLA TAPIA", RegionId = regionidssantiagorodriguez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},

            #endregion

            #region Santo Domingo
              
              new Locality{LocalityId = new Guid("72e5de4f-20f7-8468-f630-5256d53354a8"), LocalityName = "BOCA CHICA", RegionId = regionidssantiagorodriguez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("52255add-a9d7-b502-b5e1-5256d51ca5c8"), LocalityName = "HATO VIEJO (DM)", RegionId = regionidssantiagorodriguez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("9d936696-f3c3-dec7-707a-5256d54b3e28"), LocalityName = "LA CALETA (DM)", RegionId = regionidssantiagorodriguez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("5be6a123-3f2c-7023-658c-5256d5331a01"), LocalityName = "LA CUABA (DM)", RegionId = regionidssantiagorodriguez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("882e36a1-ab03-5d04-2c5d-5256d562a47b"), LocalityName = "LA GUAYIGA (DM)", RegionId = regionidssantiagorodriguez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("e15242af-fd0b-9a23-cef6-5256d57c7d38"), LocalityName = "LA VICTORIA (DM)", RegionId = regionidssantiagorodriguez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("4682067d-3a04-7fcf-989e-5256d57c17d8"), LocalityName = "LOS ALCARRIZOS", RegionId = regionidssantiagorodriguez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("2f827de1-8b11-be82-36a1-5256d52a0caf"), LocalityName = "PANTOJA (DM)", RegionId = regionidssantiagorodriguez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("25c1ec8a-2cf0-3d93-f228-5256d5eda838"), LocalityName = "PEDRO BRAND", RegionId = regionidssantiagorodriguez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("6925f2cc-a4b9-0d06-cfa2-5256d5ad61ea"), LocalityName = "SAN ANTONIO DE GUERRA", RegionId = regionidssantiagorodriguez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("7e71a425-75d1-9450-780e-5256d55c67de"), LocalityName = "SAN LUIS (DM)", RegionId = regionidssantiagorodriguez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("3ce1cca9-0156-0659-2cc7-5256d5ad7ae1"), LocalityName = "SANTO DOMINGO ESTE", RegionId = regionidssantiagorodriguez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("b2daac7b-caf3-30bb-da5f-5256d57fa655"), LocalityName = "SANTO DOMINGO NORTE", RegionId = regionidssantiagorodriguez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("cbdf30ef-8acd-fbfa-1b80-5256d51335d8"), LocalityName = "SANTO DOMINGO OESTE", RegionId = regionidssantiagorodriguez, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},

            #endregion

            #region Valverde
             
              new Locality{LocalityId = new Guid("9630e123-ea44-c202-3ff8-5256d502c563"), LocalityName = "AMINA (DM)", RegionId = regionidvalverde, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("201c6981-ccf0-1a74-5e7f-5256d5e1e958"), LocalityName = "BOCA DE MAO (DM)", RegionId = regionidvalverde, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("3f21dc90-b5af-3c7f-7c28-5256d593f369"), LocalityName = "CRUCE DE GUAYACANES (DM)", RegionId = regionidvalverde, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("5686e695-6de2-9eb3-dde7-5256d51dafa3"), LocalityName = "ESPERANZA", RegionId = regionidvalverde, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("63ce0735-12e5-4452-0a3a-5256d523907f"), LocalityName = "GUATAPANAL (DM)", RegionId = regionidvalverde, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("4acdebba-603a-4c0a-2187-5256d54ce9e2"), LocalityName = "JAIBÓN (DM)", RegionId = regionidvalverde, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("146530a5-b955-f14b-4663-5256d517494c"), LocalityName = "JICOME (DM)", RegionId = regionidvalverde, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("6c760e8c-227b-1715-2668-5256d535fe5b"), LocalityName = "LA CAYA (DM)", RegionId = regionidvalverde, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("af90e61b-d21a-7891-f469-5256d55a6178"), LocalityName = "LAGUNA SALADA", RegionId = regionidvalverde, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("2d62f43b-77e1-999e-c4dd-5256d52dd8ed"), LocalityName = "MAIZAL (DM)", RegionId = regionidvalverde, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("c88f2033-e805-fe95-c4f9-5256d513af58"), LocalityName = "MAO", RegionId = regionidvalverde, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
              new Locality{LocalityId = new Guid("e1e89628-5619-057f-8fc3-5256d5eba647"), LocalityName = "PARADERO (DM)", RegionId = regionidvalverde, DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid}

            #endregion

            };

            // Adds all base regions to the context 
            localities.ForEach(loc => context.Localities.AddOrUpdate(loca => new { loca.LocalityName, loca.RegionId }, loc));

            #endregion

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }

            #region StatePowers

            var statepowers = new List<StatePower>
            {
                new StatePower{StatePowerId = new Guid("338b2c58-a3a6-301a-8bfd-5264df1f1568"), StatePowerName = "Descentralizado", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new StatePower{StatePowerId = new Guid("ca22723b-6d88-edb6-b078-524d8ec381d5"), StatePowerName = "Ejecutivo", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new StatePower{StatePowerId = new Guid("3f346e13-1a65-4898-e7e7-524d8e043ea8"), StatePowerName = "Judicial", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new StatePower{StatePowerId = new Guid("92f10c42-8408-1611-71ba-524d8eb5c9f5"), StatePowerName = "Legislativo", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new StatePower{StatePowerId = new Guid("cb8b90e4-276d-fc0e-c5c1-526002ef6341"), StatePowerName = "Municipal", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid}
            };

            statepowers.ForEach(sta => context.StatePowers.AddOrUpdate(stat => stat.StatePowerName, sta));

            #endregion

            #region Sectors

            var sectors = new List<Sector>
            {
                new Sector{SectorId = new Guid("813d0902-e5f7-74ec-44b9-524d8bce0933"), SectorName = "Agua", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Sector{SectorId = new Guid("1e3d9e1d-14d7-fb0d-6bce-524d8b7c6845"), SectorName = "Banca y Comercio", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Sector{SectorId = new Guid("9e105e97-c2df-1167-eda7-525ffdf2393c"), SectorName = "Ciencia y Tecnología", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Sector{SectorId = new Guid("b8020c76-9398-bdf2-e1af-52651f2dde0c"), SectorName = "Deporte", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Sector{SectorId = new Guid("117724ed-605b-f177-5a54-524d8bf78e6d"), SectorName = "Economía", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Sector{SectorId = new Guid("e94cc149-25d9-17ed-3e75-524d8b6faa19"), SectorName = "Educación", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Sector{SectorId = new Guid("937d18a2-0d7f-911e-23ed-525ffdbe60de"), SectorName = "Electoral", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Sector{SectorId = new Guid("282db483-34d8-bd2d-91fc-524d8b1e6b0b"), SectorName = "Gestión Pública", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Sector{SectorId = new Guid("2c7d8962-d4e0-8a90-e92f-524d8b851446"), SectorName = "Infraestructura", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Sector{SectorId = new Guid("2375ad14-2621-9ebe-4be8-524d8b675048"), SectorName = "Institucionalidad y Justicia", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Sector{SectorId = new Guid("f065f573-7a90-2ede-e850-525ffd4d5249"), SectorName = "Legislación", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Sector{SectorId = new Guid("2a5661b4-59af-ab9a-bc12-524d8b3d2bd9"), SectorName = "Medio Ambiente", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Sector{SectorId = new Guid("db38294d-5952-448d-a0c9-525ffdaa2c5a"), SectorName = "Política Exterior", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Sector{SectorId = new Guid("2eb526a3-48cc-92f6-07d8-524d8b45acae"), SectorName = "Puertos y Aeropuertos", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Sector{SectorId = new Guid("30cb46b6-c571-78b2-9d1f-524d8b3a17bb"), SectorName = "Relaciones Exteriores", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Sector{SectorId = new Guid("5a7c09ea-386f-f51c-eeb3-524d8b03481d"), SectorName = "Salud", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Sector{SectorId = new Guid("32e538a8-2ebc-722c-5532-524d8bf3194a"), SectorName = "Seguridad Social", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Sector{SectorId = new Guid("31a0fd38-1417-ac21-0cd1-525ffe680585"), SectorName = "Sociedad y Bienestar", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Sector{SectorId = new Guid("3559a551-492f-38ec-976c-524d8b2ae306"), SectorName = "Trabajo", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Sector{SectorId = new Guid("37cdcadf-3c00-a716-2dda-524d8b49bc6e"), SectorName = "Turismo", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new Sector{SectorId = new Guid("3b854762-bc86-da0c-b27a-5266414d8f6e"), SectorName = "Urbanismo", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid}
            };

            sectors.ForEach(sec => context.Sectors.AddOrUpdate(sct => sct.SectorName, sec));

            #endregion

            #region SubSectors

            var subsectors = new List<SubSector>
            {
                new SubSector{SubSectorId = new Guid("7c35a60b-b601-da94-a9f3-52cd84eb1c2f"), SubSectorName = "Acuicultura", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("cfaa3a91-5005-ab74-2146-52cd8591a675"), SubSectorName = "Agricultura", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("215d46c2-bd97-5242-434e-52cd85d5c6db"), SubSectorName = "Agua", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("49624aa4-1fc3-d06e-8fea-52cd85ea64d7"), SubSectorName = "Asistencia Social", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("7d2b7e7f-b61a-ff8f-93b3-52cd85ca9472"), SubSectorName = "Competitividad", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("beb4f786-c825-0aa7-164d-52cd852eed00"), SubSectorName = "Comunicación", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("265d48af-167e-3f39-1dc8-52cd8525dafd"), SubSectorName = "Comunidad", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("13826dd2-3e1c-806e-7f5a-52cd85199f36"), SubSectorName = "Cultura", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("10aa6706-a011-8c65-ce56-52cd854223db"), SubSectorName = "Delito", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("d4718b0d-f506-0325-ab09-52cd85e010d5"), SubSectorName = "Deporte", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("a83f60f8-0b5e-cdb5-e5d2-52cd850479d3"), SubSectorName = "Educación Superior", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("38fe6953-4789-b407-a27a-52cd85dfa2c4"), SubSectorName = "Emergencia", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("42a55ad4-106f-da5f-4fbc-52cd85ead9c8"), SubSectorName = "Energía", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("688f2abc-ad28-468e-110f-52cd8567b4cc"), SubSectorName = "Estadística", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("b0f5b9a3-c321-23a0-92d3-52cd85f3ac3f"), SubSectorName = "Finanzas", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("349ec95c-712f-da64-5e82-52cd85be67f9"), SubSectorName = "Formación", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("991477dc-2d8c-814e-eb52-52cd86228c74"), SubSectorName = "Ganadería", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("401de77d-1d30-6d14-5f99-52cd86df128d"), SubSectorName = "Industria y Comercio", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("ddae1cfc-8624-9524-80d4-52cd866a27b5"), SubSectorName = "Infraestructura", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("58932b49-d860-ddd7-b032-52cd86fde987"), SubSectorName = "Investigación", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("c38eaf9b-894a-bb1b-0b36-52cd86ade16a"), SubSectorName = "Juventud", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("797f0ff8-c545-94d8-72f5-52cd8601d3e0"), SubSectorName = "Meteorología", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("c8a3e38c-467f-4d80-3284-52cd8600c17e"), SubSectorName = "Migración", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("3efc1912-01c9-d15e-48a5-52cd866678aa"), SubSectorName = "Mujer", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("55a5de30-38eb-c4f8-de24-52cd86e4de48"), SubSectorName = "Municipios", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("2dd2ca94-61b1-e49e-783b-52cd8665914e"), SubSectorName = "Parque", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("2792a83a-ffe9-ec62-adf0-52cd86704323"), SubSectorName = "Participación Ciudadana", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("3dc7e68e-fca3-550b-10d8-52cd86e5632e"), SubSectorName = "Petróleo", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("e279bffd-2205-5db8-f6b1-52cd86250142"), SubSectorName = "Políticas Públicas", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("bd25ce8d-b7cd-a1ea-2b2b-52cd86bf6f3c"), SubSectorName = "Protección y Derechos", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("9a7f9bc0-3aed-d39f-dbc2-52cd86189b1a"), SubSectorName = "Salud", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("84a20247-afd6-395c-e6f6-52cd86741d42"), SubSectorName = "Seguridad Nacional", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("389a5e70-cf95-d87e-f21b-52cd86fc8dd4"), SubSectorName = "Seguridad Pública", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("cfb23d6a-47c3-0736-328a-52cd878a193a"), SubSectorName = "Tecnologías de la Información y la Comunicación", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("26ad04f5-761e-4eee-6c14-52cd87a62757"), SubSectorName = "Trabajo", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("e80328a0-b1c2-adeb-025f-52cd87570056"), SubSectorName = "Transparencia", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("aaf32b27-9b8e-399a-41a4-52cd879a244e"), SubSectorName = "Transporte Aéreo", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("a4416f11-d999-812f-1f98-52cd8766a18f"), SubSectorName = "Transporte Marítimo", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("db6f9d6d-9651-7aee-2b6c-52cd873638cb"), SubSectorName = "Transporte Terrestre", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new SubSector{SubSectorId = new Guid("35bae324-5f30-9783-1c26-52cd87d2f513"), SubSectorName = "Turismo", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid}
            };

            subsectors.ForEach(sub => context.SubSectors.AddOrUpdate(subs => subs.SubSectorName, sub));

            #endregion

            #region InstitutionTypes

            var institutiontypes = new List<InstitutionType>
            {
                new InstitutionType{InstitutionTypeId = new Guid("24588634-09f9-c273-851c-524d9041a498"), InstitutionTypeName = "Administradora", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("6ba4e30e-4a25-305b-de7f-524d9013efe4"), InstitutionTypeName = "Alcaldí­a", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("769117c9-9e42-b3bb-df23-524d90f137a0"), InstitutionTypeName = "Archivo­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("277c169b-0adf-29da-ee61-524d90bcf4d3"), InstitutionTypeName = "Autoridad­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("d9c92cf9-6f9e-f65c-bc96-5252d9fe0881"), InstitutionTypeName = "Ayuntamiento­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("29cfe234-dd2e-c279-c8e2-524d9019ec9e"), InstitutionTypeName = "Banco­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("870c3041-68ea-535b-2620-524d90f01779"), InstitutionTypeName = "Biblioteca­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("2c3cca83-0e73-9047-f68c-524d90dbd4a2"), InstitutionTypeName = "Caja­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("2e4cb448-e9ec-99f8-3fa2-524d90bad2d5"), InstitutionTypeName = "Cámara­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("323ac9c0-7ef3-501d-8cce-524d902e584b"), InstitutionTypeName = "Centro­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("303ef93e-8230-090a-3ea0-524d907885bd"), InstitutionTypeName = "Comedor­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("3552db72-7e92-e6d2-18b5-524d9030cda7"), InstitutionTypeName = "Comisión­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("56af6a3e-c50f-f8e2-d59d-5264f073e827"), InstitutionTypeName = "Congreso­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("39494d9e-767c-5313-f527-524d9060b236"), InstitutionTypeName = "Consejo­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("3b3861b5-466b-cdf0-e584-524d9009de6e"), InstitutionTypeName = "Consultoría­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("6f5a5b72-5888-f36e-f823-524d90406237"), InstitutionTypeName = "Contraloría­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("d1bd5b7f-76cf-63c0-5bdd-5264ef8a8df7"), InstitutionTypeName = "Corte­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("3f85bace-c692-29ac-01e3-524d909b51ab"), InstitutionTypeName = "Cuerpo­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("7d21672b-a327-2dbb-cf0c-524d90ed897f"), InstitutionTypeName = "Departamento­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("8b36b496-e604-a03c-9dd1-524d90f1faca"), InstitutionTypeName = "Despacho­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("4170f378-c701-063a-dff7-524d90451e83"), InstitutionTypeName = "Dirección­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("435b7769-b23c-cc18-5b31-524d90893ff3"), InstitutionTypeName = "Empresa­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("8f376cee-1fcb-b191-01b9-5252e40f0478"), InstitutionTypeName = "Escuela­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("736a6bb3-33a7-16ca-8f5d-524d90033b10"), InstitutionTypeName = "Federación­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("4542e13c-f92c-e3e4-9063-524d90bb3d69"), InstitutionTypeName = "Fondo­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("4737240b-8cdd-95d2-ab00-524d90d48a6a"), InstitutionTypeName = "Gabinete­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("2a41f3ad-3f39-fae7-d32b-5321ed84a0a0"), InstitutionTypeName = "Gobernación­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("4a607535-cf09-0d65-9efe-524d906e26db"), InstitutionTypeName = "Hospital­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("4de68fc0-aa11-0d68-d191-524d90664faa"), InstitutionTypeName = "Instituto­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("4feeab75-f112-cfe7-dc1d-524d9037ab8b"), InstitutionTypeName = "Junta­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("cdf7cdfc-0300-dbee-0115-53273c428d25"), InstitutionTypeName = "Juzgado­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("7cc85f76-db10-d0ed-d39a-526a27070533"), InstitutionTypeName = "Liga­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("8078a692-5284-ea51-98f4-524d9011f1b7"), InstitutionTypeName = "Loterí­a­", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("529654b6-29b5-7198-3f88-524d905a55ec"), InstitutionTypeName = "Ministerio", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("5499f480-33e7-fbff-b879-524d90145caa"), InstitutionTypeName = "Museo", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("844be5aa-0373-5005-1ab7-524d9052be47"), InstitutionTypeName = "Oficina", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("5a476ca4-a5e5-2824-5516-524d90d4d957"), InstitutionTypeName = "Organismo Regulador", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("5750ccc1-5446-9a40-ff56-524d9078bf25"), InstitutionTypeName = "Organismos Especiales", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("5c687802-f188-ac98-38ce-524d906f8aa1"), InstitutionTypeName = "Policía", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("c1aa4116-d2de-a825-f3e0-5264eebe5692"), InstitutionTypeName = "Presidencia", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("5e935cd6-d708-283c-c79c-524d90a27a31"), InstitutionTypeName = "Procuradurí­a", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("62b8fed2-5b3c-9f2b-1154-524d909980b7"), InstitutionTypeName = "Programa", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("64b91f2b-7a66-4864-f7c8-524d90a8ad2a"), InstitutionTypeName = "Seguro", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("79f27081-a43d-f964-8177-524d90ecf607"), InstitutionTypeName = "Superintendencia", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("6769f73e-0895-505e-241e-524d90619022"), InstitutionTypeName = "Tesorería", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("cb99d0d3-464d-0921-8fdd-53276ddb27d8"), InstitutionTypeName = "Tribunal", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("6988b1c8-d6a5-5d86-c186-524d903aee22"), InstitutionTypeName = "Unidad", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid},
                new InstitutionType{InstitutionTypeId = new Guid("73c26147-b077-bdf9-6cfc-5267a71cb05a"), InstitutionTypeName = "Universidad", DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid}
            };

            institutiontypes.ForEach(it => context.InstitutionTypes.AddOrUpdate(itype => itype.InstitutionTypeName, it));

            #endregion

            #region Institutions

            var institutions = new List<Institution>
            {
                new Institution{InstitutionId = new Guid("24e24d06-e396-ba7d-c7d0-524f1db02609"), InstitutionName = "Acuario Nacional", InstitutionMission = "Ofrecer una visión general de la biodiversidad costera y marina, promoviendo su conocimiento a través de exhibiciones, actividades educativas y estudios científicos como medio de divulgación para fomentar y promover su conservación y protección", InstitutionLegalBasis = "- Decreto Núm. 245-90, de 22 de julio del 1990, Gaceta Oficial Núm. 9785, que crea el Patronato del Acuario Nacional. Decreto Núm. 385, del 1 de octubre de 1990, Gaceta Oficial Núm. 9793, que integra el Centro de Investigación de Biología Marina (CIBIMA), como miembro ex-oficio del  Patronato del Acuario Nacional. - Decreto Núm. 515, del 19 de diciembre de 1990, Gaceta Oficial Núm. 9798, que integra al Museo Nacional de Historia Natural al Patronato del Acuario Nacional. - Ley Núm. 64-00, del 18 de agosto de 2000, Gaceta Oficial Núm. 10056, que crea la Secretaría de Estado de Medio Ambiente y Recursos Naturales y adscribe a ésta el Acuario Nacional. - Decreto Núm. 166-01, del 31 de enero de 2001, Gaceta Oficial Núm. 10071, que conforma el Consejo Directivo del Acuario Nacional", IsInstitutionDescentralized = true, StatePowerId = new Guid("ca22723b-6d88-edb6-b078-524d8ec381d5"), InstitutionTypeId = new Guid("5499f480-33e7-fbff-b879-524d90145caa"), SectorId = new Guid("31a0fd38-1417-ac21-0cd1-525ffe680585"), SubSectorId = new Guid("2dd2ca94-61b1-e49e-783b-52cd8665914e"), IsInstitutionDisabled = false , DateEntered = dateentered, DateModified = DateTime.Now, CreatedByUserId = createdbyuserid, ModifiedByUserId = modifiedbyuserid, InstitutionAddress = "Av. España No. 75, San Souci", LocalityId = new Guid("3ce1cca9-0156-0659-2cc7-5256d5ad7ae1"), InstitutionPhone = "(809) 766-1709", InstitutionFax = "(809) 766-1629", InstitutionEmailAddress = "info@acuarionacional.gob.do", InstitutionUrl = "http://www.acuarionacional.gob.do", ShouldInstitutionHaveEthicsCommittee = true, ShouldInstitutionHaveOAI = true, AssignedToUserId = createdbyuserid}
            };

            institutions.ForEach(inst => context.Institutions.AddOrUpdate(insts => insts.InstitutionName, inst));

            #endregion

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }

        }
    }
}
