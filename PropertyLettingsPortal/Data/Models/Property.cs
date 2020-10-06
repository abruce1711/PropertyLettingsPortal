using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PropertyLettingsPortal.Data.Models
{
    public class Property
    {
        public int Id { get; set; }
        public int ManagerId { get; set; }

        [ForeignKey("ManagerId")]
        public PropertyManager Manager { get; set; }

        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public float CostPM { get; set; }
        public string Description { get; set; }
        public DateTime Available { get; set; }
    }
}
