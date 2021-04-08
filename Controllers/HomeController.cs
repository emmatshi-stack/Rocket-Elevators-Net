using buildingapi.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace rocket_elevator_ui.Controllers
{
    public class HomeController : Controller
    {
        private static readonly HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            return View();
        }

        static async Task<Customers> GetProductAsync(string path)
        {
            Customers customer = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                customer = await response.Content.ReadAsAsync<Customers>();
            }
            return customer;
        }


        [HttpGet]
        public  ActionResult GetInterventions()
        {
            var email = User.Identity.GetUserName();
            long id=0;
            var path1 = @"https://localhost:5001/Customers/"+email;
             var customer= GetProductAsync(path1);
            id = customer.Id;
            Console.WriteLine(id);
            var path = @"https://localhost:5001/Buildings/"+id+"/net";

            Interventions Interv = new Interventions();
            return View(Interv);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}