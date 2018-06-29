using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaraDataRequestApplication.ModelBinders
{
    public class CustomDateTimeModelBinderAttribute: ModelBinderAttribute
    {
        public string DateFormat { get; set; }

        public CustomDateTimeModelBinderAttribute() : base(typeof(CustomDateTimeModelBinder))
        {
        }
    }
}
