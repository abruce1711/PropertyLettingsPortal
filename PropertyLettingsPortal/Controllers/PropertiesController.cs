using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PropertyLettingsPortal.Data.Models;
using PropertyLettingsPortal.Interfaces;
using PropertyLettingsPortal.Models;

namespace PropertyLettingsPortal.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly IPropertyService _properties;
        private readonly ILogger<PropertiesController> _logger;

        public PropertiesController(ILogger<PropertiesController> logger, IPropertyService properties)
        {
            _logger = logger;
            _properties = properties;
        }

        // Retrieves list of all properties and converts them to index view models for listing on home page
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
    }
}
