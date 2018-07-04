using AcaraDataRequestApplication.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AcaraDataRequestApplication.CustomValidations;

namespace AcaraDataRequestApplication.Models
{
    public class DataRequestApplicationViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string OrganisationLegalName { get; set; }

        [Required]
        [StringLength(11)]
        [RegularExpression("\\d{11}")]
        public string OrganisationABN { get; set; }

        [Required]
        [StringLength(500)]
        public string OrganisationPhysicalAddress { get; set; }

        [Required]
        [StringLength(500)]
        public string AuthorisedUsers { get; set; }

        [Required]
        [StringLength(255)]
        public string AuthorisedSignatoryName { get; set; }

        [Required]
        [StringLength(255)]
        public string AuthorisedSignatoryPosition { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string EmailAddress { get; set; }

        public string AddressForServiceOfNotices
        {
            get
            {
                return string.Format($"{AuthorisedSignatoryName}, {AuthorisedSignatoryPosition}, 91 Carba Road Mount Schank");
            }
        }

        [AllowSelectSchoolLevel]
        [Remote("VerifySchoolDataLevel", "Home", AdditionalFields = nameof(Id) + "," + nameof(OrganisationABN))]
        public bool NAPLAN_IsCurrentYear { get; set; }
        [AllowSelectSchoolLevel]
        [Remote("VerifySchoolDataLevel", "Home", AdditionalFields = nameof(Id) + "," + nameof(OrganisationABN))]
        public bool NAPLAN_IsAllYears { get; set; }

        [AllowSelectSchoolLevel]
        [Remote("VerifySchoolDataLevel", "Home", AdditionalFields = nameof(Id) + "," + nameof(OrganisationABN))]
        public bool NAPLAN_SimilarSchools_IsCurrentYear { get; set; }
        [AllowSelectSchoolLevel]
        [Remote("VerifySchoolDataLevel", "Home", AdditionalFields = nameof(Id) + "," + nameof(OrganisationABN))]
        public bool NAPLAN_SimilarSchools_IsAllYears { get; set; }

        [AllowSelectSchoolLevel]
        [Remote("VerifySchoolDataLevel", "Home", AdditionalFields = nameof(Id) + "," + nameof(OrganisationABN))]
        public bool NAPLAN_SimpleStudentGain_IsCurrentYear { get; set; }
        [AllowSelectSchoolLevel]
        [Remote("VerifySchoolDataLevel", "Home", AdditionalFields = nameof(Id) + "," + nameof(OrganisationABN))]
        public bool NAPLAN_SimpleStudentGain_IsAllYears { get; set; }

        [AllowSelectSchoolLevel]
        [Remote("VerifySchoolDataLevel", "Home", AdditionalFields = nameof(Id) + "," + nameof(OrganisationABN))]
        public bool NAPLAN_SameStartingScoreGain_IsCurrentYear { get; set; }
        [AllowSelectSchoolLevel]
        [Remote("VerifySchoolDataLevel", "Home", AdditionalFields = nameof(Id) + "," + nameof(OrganisationABN))]
        public bool NAPLAN_SameStartingScoreGain_IsAllYears { get; set; }

        [AllowSelectSchoolLevel]
        [Remote("VerifySchoolDataLevel", "Home", AdditionalFields = nameof(Id) + "," + nameof(OrganisationABN))]
        public bool NAPLAN_SimilarSchoolsGain_IsCurrentYear { get; set; }
        [AllowSelectSchoolLevel]
        [Remote("VerifySchoolDataLevel", "Home", AdditionalFields = nameof(Id) + "," + nameof(OrganisationABN))]
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

        [AllowSelectStudentLevelDeidentified]
        public bool StudentLevelDeidentified_IsCurrentYear { get; set; }

        [AllowSelectStudentLevelDeidentified]
        public bool StudentLevelDeidentified_IsAllYears { get; set; }

        [RequireCustomisedRequestIfNeeded]
        [StringLength(500)]
        public string CustomisedRequestText { get; set; }
        public bool CustomisedRequest_IsCurrentYear { get; set; }
        public bool CustomisedRequest_IsAllYears { get; set; }

        [Required]
        public string DetailedDescriptionOfTheIntendedUse { get; set; }

        [Required]
        public string PlannedProductsFromTheDataProvided { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [CustomDateTimeModelBinder(DateFormat = "dd/MM/yyyy")]
        public DateTime LicensePeriod { get; set; }

        public string LicensePeriodString
        {
            get
            {
                if(LicensePeriod != DateTime.MinValue)
                {
                    return LicensePeriod.ToString("dd/MM/yyyy");
                }
                return string.Empty;
            }
        }
    }
}
