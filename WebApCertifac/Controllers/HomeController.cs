using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApCertifac.Models;

namespace WebApCertifac.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {


            return View();
        }
        public async Task<IActionResult> IndexR(Addendas addendas)
        {
            try
            {
                List<Addendas> addendaL = new List<Addendas>();
                HttpClient client = new HttpClient();
                var data = await client.GetAsync("https://localhost:44356/api/Addendas/"+ addendas.NombreAddenda+","+addendas.Estado2);
                var Rsp = await data.Content.ReadAsStringAsync();
                addendaL = JsonConvert.DeserializeObject<List<Addendas>>(Rsp);
                ViewBag.Addendas = addendaL;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
