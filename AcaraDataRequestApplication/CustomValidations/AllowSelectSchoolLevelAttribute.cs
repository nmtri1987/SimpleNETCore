using AcaraDataRequestApplication.Models;
using Domain.Entities;
using Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AcaraDataRequestApplication.CustomValidations
{
    public class AllowSelectSchoolLevelAttribute : ValidationAttribute
    {
        private IUnitOfWork _unitOfWork;


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DataRequestApplicationViewModel viewModel = validationContext.ObjectInstance as DataRequestApplicationViewModel;
            if (viewModel == null)
            {
                return ValidationResult.Success;
            }

            bool isChecked = (bool)value;
            if (!isChecked)
            {
                return ValidationResult.Success;
            }

            if (viewModel.StudentLevelDeidentified_IsCurrentYear == true || viewModel.StudentLevelDeidentified_IsAllYears == true)
            {
                return new ValidationResult(GetErrorMessage());
            }

            _unitOfWork = validationContext.GetService(typeof(IUnitOfWork)) as IUnitOfWork;

            if(IsRequestedStudentDataLevelInPreviousApplication(viewModel))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage()
        {
            return $"School level data cannot be provided with student level data in this application and any previous approved and finalised application.";
        }

        private bool IsRequestedStudentDataLevelInPreviousApplication(DataRequestApplicationViewModel viewModel)
        {
            Expression<Func<DataRequestApplication, bool>> predicate = x => x.OrganisationABN.Equals(viewModel.OrganisationABN) 
                                                                && x.Id != viewModel.Id 
                                                                && x.Status == DataRequestApplicationStatus.Approved
                                                                && (x.StudentLevelDeidentified_IsCurrentYear == true || x.StudentLevelDeidentified_IsAllYears == true);

            var previousApplications = _unitOfWork.DataRequestApplicationRepository.List(predicate);
            if(previousApplications != null && previousApplications.Any())
            {
                return true;
            }

            return false;
        }
    }
}
