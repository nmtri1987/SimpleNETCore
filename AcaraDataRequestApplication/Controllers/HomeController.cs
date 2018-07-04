using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AcaraDataRequestApplication.Models;
using System.ComponentModel;
using System.Globalization;
using AcaraDataRequestApplication.ModelBinders;
using Domain.UnitOfWork;
using AutoMapper;
using Domain.Entities;
using System.Linq.Expressions;
using AcaraDataRequestApplication.Services;
using Microsoft.Extensions.Options;

namespace AcaraDataRequestApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly EmailConfiguration _emailConfiguration;

        public HomeController(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService, IOptions<EmailConfiguration> options)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
            _emailConfiguration = options.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult DataRequestApplication(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            if(id <= 0)
            {
                return View();
            }

            DataRequestApplication entity = _unitOfWork.DataRequestApplicationRepository.Get(id);
            if(entity == null)
            {
                return BadRequest();
            }

            DataRequestApplicationViewModel viewModel = _mapper.Map<DataRequestApplication, DataRequestApplicationViewModel> (entity);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DataRequestApplication(DataRequestApplicationViewModel viewModel)
        {

            if(ModelState.IsValid)
            {
                DataRequestApplication dataRequestApplication; 

                if(viewModel.Id > 0)
                {
                    dataRequestApplication = _unitOfWork.DataRequestApplicationRepository.Get(viewModel.Id);
                    dataRequestApplication = _mapper.Map<DataRequestApplicationViewModel, DataRequestApplication>(viewModel, dataRequestApplication);
                    _unitOfWork.DataRequestApplicationRepository.Update(dataRequestApplication);
                    _unitOfWork.Commit();
                }
                else
                {
                    dataRequestApplication = _mapper.Map<DataRequestApplicationViewModel, DataRequestApplication>(viewModel);
                    _unitOfWork.DataRequestApplicationRepository.Add(dataRequestApplication);
                    _unitOfWork.Commit();

                    _emailService.SendEmail(dataRequestApplication.EmailAddress, "[Acara] Notification", "Application successfully sent");
                    _emailService.SendEmail(_emailConfiguration.AdminEmailAddress, "[Acara] A new application is created", $"A new application ({dataRequestApplication.Id}) has just created.");
                }

                return RedirectToAction("DataRequestApplication", new { id = new Nullable<int>() });

            }
            return View(viewModel);
        }

        public IActionResult VerifySchoolDataLevel([ModelBinder(typeof(CustomSchoolDataLevelModelBinder))]bool isChecked, int id, string organisationABN)
        {
            if(isChecked)
            {
                if(IsRequestedStudentDataLevelInPreviousApplication(id, organisationABN))
                {
                    return Json($"School level data cannot be provided with student level data in this application and any previous approved and finalised application.");
                }

                return Json(true);
            }

            return Json(true);
        }

        public IActionResult DateOnAction()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DateOnAction([CustomDateTimeModelBinder(DateFormat = "dd/MM/yyyy", Name = "TempDate")]DateTime submittedDate)
        {
            return View(submittedDate);
        }

        public IActionResult DateOnNestedModel()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DateOnNestedModel(TestViewModel viewModel)
        {
            if(ModelState.IsValid)
            {

            }

            return View(viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }

        private bool IsRequestedStudentDataLevelInPreviousApplication(int id, string organisationABN)
        {
            if(string.IsNullOrEmpty(organisationABN))
            {
                return false;
            }

            Expression<Func<DataRequestApplication, bool>> predicate = x => x.OrganisationABN.Equals(organisationABN)
                                                                && x.Id != id
                                                                && x.Status == DataRequestApplicationStatus.Approved
                                                                && (x.StudentLevelDeidentified_IsCurrentYear == true || x.StudentLevelDeidentified_IsAllYears == true);

            var previousApplications = _unitOfWork.DataRequestApplicationRepository.List(predicate);
            if (previousApplications != null && previousApplications.Any())
            {
                return true;
            }

            return false;
        }
    }
}
