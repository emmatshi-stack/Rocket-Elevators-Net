using System;
using System.Collections.Generic;

namespace buildingapi.Model
{
    public partial class Interventions
    {
        public long Id { get; set; }
        public string StartInterv { get; set; }
        public string StopInterv { get; set; }
        public string Result { get; set; }
        public string Reports { get; set; }
        public string Status { get; set; }
        public string EmployeeId { get; set; }
        public long? Author { get; set; }
        public long? CustomerId { get; set; }
        public long? BuildingId { get; set; }
        public long? BatteryId { get; set; }
        public long? ColumnId { get; set; }
        public long? ElevatorId { get; set; }

        public virtual Employees AuthorNavigation { get; set; }
        public virtual Batteries Battery { get; set; }
        public virtual Buildings Building { get; set; }
        public virtual Columns Column { get; set; }
        public virtual Customers Customer { get; set; }
        public virtual Elevators Elevator { get; set; }
    }
}
