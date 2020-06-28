using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_EF_Deneme.Models;
using MVC_EF_Deneme.DB;
using Microsoft.Extensions.Configuration;

namespace MVC_EF_Deneme.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        static IConfiguration _iconfiguration;

        public HomeController(ILogger<HomeController> logger,IConfiguration iconfiguration)
        {
            _logger = logger;
            _iconfiguration = iconfiguration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult KargoGoruntule()
        {
            System.Diagnostics.Debug.WriteLine("0000000: ");
            return View(RetrieveKargo());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()

        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult KargoEkle()
        {
            System.Diagnostics.Debug.WriteLine("1111111111111111111111");
            return View();
        }

        [HttpPost]
        public IActionResult KargoEkle(KargoDetay krgDetay)
        {
            System.Diagnostics.Debug.WriteLine("Controller KargoEkle - " + krgDetay.aliciBirim);
            using (var db = new KargoContext(_iconfiguration))
            {
                db.Add(krgDetay);
                db.SaveChanges();
                Console.WriteLine("DB isert completed: " +
                                    krgDetay.kargoId + "," + 
                                    krgDetay.aliciIsim + "," + 
                                    krgDetay.gonderenIsim);
            }

            return View("KargoGoruntule", RetrieveKargo());
        }

        private static List<KargoDetay> RetrieveKargo()
        {
            List<KargoDetay> lst = null;
            using (var db = new KargoContext(_iconfiguration))
            {
                lst = db.kargolar.ToList();
            }
            return lst;
        }
    }
}
