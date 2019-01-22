using RealEstateChecking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateChecking.Repository
{
    public class PropertySeeder
    {
        public List<Property> Seed()
        {
            List<Property> properties = new List<Property>
            {
                new Property{
                    Address = "32 Sir John Young Crescent, Sydney, NSW",
                    AgencyCode = "OTBRE",
                    Name= "Super High Apartments, Sydney",
                    Latitude = -33.870419m,
                    Longitude = 151.217293m
                },
                new Property{
                    Address = "581 George St, Sydney, NSW",
                    AgencyCode = "CRE",
                    Name= "The Summit Apartments",
                    Latitude = -33.8768076m,
                    Longitude = 151.205456m
                },

                new Property{
                    Address = "455 George St, Sydney, NSW",
                    AgencyCode = "LRE",
                    Name= "Queen Victoria Building",
                    Latitude = -33.8716516m,
                    Longitude = 151.2067689m
                },
            };
            return properties;
        }
    }
}
