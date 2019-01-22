using RealEstateChecking.Models;

namespace RealEstateChecking.Services
{
    public interface IPropertyMatch
    {
        bool IsMatch(Property agencyProperty, Property databaseProperty);
    }
}