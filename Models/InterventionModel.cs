using buildingapi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace rocket_elevator_ui.Models
{
    public class InterventionModel
    {
        public long Id { get; set; }
       // public string Result { get; set; }
        public string Reports { get; set; }
       // public string Status { get; set; }
       // public string EmployeeId { get; set; }
        public long? Author { get; set; }
        public long? CustomerId { get; set; }
        public string BuildingId { get; set; }
        public string BatteryId { get; set; }
        public string ColumnId { get; set; }
        public string ElevatorId { get; set; }

        public List<SelectListItem> Buildings { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Batteries { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> Columns { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> Elevators { get; set; } = new List<SelectListItem>();



        //  public List<Buildings> Buildings { get; set; }
    }
}