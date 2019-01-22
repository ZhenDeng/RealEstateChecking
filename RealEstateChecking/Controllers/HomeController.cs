using System.Diagnostics;
using RealEstateChecking.Services;
using Microsoft.AspNetCore.Mvc;
using RealEstateChecking.Models;
using RealEstateChecking.Repository;
using System.Collections.Generic;

namespace RealEstateChecking.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPropertyMatch propertyMatch;
        private readonly IPropertyRepository propertyRepository;

        public HomeController(IPropertyMatch propertyMatch, IPropertyRepository propertyRepository)
        {
            this.propertyMatch = propertyMatch;
            this.propertyRepository = propertyRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Property property)
        {
            if (ModelState.IsValid)
            {
                List<Property> databaseProperty = this.propertyRepository.GetPropertiesByAgencyCode(property.AgencyCode.ToUpper());
                bool existProperty = false;
                foreach (Property p in databaseProperty)
                {
                    if (this.propertyMatch.IsMatch(property, p))
                    {
                        existProperty = true;
                        break;
                    }
                }
                if (existProperty)
                {
                    ViewBag.UserMessage = "This property is IN the database";
                }
                else
                {
                    ViewBag.UserMessage = "This property is NOT IN the database";
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
