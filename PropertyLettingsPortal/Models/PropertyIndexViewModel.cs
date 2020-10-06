using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyLettingsPortal.Models
{
    public class PropertyIndexViewModel
    {
        public IEnumerable<PropertyIndexListViewModel> Properties { get; set; }
    }
}
