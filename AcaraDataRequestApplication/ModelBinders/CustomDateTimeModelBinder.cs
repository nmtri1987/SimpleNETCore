using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaraDataRequestApplication.ModelBinders
{
    public class CustomDateTimeModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if(bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            if(bindingContext.ModelType != typeof(DateTime))
            {
                return Task.CompletedTask;
            }

            string modelName = GetModelName(bindingContext);
            ValueProviderResult valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
            if(valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            string dateToParse = valueProviderResult.FirstValue;
            if(string.IsNullOrEmpty(dateToParse))
            {
                return Task.CompletedTask;
            }

            DateTime dateTimeResult = ParseDate(bindingContext, dateToParse);

            if(dateTimeResult == DateTime.MinValue)
            {
                bindingContext.ModelState.TryAddModelError(modelName, $"The value '{dateToParse}' is not valid.");
                return Task.CompletedTask;
            }

            bindingContext.Result = ModelBindingResult.Success(dateTimeResult);

            return Task.CompletedTask;
        }

        private string GetModelName(ModelBindingContext bindingContext)
        {
            if(!string.IsNullOrEmpty(bindingContext.BinderModelName))
            {
                return bindingContext.BinderModelName;
            }

            return bindingContext.ModelName;
        }

        private DateTime ParseDate(ModelBindingContext bindingContext, string dateToParse)
        {
            CustomDateTimeModelBinderAttribute attribute = GetDateTimeModelBinderAttribute(bindingContext);
            string dateFormat;
            dateFormat = attribute?.DateFormat ?? "dd/MM/yyyy";

            DateTime dateResult;
            if(DateTime.TryParseExact(dateToParse, dateFormat, null, System.Globalization.DateTimeStyles.AssumeLocal, out dateResult))
            {
                return dateResult;
            }

            return DateTime.MinValue;
        }

        private CustomDateTimeModelBinderAttribute GetDateTimeModelBinderAttribute(ModelBindingContext bindingContext)
        {
            var attribute = GetDateTimeModelBinderAttributeFromActionParameter(bindingContext);
            if(attribute != null)
            {
                return attribute;
            }

            return GetDateTimeModelBinderAttributeFromProperty(bindingContext);
        }

        private CustomDateTimeModelBinderAttribute GetDateTimeModelBinderAttributeFromActionParameter(ModelBindingContext bindingContext)
        {
            string modelName = GetModelName(bindingContext);

            var paramDescriptor = bindingContext.ActionContext.ActionDescriptor.Parameters
                .Where(p => p.ParameterType == typeof(DateTime))
                .Where(p =>
                {
                    string paramModelName = p.BindingInfo?.BinderModelName ?? p.Name;
                    return paramModelName.Equals(modelName);
                })
                .FirstOrDefault();

            var ctrlParamDescriptor = paramDescriptor as ControllerParameterDescriptor;
            if (ctrlParamDescriptor == null)
            {
                return null;
            }

            var attribute = ctrlParamDescriptor.ParameterInfo
                .GetCustomAttributes(typeof(CustomDateTimeModelBinderAttribute), false)
                .FirstOrDefault();

            return (CustomDateTimeModelBinderAttribute)attribute;
        }

        private CustomDateTimeModelBinderAttribute GetDateTimeModelBinderAttributeFromProperty(ModelBindingContext bindingContext)
        {
            if(bindingContext.ModelMetadata == null || bindingContext.ModelMetadata.ContainerType == null)
            {
                return null;
            }

            string propertyName = bindingContext.ModelMetadata.PropertyName;
            if(string.IsNullOrEmpty(propertyName))
            {
                return null;
            }

            var propertyInfo = bindingContext.ModelMetadata.ContainerType.GetProperty(propertyName);
            if(propertyInfo == null)
            {
                return null;
            }

            var attribute = propertyInfo.GetCustomAttributes(typeof(CustomDateTimeModelBinderAttribute), false)
                .FirstOrDefault();

            return (CustomDateTimeModelBinderAttribute)attribute;
        }
    }
}
