using PropertyLettingsPortal.Data;
using PropertyLettingsPortal.Data.Models;
using PropertyLettingsPortal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyLettingsPortal.Services
{
    public class PropertyManagerService : IPropertyManagerService
    {
        private readonly ApplicationDbContext _context;
        public PropertyManagerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(PropertyManager newManager)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PropertyManager> GetAll()
        {
            return _context.PropertyManager;
        }

        public PropertyManager GetById(int? Id)
        {
            return GetAll().FirstOrDefault(pm => pm.Id == Id);
        }

        public bool PropertyManagerExists(int id)
        {
            throw new NotImplementedException();
        }

        public void RemovePropertyManager(PropertyManager manager)
        {
            throw new NotImplementedException();
        }

        public void UpdatePropertyManager(PropertyManager manager)
        {
            throw new NotImplementedException();
        }
    }
}
