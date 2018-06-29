using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class DataRequestApplication
    {
        public int Id { get; set; }

        public string OrganisationLegalName { get; set; }

        public string OrganisationABN { get; set; }

        public string OrganisationPhysicalAddress { get; set; }

        public string AuthorisedUsers { get; set; }

        public string AuthorisedSignatoryName { get; set; }

        public string AuthorisedSignatoryPosition { get; set; }

        public string EmailAddress { get; set; }

        public bool NAPLAN_IsCurrentYear { get; set; }
        public bool NAPLAN_IsAllYears { get; set; }

        public bool NAPLAN_SimilarSchools_IsCurrentYear { get; set; }
        public bool NAPLAN_SimilarSchools_IsAllYears { get; set; }

        public bool NAPLAN_SimpleStudentGain_IsCurrentYear { get; set; }
        public bool NAPLAN_SimpleStudentGain_IsAllYears { get; set; }

        public bool NAPLAN_SameStartingScoreGain_IsCurrentYear { get; set; }
        public bool NAPLAN_SameStartingScoreGain_IsAllYears { get; set; }

        public bool NAPLAN_SimilarSchoolsGain_IsCurrentYear { get; set; }
        public bool NAPLAN_SimilarSchoolsGain_IsAllYears { get; set; }

        public bool SchoolAttendance_IsCurrentYear { get; set; }
        public bool SchoolAttendance_IsAllYears { get; set; }

        public bool SeniorSecondary_IsCurrentYear { get; set; }
        public bool SeniorSecondary_IsAllYears { get; set; }

        public bool VETInSchools_IsCurrentYear { get; set; }
        public bool VETInSchools_IsAllYears { get; set; }

        public bool Finance_IsCurrentYear { get; set; }
        public bool Finance_IsAllYears { get; set; }

        public bool EnrolmentsByGrade_IsCurrentYear { get; set; }
        public bool EnrolmentsByGrade_IsAllYears { get; set; }

        public bool StudentLevelDeidentified_IsCurrentYear { get; set; }
        public bool StudentLevelDeidentified_IsAllYears { get; set; }

        public string CustomisedRequestText { get; set; }
        public bool CustomisedRequest_IsCurrentYear { get; set; }
        public bool CustomisedRequest_IsAllYears { get; set; }

        public string DetailedDescriptionOfTheIntendedUse { get; set; }

        public string PlannedProductsFromTheDataProvided { get; set; }

        public DateTime LicensePeriod { get; set; }
        public DateTime CreatedDate { get; set; }
        public DataRequestApplicationStatus Status { get; set; }
        public byte[] Version { get; set; }
    }
}
