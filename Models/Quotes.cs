using System;
using System.Collections.Generic;

namespace buildingapi.Model
{
    public partial class Quotes
    {
        public long Id { get; set; }
        public int? NumberOfApartments { get; set; }
        public int? NumberOfFloors { get; set; }
        public int? NumberOfBasements { get; set; }
        public int? NumberOfCompanies { get; set; }
        public int? NumberOfCorporations { get; set; }
        public int? NumberOfParking { get; set; }
        public int? NumberOfElevators { get; set; }
        public int? MaximumOccupancy { get; set; }
        public int? BusinessHours { get; set; }
        public int? ElevatorAmount { get; set; }
        public string ProductLine { get; set; }
        public string QuotesName { get; set; }
        public string QuotesEmail { get; set; }
        public string QuotesCompanyName { get; set; }
        public string InstallFees { get; set; }
        public string TotalPrice { get; set; }
        public string UnitPrice { get; set; }
        public string BuildingType { get; set; }
        public string FinalPrice { get; set; }
    }
}
