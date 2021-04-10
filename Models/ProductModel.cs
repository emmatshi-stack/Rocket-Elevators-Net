using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using buildingapi.Model;
namespace rocket_elevator_ui.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        public List<Batteries> Batteries { get; set; } = new List<Batteries>();
        public List<Buildings> Buildings { get; set; } = new List<Buildings>();
        public List<Columns> Columns { get; set; } = new List<Columns>();

        public List<Customers> Customers { get; set; } = new List<Customers>();

        public List<Elevators> Elevators { get; set; } = new List<Elevators>();
    }
}