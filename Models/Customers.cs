using System;
using System.Collections.Generic;

namespace buildingapi.Model
{
    public partial class Customers
    {
        public Customers()
        {
            Addresses = new HashSet<Addresses>();
            Buildings = new HashSet<Buildings>();
            Interventions = new HashSet<Interventions>();
            Leads = new HashSet<Leads>();
        }

        public long Id { get; set; }
        public DateTime? DateCreate { get; set; }
        public string CompanyName { get; set; }
        public string CpyContactFullName { get; set; }
        public string CpyContactPhone { get; set; }
        public string CpyContactEmail { get; set; }
        public string CpyDescription { get; set; }
        public string TechAuthorityServiceFullName { get; set; }
        public string TechAuthorityServicePhone { get; set; }
        public string TechManagerServiceEmail { get; set; }
        public long? UserId { get; set; }
        public long? AddressId { get; set; }
        public long? LeadId { get; set; }

        public virtual Addresses Address { get; set; }
        public virtual Leads Lead { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<Addresses> Addresses { get; set; }
        public virtual ICollection<Buildings> Buildings { get; set; }
        public virtual ICollection<Interventions> Interventions { get; set; }
        public virtual ICollection<Leads> Leads { get; set; }
    }
}
