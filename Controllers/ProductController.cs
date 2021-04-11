using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using buildingapi.Model;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using rocket_elevator_ui.Models;

namespace rocket_elevator_ui.Controllers
{
    public class ProductController : Controller
    {
        string url = "https://rocketapiem.herokuapp.com";
        // GET: Product
        public async Task<ActionResult> Index()
        {
            try
            {
                var model = await Loaddata();
                return View(model);
            } catch(Exception e)
            {
                int x = 9;
            }

            return View(new ProductModel());
           
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

       private async Task<ProductModel> Loaddata()
        {
            var model = new ProductModel { 
                Elevators = await GetElevatorsAsync($"{url}/Elevators"),
                Columns = await GetColumnsAsync($"{url}/Columns"),
                Batteries = await GetBatteriesAsync($"{url}/Batteries"),
                Buildings =await loadBuildingsAsync()
            };
            //loadBuildingsAsync();
            //loadBatteriesAsync(model);
            //loadColumnsAsync(model);
            //loadElevatorsAsync(model);
            return model;
        }

        private async void loadElevatorsAsync(ProductModel model)
        {
            var Elevators = await GetElevatorsAsync($"{url}/Elevators");
            if (Elevators != null)
            {
                foreach (var element in Elevators)
                {
                    //model.Buildings.Add(new SelectListItem { Text = element.AdmContactFullName, Value = element.Id.ToString() });
                    model.Elevators.Add(new Elevators
                    {
                        Id = element.Id,
                        ColumnId = element.ColumnId,
                        Notes = element.Notes,
                        TypeBuilding = element.TypeBuilding,
                        Status = element.Status,
                        DateCommissioning = element.DateCommissioning,
                        DateLastInspection = element.DateLastInspection
                    });
                }
            }
        }

        private async void loadColumnsAsync(ProductModel model)
        {
            var columns = await GetColumnsAsync($"{url}/Columns");
            if (columns != null)
            {
                model.Columns.AddRange(columns);
                foreach (var element in columns)
                {
                    //model.Buildings.Add(new SelectListItem { Text = element.AdmContactFullName, Value = element.Id.ToString() });
                    model.Columns.Add(new Columns
                    {
                        Id = element.Id,
                        TypeBuilding = element.TypeBuilding,
                        BatteryId = element.BatteryId,
                        Information = element.Information,
                        Status = element.Status,
                        NumberFloorsServed = element.NumberFloorsServed,
                        Notes = element.Notes
                    });
                }
            }
        }

        private async void loadBatteriesAsync(ProductModel model)
        {
            var batteries = await GetBatteriesAsync($"{url}/Batteries");
            if (batteries != null)
            {
                model.Batteries.AddRange(batteries);
                foreach (var element in batteries)
                {
                    //model.Buildings.Add(new SelectListItem { Text = element.AdmContactFullName, Value = element.Id.ToString() });
                    model.Batteries.Add(new Batteries
                    {
                        Id = element.Id,
                        BuildingId = element.BuildingId,
                        Building = element.Building,
                        Columns  = element.Columns,
                        DateCommissioning = element.DateCommissioning,
                        EmployeeId = element.EmployeeId,
                        Status = element.Status,
                        Notes = element.Notes,
                        TypeBuilding = element.TypeBuilding
                    });
                }
            }
        }


        private async Task<List<Buildings>> loadBuildingsAsync()
        {
            var email = User.Identity.GetUserName();
            var path1 = $"{url}/Customers/{email}";
            var customer = await GetCustomerAsync(path1);
            if (customer != null)
            {
                return await GetBuildingsAsync($"{url}/Buildings/{customer.Id}/net");
                //if (buildings != null)
                //{
                //    model.Buildings.AddRange(buildings);
                //    foreach (var element in buildings)
                //    {
                //        //model.Buildings.Add(new SelectListItem { Text = element.AdmContactFullName, Value = element.Id.ToString() });
                //        model.Buildings.Add(new Buildings {
                //            Id = element.Id,
                //            AddressId = element.AddressId,
                //            Address = element.Address,
                //            AdmContactEmail = element.AdmContactEmail,
                //            AdmContactFullName = element.AdmContactFullName,
                //            AdmContactPhone = element.AdmContactPhone
                //        });
                //    }
                //}
            }
            return null;

        }

        private async Task<List<Batteries>> GetBatteriesAsync(string path)
        {
            List<Batteries> batteries = null;

            var httpClient = new HttpClient();
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var response = await httpClient.GetAsync(requestUri: path);
            Console.WriteLine(response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                batteries = JsonConvert.DeserializeObject<List<Batteries>>(result);
            }
            return batteries;

        }

        private async Task<List<Elevators>> GetElevatorsAsync(string path)
        {
            List<Elevators> Elevators = null;

            var httpClient = new HttpClient();
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var response = await httpClient.GetAsync(requestUri: path);
            Console.WriteLine(response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                Elevators = JsonConvert.DeserializeObject<List<Elevators>>(result);
            }
            return Elevators;

        }

        private async Task<List<Columns>> GetColumnsAsync(string path)
        {
            List<Columns> columns = null;

            var httpClient = new HttpClient();
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            var response = await httpClient.GetAsync(requestUri: path);
            Console.WriteLine(response.StatusCode);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                columns = JsonConvert.DeserializeObject<List<Columns>>(result);
            }
            return columns;

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

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
