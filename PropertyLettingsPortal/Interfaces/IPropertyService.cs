using PropertyLettingsPortal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyLettingsPortal.Interfaces
{
    public interface IPropertyService
    {
        // Define CRUD operations for property
        IEnumerable<Property> GetAll();
        Property GetById(int? Id);
        void Add(Property newProperty);
        void UpdateProperty(Property property);
        void RemoveProperty(Property property);
        bool PropertyExists(int id);
    }
}
