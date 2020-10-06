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
        private readonly IPropertyManagerService _managers;
        private readonly ILogger<PropertiesController> _logger;

        public PropertiesController(ILogger<PropertiesController> logger, IPropertyService properties, IPropertyManagerService managers)
        {
            _logger = logger;
            _properties = properties;
            _managers = managers;
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

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = _properties.GetById(id);

            if (property == null)
            {
                return NotFound();
            }

            PropertyDetailsViewModel propertyDetailModel = new PropertyDetailsViewModel
            {
                Id = property.Id,
                //Manager = _managers.GetById(property.Manager.Id),
                Manager = property.Manager,
                StreetAddress = property.StreetAddress,
                City = property.City,
                Postcode = property.Postcode,
                CostPM = property.CostPM,
                Description = property.Description,
                Available = property.Available
            };

            return View(propertyDetailModel);
    }
    }
}
