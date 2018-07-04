using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaraDataRequestApplication.ModelBinders
{
    public class CustomSchoolDataLevelModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            if (bindingContext.ModelType != typeof(bool))
            {
                return Task.CompletedTask;
            }

            ValueProviderResult valueProviderResult = GetSchoolDataLevelValue(bindingContext);
            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            string valueToParse = valueProviderResult.FirstValue;
            if (string.IsNullOrEmpty(valueToParse))
            {
                return Task.CompletedTask;
            }

            bool result;
            if(!bool.TryParse(valueToParse, out result))
            {
                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(result);

            return Task.CompletedTask;
        }

        ValueProviderResult GetSchoolDataLevelValue(ModelBindingContext bindingContext)
        {
            List<string> modelNames = new List<string>
            {
                "NAPLAN_IsCurrentYear",
                "NAPLAN_IsAllYears",
                "NAPLAN_SimilarSchools_IsCurrentYear",
                "NAPLAN_SimilarSchools_IsAllYears",
                "NAPLAN_SimpleStudentGain_IsCurrentYear",
                "NAPLAN_SimpleStudentGain_IsAllYears",
                "NAPLAN_SameStartingScoreGain_IsCurrentYear",
                "NAPLAN_SameStartingScoreGain_IsAllYears",
                "NAPLAN_SimilarSchoolsGain_IsCurrentYear",
                "NAPLAN_SimilarSchoolsGain_IsAllYears"
            };

            ValueProviderResult valueProviderResult;
            foreach (var name in modelNames)
            {
                valueProviderResult  = bindingContext.ValueProvider.GetValue(name);
                if(valueProviderResult != ValueProviderResult.None)
                {
                    break;
                }
            }

            return valueProviderResult;
        }
    }
}
