using AcaraDataRequestApplication.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AcaraDataRequestApplication.Models
{
    public class TestViewModel
    {
        public int Id { get; set; }
        public FirstNestedViewModel FirstNested { get; set; }
    }

    public class FirstNestedViewModel
    {
        public string Name { get; set; }
        public SecondNestedViewModel SecondNested { get; set; }
    }

    public class SecondNestedViewModel
    {
        public string Code { get; set; }

        [Required]
        //[CustomDateTimeModelBinder(DateFormat = "dd/MM/yyyy")]
        [ModelBinder(typeof(CustomDateTimeModelBinder))]
        public DateTime ReleaseDate { get; set; }
    }
}
