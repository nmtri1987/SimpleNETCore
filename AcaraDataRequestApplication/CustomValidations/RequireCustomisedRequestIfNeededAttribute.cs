using AcaraDataRequestApplication.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcaraDataRequestApplication.CustomValidations
{
    public class RequireCustomisedRequestIfNeededAttribute : ValidationAttribute, IClientModelValidator
    {
        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-requireifneeded", GetErrorMessage());
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DataRequestApplicationViewModel viewModel = validationContext.ObjectInstance as DataRequestApplicationViewModel;
            if (viewModel == null || value == null)
            {
                return ValidationResult.Success;
            }

            string customisedRequest = value.ToString();
            if ((viewModel.CustomisedRequest_IsCurrentYear || viewModel.CustomisedRequest_IsAllYears) && string.IsNullOrEmpty(customisedRequest))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage()
        {
            return $"Customised request is required.";
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
