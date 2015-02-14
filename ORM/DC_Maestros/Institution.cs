﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ORM.DC_Maestros
{
    public class Institution
    {
        [Key]
        public Guid InstitutionId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        public string InstitutionName { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(250)]
        public string InstitutionMission { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [MaxLength(1000)]
        public string InstitutionLegalBasis { get; set; }

        [Required]
        public bool IsInstitutionDescentralized { get; set; }

        [Required]
        [ForeignKey("StatePowerId")]
        public StatePower StatePower { get; set; }

        public Guid StatePowerId { get; set; }

        [Required]
        [ForeignKey("InstitutionTypeId")]
        public InstitutionType InstitutionType { get; set; }

        public Guid InstitutionTypeId { get; set; }

        [Required]
        [ForeignKey("SectorId")]
        public Sector Sector { get; set; }

        public Guid SectorId { get; set; }

        [Required]
        [ForeignKey("SubSectorId")]
        public SubSector SubSector { get; set; }

        public Guid SubSectorId { get; set; }

        [Required]
        public bool IsInstitutionDisabled { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [MaxLength(100)]
        public string InstitutionAddress { get; set; }

        [Required]
        [ForeignKey("LocalityId")]
        public Locality Locality { get; set; }

        public Guid LocalityId { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(14)]
        public string InstitutionPhone { get; set; }

        [DataType(DataType.PhoneNumber)]
        [MaxLength(14)]
        public string InstitutionFax { get; set; }

        [DataType(DataType.Url)]
        [MaxLength(30)]
        public string InstitutionEmailAddress { get; set; }

        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        public string InstitutionUrl { get; set; }

        [Required]
        public bool ShouldInstitutionHaveEthicsCommittee { get; set; }

        [Required]
        public bool ShouldInstitutionHaveOAI { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateEntered { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateModified { get; set; }
        public Guid CreatedByUserId { get; set; }
        public Guid ModifiedByUserId { get; set; }

        [Required]
        [ForeignKey("AssignedToUserId")]
        public User User { get; set; }

        public Guid AssignedToUserId { get; set; }

        public Institution()
        {

        }

        public Institution(string institutionname, string institutionmission, string institutionlegalbasis, bool isinstitutiondescentralized, string statepowerid, string institutiontypeid, string sectorid, string subsectorid, bool isinstitutiondisabled, string institutionaddress, string localityid, string institutionphone, string institutionfax, string institutionemailaddress, string institutionurl, bool shouldinstitutionhaveethicscommittee, DateTime dateentered, DateTime datemodified, string createdbyuserid, string modifiedbyuserid, string assignedtouserid)
        {
            this.InstitutionId = Guid.NewGuid();
            this.InstitutionName = institutionname;
            this.InstitutionMission = institutionmission;
            this.InstitutionLegalBasis = institutionlegalbasis;
            this.IsInstitutionDescentralized = isinstitutiondescentralized;
            this.StatePowerId = new Guid(statepowerid);
            this.InstitutionTypeId = new Guid(institutiontypeid);
            this.SectorId = new Guid(sectorid);
            this.SubSectorId = new Guid(subsectorid);
            this.IsInstitutionDisabled = isinstitutiondisabled;
            this.InstitutionAddress = institutionaddress;
            this.LocalityId = new Guid(localityid);
            this.InstitutionPhone = institutionphone;
            this.InstitutionFax = institutionfax;
            this.InstitutionEmailAddress = institutionemailaddress;
            this.InstitutionUrl = institutionurl;
            this.ShouldInstitutionHaveEthicsCommittee = shouldinstitutionhaveethicscommittee;
            this.DateEntered = dateentered;
            this.DateModified = datemodified;
            this.CreatedByUserId = new Guid(createdbyuserid);
            this.ModifiedByUserId = new Guid(modifiedbyuserid);
            this.AssignedToUserId = new Guid(assignedtouserid);
        }

        public Institution(string id, string institutionname, string institutionmission, string institutionlegalbasis, bool isinstitutiondescentralized, string statepowerid, string institutiontypeid, string sectorid, string subsectorid, bool isinstitutiondisabled, string institutionaddress, string localityid, string institutionphone, string institutionfax, string institutionemailaddress, string institutionurl, bool shouldinstitutionhaveethicscommittee, DateTime dateentered, DateTime datemodified, string createdbyuserid, string modifiedbyuserid, string assignedtouserid)
        {
            this.InstitutionId = new Guid(id);
            this.InstitutionName = institutionname;
            this.InstitutionMission = institutionmission;
            this.InstitutionLegalBasis = institutionlegalbasis;
            this.IsInstitutionDescentralized = isinstitutiondescentralized;
            this.StatePowerId = new Guid(statepowerid);
            this.InstitutionTypeId = new Guid(institutiontypeid);
            this.SectorId = new Guid(sectorid);
            this.SubSectorId = new Guid(subsectorid);
            this.IsInstitutionDisabled = isinstitutiondisabled;
            this.InstitutionAddress = institutionaddress;
            this.LocalityId = new Guid(localityid);
            this.InstitutionPhone = institutionphone;
            this.InstitutionFax = institutionfax;
            this.InstitutionEmailAddress = institutionemailaddress;
            this.InstitutionUrl = institutionurl;
            this.ShouldInstitutionHaveEthicsCommittee = shouldinstitutionhaveethicscommittee;
            this.DateEntered = dateentered;
            this.DateModified = datemodified;
            this.CreatedByUserId = new Guid(createdbyuserid);
            this.ModifiedByUserId = new Guid(modifiedbyuserid);
            this.AssignedToUserId = new Guid(assignedtouserid);
        }
        public IEnumerable<Institution> GetAll(SIGEeLDBContext e)
        {
            return (from c in e.Institutions
                    orderby c.InstitutionName ascending
                    select c);
        }

        public Institution GetInstitutionById(SIGEeLDBContext e, string id)
        {
            var query = (from c in e.Institutions
                         where c.InstitutionId == new Guid(id)
                         select c).FirstOrDefault();

            return query;
        }

        public Institution GetInstitutionByName(SIGEeLDBContext e, string name)
        {
            var query = (from c in e.Institutions
                         where c.InstitutionName == name
                         select c).FirstOrDefault();

            return query;
        }

    }
}