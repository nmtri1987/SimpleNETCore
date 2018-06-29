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

namespace AcaraDataRequestApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HomeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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
                }
                else
                {
                    dataRequestApplication = _mapper.Map<DataRequestApplicationViewModel, DataRequestApplication>(viewModel);
                    _unitOfWork.DataRequestApplicationRepository.Add(dataRequestApplication);
                }

                _unitOfWork.Commit();

            }
            return View(viewModel);
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


    }
}
