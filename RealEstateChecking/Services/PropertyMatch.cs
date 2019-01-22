using GeoCoordinatePortable;
using RealEstateChecking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateChecking.Services
{
    public class PropertyMatch : IPropertyMatch
    {
        public bool IsMatch(Property agencyProperty, Property databaseProperty)
        {
            if (agencyProperty.AgencyCode.ToUpper() == "OTBRE")
            {
                bool flag = false;
                string agencyPropertyName = processString(agencyProperty.Name);

                string databasePropertyName = processString(databaseProperty.Name);

                string agencyPropertyAddress = processString(agencyProperty.Address);

                string databasePropertyAddress = processString(databaseProperty.Address);

                if (agencyPropertyName == databasePropertyName && agencyPropertyAddress == databasePropertyAddress)
                {
                    flag = true;
                }
                return flag;
            }
            else if (agencyProperty.AgencyCode.ToUpper() == "LRE")
            {
                return processCoordinators(agencyProperty.Latitude, agencyProperty.Longitude, databaseProperty.Latitude, databaseProperty.Longitude);
            }
            else if (agencyProperty.AgencyCode.ToUpper() == "CRE")
            {
                string[] agencyPropertyName = agencyProperty.Name.Split(' ');
                string[] databasePropertyName = databaseProperty.Name.Split(' ');
                bool flag = agencyPropertyName.OrderBy(a => a).SequenceEqual(databasePropertyName.OrderBy(a => a));
                return flag;
            }
            return false;
        }

        private string processString(string input)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in input)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString().ToLower();
        }

        private bool processCoordinators(decimal agencyLati, decimal agencyLongti, decimal databaseLati, decimal databaseLongti)
        {
            //decimal deviationDegree = (decimal)Math.Sqrt(Math.Pow((double)(agencyLati - databaseLati), 2) + Math.Pow((double)(agencyLongti - databaseLongti), 2));
            //decimal deviationDistance = deviationDegree * 111;
            GeoCoordinate pin1 = new GeoCoordinate((double)agencyLati, (double)agencyLongti);
            GeoCoordinate pin2 = new GeoCoordinate((double)databaseLati, (double)databaseLongti);
            double distanceBetween = pin1.GetDistanceTo(pin2);
            bool flag = false;
            if (distanceBetween <= 200)
            {
                flag = true;
            }
            return flag;
        }
    }
}
