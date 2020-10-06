using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PropertyLettingsPortal.Data.Models;
using PropertyLettingsPortal.Interfaces;
using PropertyLettingsPortal.Models;

namespace PropertyLettingsPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPropertyService _properties;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IPropertyService properties)
        {
            _logger = logger;
            _properties = properties;
        }

        private PropertyIndexViewModel ConvertToViewModel(IEnumerable<Property> properties)
        {
            var propertyModelList = properties.Select(property => new PropertyIndexListViewModel
            {
                Id = property.Id,
                StreetAddress = property.StreetAddress,
                City = property.City,
                Postcode = property.Postcode,
                CostPM = property.CostPM
            });

            var model = new PropertyIndexViewModel() { Properties = propertyModelList };
            return model;
        }

        public IActionResult Index()
        {
            return View(ConvertToViewModel(_properties.GetAll()));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
