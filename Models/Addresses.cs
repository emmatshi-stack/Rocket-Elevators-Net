using System;
using System.Collections.Generic;

namespace buildingapi.Model
{
    public partial class Addresses
    {
        public Addresses()
        {
            Buildings = new HashSet<Buildings>();
            Customers = new HashSet<Customers>();
        }

        public long Id { get; set; }
        public string TypeAddress { get; set; }
        public string Status { get; set; }
        public string Entity { get; set; }
        public string NumberStreet { get; set; }
        public string SuiteApt { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Notes { get; set; }
        public long? BuildingId { get; set; }
        public long? CustomerId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public virtual Buildings Building { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual ICollection<Buildings> Buildings { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
    }
}
