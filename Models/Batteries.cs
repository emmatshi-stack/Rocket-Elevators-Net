using System;
using System.Collections.Generic;

namespace buildingapi.Model
{
    public partial class Batteries
    {
        public Batteries()
        {
            Columns = new HashSet<Columns>();
            Interventions = new HashSet<Interventions>();
        }

        public long Id { get; set; }
        public string TypeBuilding { get; set; }
        public string Status { get; set; }
        public DateTime? DateCommissioning { get; set; }
        public DateTime? DateLastInspection { get; set; }
        public string CertificateOperations { get; set; }
        public string Information { get; set; }
        public string Notes { get; set; }
        public long? BuildingId { get; set; }
        public long? EmployeeId { get; set; }

        public virtual Buildings Building { get; set; }
        public virtual Employees Employee { get; set; }
        public virtual ICollection<Columns> Columns { get; set; }
        public virtual ICollection<Interventions> Interventions { get; set; }
    }
}
