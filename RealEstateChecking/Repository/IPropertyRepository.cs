using System.Collections.Generic;
using RealEstateChecking.Models;

namespace RealEstateChecking.Repository
{
    public interface IPropertyRepository
    {
        List<Property> GetPropertiesByAgencyCode(string agencyCode);
    }
}