using AcaraDataRequestApplication.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcaraDataRequestApplication.CustomValidations
{
    public class AllowSelectStudentLevelDeidentifiedAttribute : ValidationAttribute, IClientModelValidator
    {
        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-allowselectstudentleveldeidentified", GetErrorMessage());
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DataRequestApplicationViewModel viewModel = validationContext.ObjectInstance as DataRequestApplicationViewModel;
            if(viewModel == null)
            {
                return ValidationResult.Success;
            }

            bool isChecked = (bool)value;
            if(!isChecked)
            {
                return ValidationResult.Success;
            }

            if(viewModel.NAPLAN_IsCurrentYear == true || viewModel.NAPLAN_IsAllYears == true
                || viewModel.NAPLAN_SimilarSchools_IsCurrentYear == true || viewModel.NAPLAN_SimilarSchools_IsAllYears == true
                || viewModel.NAPLAN_SimpleStudentGain_IsCurrentYear == true || viewModel.NAPLAN_SimpleStudentGain_IsAllYears == true
                || viewModel.NAPLAN_SameStartingScoreGain_IsCurrentYear == true || viewModel.NAPLAN_SameStartingScoreGain_IsAllYears == true
                || viewModel.NAPLAN_SimilarSchoolsGain_IsCurrentYear == true || viewModel.NAPLAN_SimilarSchoolsGain_IsAllYears == true)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage()
        {
            return $"Student level data cannot be provided with school level data.";
        }

        private void MergeAttribute(IDictionary<string, string> source, string key, string value)
        {
            if (!source.ContainsKey(key))
            {
                source.Add(key, value);
            }
        }
    }
}
