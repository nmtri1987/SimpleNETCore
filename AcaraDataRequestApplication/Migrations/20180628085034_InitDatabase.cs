using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AcaraDataRequestApplication.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataRequestApplications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrganisationLegalName = table.Column<string>(maxLength: 255, nullable: false),
                    OrganisationABN = table.Column<string>(maxLength: 11, nullable: false),
                    OrganisationPhysicalAddress = table.Column<string>(maxLength: 500, nullable: false),
                    AuthorisedUsers = table.Column<string>(maxLength: 500, nullable: false),
                    AuthorisedSignatoryName = table.Column<string>(maxLength: 255, nullable: false),
                    AuthorisedSignatoryPosition = table.Column<string>(maxLength: 255, nullable: false),
                    EmailAddress = table.Column<string>(maxLength: 100, nullable: false),
                    NAPLAN_IsCurrentYear = table.Column<bool>(nullable: false),
                    NAPLAN_IsAllYears = table.Column<bool>(nullable: false),
                    NAPLAN_SimilarSchools_IsCurrentYear = table.Column<bool>(nullable: false),
                    NAPLAN_SimilarSchools_IsAllYears = table.Column<bool>(nullable: false),
                    NAPLAN_SimpleStudentGain_IsCurrentYear = table.Column<bool>(nullable: false),
                    NAPLAN_SimpleStudentGain_IsAllYears = table.Column<bool>(nullable: false),
                    NAPLAN_SameStartingScoreGain_IsCurrentYear = table.Column<bool>(nullable: false),
                    NAPLAN_SameStartingScoreGain_IsAllYears = table.Column<bool>(nullable: false),
                    NAPLAN_SimilarSchoolsGain_IsCurrentYear = table.Column<bool>(nullable: false),
                    NAPLAN_SimilarSchoolsGain_IsAllYears = table.Column<bool>(nullable: false),
                    SchoolAttendance_IsCurrentYear = table.Column<bool>(nullable: false),
                    SchoolAttendance_IsAllYears = table.Column<bool>(nullable: false),
                    SeniorSecondary_IsCurrentYear = table.Column<bool>(nullable: false),
                    SeniorSecondary_IsAllYears = table.Column<bool>(nullable: false),
                    VETInSchools_IsCurrentYear = table.Column<bool>(nullable: false),
                    VETInSchools_IsAllYears = table.Column<bool>(nullable: false),
                    Finance_IsCurrentYear = table.Column<bool>(nullable: false),
                    Finance_IsAllYears = table.Column<bool>(nullable: false),
                    EnrolmentsByGrade_IsCurrentYear = table.Column<bool>(nullable: false),
                    EnrolmentsByGrade_IsAllYears = table.Column<bool>(nullable: false),
                    StudentLevelDeidentified_IsCurrentYear = table.Column<bool>(nullable: false),
                    StudentLevelDeidentified_IsAllYears = table.Column<bool>(nullable: false),
                    CustomisedRequestText = table.Column<string>(maxLength: 500, nullable: true),
                    CustomisedRequest_IsCurrentYear = table.Column<bool>(nullable: false),
                    CustomisedRequest_IsAllYears = table.Column<bool>(nullable: false),
                    DetailedDescriptionOfTheIntendedUse = table.Column<string>(type: "text", nullable: false),
                    PlannedProductsFromTheDataProvided = table.Column<string>(nullable: false),
                    LicensePeriod = table.Column<DateTime>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2018, 6, 28, 15, 50, 34, 349, DateTimeKind.Local)),
                    Status = table.Column<int>(nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataRequestApplications", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataRequestApplications");
        }
    }
}
