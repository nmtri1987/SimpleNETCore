using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaraDataRequestApplication.ModelBinders
{
    public class CustomDateTimeModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if(context.Metadata.ModelType == typeof(DateTime))
            {
                return new CustomDateTimeModelBinder();
            }

            return null;
        }
    }
}
