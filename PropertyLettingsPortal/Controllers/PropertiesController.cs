using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly IEmailService _email;
        private readonly ILogger<PropertiesController> _logger;

        public PropertiesController(ILogger<PropertiesController> logger, IPropertyService properties, IEmailService email)
        {
            _logger = logger;
            _properties = properties;
            _email = email;
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

            // Transposes data from model to view model
            PropertyDetailsViewModel propertyDetailModel = new PropertyDetailsViewModel
            {
                Id = property.Id,
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

        [HttpPost]
        [Authorize]
        public IActionResult Details(string message, string managerName, string managerEmail, string address)
        {
            ClaimsPrincipal currentUser = User;
            string currentUsername = string.Empty;
            try
            {
                currentUsername = currentUser.FindFirst(ClaimTypes.Name).Value;
            } catch(NullReferenceException ex)
            {
                currentUsername = "Unknown";
            }        

            _email.Send(currentUsername, message, address, managerName, managerEmail);
            return Redirect("/Properties");
        }
    }
}
