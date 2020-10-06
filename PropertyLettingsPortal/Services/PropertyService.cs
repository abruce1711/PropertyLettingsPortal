using Microsoft.EntityFrameworkCore;
using PropertyLettingsPortal.Data;
using PropertyLettingsPortal.Data.Models;
using PropertyLettingsPortal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyLettingsPortal.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly ApplicationDbContext _context;
        public PropertyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Property newProperty)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Property> GetAll()
        {
            return _context.Property
                .Include(property => property.Manager);
        }

        public Property GetById(int? Id)
        {
            return GetAll().FirstOrDefault(property => property.Id == Id);
        }

        public bool PropertyExists(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveProperty(Property property)
        {
            throw new NotImplementedException();
        }

        public void UpdateProperty(Property property)
        {
            throw new NotImplementedException();
        }
    }
}
