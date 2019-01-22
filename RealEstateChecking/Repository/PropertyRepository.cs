using RealEstateChecking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateChecking.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        PropertySeeder _ps;
        public PropertyRepository()
        {
            _ps = new PropertySeeder();
        }
        public List<Property> GetPropertiesByAgencyCode(string agencyCode)
        {
            return this._ps.Seed()
                .Where(o => o.AgencyCode == agencyCode)
                .ToList();
        }
    }
}
