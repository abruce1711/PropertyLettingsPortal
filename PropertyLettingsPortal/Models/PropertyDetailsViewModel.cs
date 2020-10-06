using PropertyLettingsPortal.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyLettingsPortal.Models
{
    public class PropertyDetailsViewModel
    {
        public int Id { get; set; }
        public PropertyManager Manager { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public float CostPM { get; set; }
        public string Description { get; set; }
        public DateTime Available { get; set; }
    }
}
