using PropertyLettingsPortal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyLettingsPortal.Interfaces
{
    interface IPropertyManagerService
    {
        // Define CRUD operations for property manager
        IEnumerable<PropertyManager> GetAll();
        PropertyManager GetById(int? Id);
        void Add(PropertyManager newManager);
        void UpdatePropertyManager(PropertyManager manager);
        void RemovePropertyManager(PropertyManager manager);
        bool PropertyManagerExists(int id);
    }
}
