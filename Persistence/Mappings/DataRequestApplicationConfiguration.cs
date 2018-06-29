using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Mappings
{
    public class DataRequestApplicationConfiguration : IEntityTypeConfiguration<DataRequestApplication>
    {
        public void Configure(EntityTypeBuilder<DataRequestApplication> builder)
        {
            builder.Property(a => a.OrganisationLegalName).IsRequired().HasMaxLength(255);
            builder.Property(a => a.OrganisationABN).IsRequired().HasMaxLength(11);
            builder.Property(a => a.OrganisationPhysicalAddress).IsRequired().HasMaxLength(500);
            builder.Property(a => a.AuthorisedUsers).IsRequired().HasMaxLength(500);
            builder.Property(a => a.AuthorisedSignatoryName).IsRequired().HasMaxLength(255);
            builder.Property(a => a.AuthorisedSignatoryPosition).IsRequired().HasMaxLength(255);
            builder.Property(a => a.EmailAddress).IsRequired().HasMaxLength(100);

            builder.Property(a => a.NAPLAN_IsCurrentYear).IsRequired();
            builder.Property(a => a.NAPLAN_IsAllYears).IsRequired();

            builder.Property(a => a.NAPLAN_SimilarSchools_IsCurrentYear).IsRequired();
            builder.Property(a => a.NAPLAN_SimilarSchools_IsAllYears).IsRequired();

            builder.Property(a => a.NAPLAN_SimpleStudentGain_IsCurrentYear).IsRequired();
            builder.Property(a => a.NAPLAN_SimpleStudentGain_IsAllYears).IsRequired();

            builder.Property(a => a.NAPLAN_SameStartingScoreGain_IsCurrentYear).IsRequired();
            builder.Property(a => a.NAPLAN_SameStartingScoreGain_IsAllYears).IsRequired();

            builder.Property(a => a.NAPLAN_SimilarSchoolsGain_IsCurrentYear).IsRequired();
            builder.Property(a => a.NAPLAN_SimilarSchoolsGain_IsAllYears).IsRequired();

            builder.Property(a => a.SchoolAttendance_IsCurrentYear).IsRequired();
            builder.Property(a => a.SchoolAttendance_IsAllYears).IsRequired();

            builder.Property(a => a.SeniorSecondary_IsCurrentYear).IsRequired();
            builder.Property(a => a.SeniorSecondary_IsAllYears).IsRequired();

            builder.Property(a => a.VETInSchools_IsCurrentYear).IsRequired();
            builder.Property(a => a.VETInSchools_IsAllYears).IsRequired();

            builder.Property(a => a.Finance_IsCurrentYear).IsRequired();
            builder.Property(a => a.Finance_IsAllYears).IsRequired();

            builder.Property(a => a.EnrolmentsByGrade_IsCurrentYear).IsRequired();
            builder.Property(a => a.EnrolmentsByGrade_IsAllYears).IsRequired();

            builder.Property(a => a.StudentLevelDeidentified_IsCurrentYear).IsRequired();
            builder.Property(a => a.StudentLevelDeidentified_IsAllYears).IsRequired();

            builder.Property(a => a.CustomisedRequestText).HasMaxLength(500);
            builder.Property(a => a.CustomisedRequest_IsCurrentYear).IsRequired();
            builder.Property(a => a.CustomisedRequest_IsAllYears).IsRequired();

            builder.Property(a => a.DetailedDescriptionOfTheIntendedUse).IsRequired();
            builder.Property(a => a.PlannedProductsFromTheDataProvided).IsRequired();

            builder.Property(a => a.LicensePeriod).IsRequired();
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.Status).IsRequired();
            builder.Property(a => a.Version).IsRowVersion();
        }
    }
}
