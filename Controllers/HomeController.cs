   using buildingapi.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using rocket_elevator_ui.Models;
using System.Text;

namespace rocket_elevator_ui.Controllers
{
    public class HomeController : Controller
    {
        private static readonly HttpClient client = new HttpClient();
        private string url = "https://rocketapiem.herokuapp.com";
        public ActionResult Index()
        {
            return View();
        }

        private async Task<Customers> GetCustomerAsync(string path)
        {
            Customers customer = null;

            var httpClient = new HttpClient();
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var response = await httpClient.GetAsync(requestUri: path);
            Console.WriteLine(response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<List<Customers>>(result);
                customer = customers.FirstOrDefault();
            }
            return customer;
        }

        private async Task<List<Buildings>> GetBuildingsAsync(string path)
        {
            List<Buildings> buildings = null;

            var httpClient = new HttpClient();
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var response = await httpClient.GetAsync(requestUri: path);
            Console.WriteLine(response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                buildings = JsonConvert.DeserializeObject<List<Buildings>>(result);
            }
            return buildings;
        }

        [HttpGet]
        public async Task<ActionResult> GetInterventions()
        {
            InterventionModel model = new InterventionModel();
            var email = User.Identity.GetUserName();
            var path1 = $"{url}/Customers/{email}";
            var customer = await GetCustomerAsync(path1);
            if (customer != null)
            {
                var buildings = await GetBuildingsAsync($"{url}/Buildings/{customer.Id}/net");
                if (buildings != null)
                {
                    foreach (var element in buildings)
                    {
                        model.Buildings.Add(new SelectListItem { Text = element.AdmContactFullName, Value = element.Id.ToString() });
                    }
                }
            }
            return View("GetInterventions", model);
        }
        [HttpPost]
        public async Task<ActionResult> CreateInterventions(InterventionModel model)
        {

            Interventions interv = new Interventions
            {
                Reports = model.Reports,
                Author = model.Author,
                CustomerId = model.CustomerId,
                BuildingId = long.Parse(model.BuildingId),
                BatteryId = long.Parse(model.BatteryId),
                ColumnId = long.Parse(model.ColumnId),
                ElevatorId = long.Parse(model.ElevatorId)
            };
            var httpClient = new HttpClient();
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            var response = await httpClient.PostAsync($"{url}/Interventions",
                                                       new StringContent(JsonConvert.SerializeObject(interv), Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                return View("Error"); 
            }
            return View("Index");

        }
        [HttpGet()]
        public async Task<ActionResult> GetBatteries(string buildingId)
        {
            long lBuildingId = long.Parse(buildingId);
            List<Batteries> batteries = new List<Batteries>();
            List<SelectListItem> items = new List<SelectListItem>();


            var httpClient = new HttpClient();
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var response = await httpClient.GetAsync(requestUri: $"{url}/Batteries/{lBuildingId}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                batteries = JsonConvert.DeserializeObject<List<Batteries>>(result);
            }
            var model = new InterventionModel();
            if (batteries?.Count > 0)
            {
                foreach (var element in batteries)
                {
                    model.Batteries.Add(new SelectListItem { Text = element.Id.ToString(), Value = element.Id.ToString() });
                }
            }
            return PartialView("_PartialSelectBatteries", model);
        }

        [HttpGet]
        public async Task<ActionResult> GetColumns(string batteryId)
        {
            long lbatteryId = long.Parse(batteryId);
            List<Columns> columns = new List<Columns>();
            List<SelectListItem> items = new List<SelectListItem>();


            var httpClient = new HttpClient();
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var response = await httpClient.GetAsync(requestUri: $"{url}/Columns/{lbatteryId}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                columns = JsonConvert.DeserializeObject<List<Columns>>(result);
            }
            var model = new InterventionModel();
            if (columns?.Count > 0)
            {
                foreach (var element in columns)
                {
                    model.Columns.Add(new SelectListItem { Text = element.Id.ToString(), Value = element.Id.ToString() });

                }
            }
            return PartialView("_PartialSelectColumn", model);
        }

        [HttpGet]
        public async Task<ActionResult> GetElevators(string columnId)
        {
            long lcolumnId = long.Parse(columnId);
            List<Elevators> elevators = new List<Elevators>();
            List<SelectListItem> items = new List<SelectListItem>();


            var httpClient = new HttpClient();
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var response = await httpClient.GetAsync(requestUri: $"{url}/Elevators/{lcolumnId}/net");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                elevators = JsonConvert.DeserializeObject<List<Elevators>>(result);
            }
            var model = new InterventionModel();
            if (elevators?.Count > 0)
            {
                foreach (var element in elevators)
                {
                    model.Elevators.Add(new SelectListItem { Text = element.Id.ToString(), Value = element.Id.ToString() });
                }
            }
            return PartialView("_PartialSelectElevators", model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            //patate = loaddata()
            //return View("about", patate);
            return View();
        }

        public async Task<ActionResult> GetAddress(string email)
        {
            var httpClient = new HttpClient();
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            //A appeller avec la function GetAddress(string email)
            //var email = User.Identity.GetUserName();
            //var path1 = $"{url}/Customers/{email}";
            //var customer = await GetCustomerAsync(path1);
            //GetAddress(customer.AddressId)



            var response = await httpClient.GetAsync(requestUri: $"{url}/Address/net/{email}/n");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var addres = JsonConvert.DeserializeObject<List<Addresses>>(result);
            }
            var model = new ProductModel();
            //if (addres?.Count > 0)
            //{
            //    foreach (var element in addres)
            //    {
            //        model.Addresses.Add(new SelectListItem { Text = element.Id.ToString(), Value = element.Id.ToString() });
            //    }
            //}
            return View("ProductModel", model);


        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}