using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateChecking.Models
{
    public class Property
    {
        [Required]
        public string Address { get; set; }
        [Required]
        public string AgencyCode { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(-90, 90)]
        public decimal Latitude { get; set; }
        [Required]
        [Range(-180, 180)]
        public decimal Longitude { get; set; }
    }
}
