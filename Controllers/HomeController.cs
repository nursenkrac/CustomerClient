using CustomerClient.Models;
using CustomerClient.Models.ViewModels.Outputs;
using CustomerClient.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerClient.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult SaveCustomer()
        {
            return View();

        }
        public IActionResult SearchById()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> SaveCustomer(SaveCustomer model)
        {
            if (ModelState.IsValid)
            {
                SaveCustomer saveCustomer = new SaveCustomer
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    IdentityNo = model.IdentityNo,
                    BirthDate = model.BirthDate,
                };

                ServiceOperation ou = new ServiceOperation();
                try
                {
                    var deger = ou.Create(model);
                    if (deger.data.Status == true)
                    {
                        ViewBag.StepSS = "yes";
                        return View(model);
                    }
                    else 
                    {

                        ModelState.AddModelError("", deger.message.ToString());
                        return View(model);

                    }
                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Hata Oluştu");
                    return View(model);

                }


            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SearchById(GetCustomer model)
        {
            if (ModelState.IsValid)
            {
                
                ServiceOperation ou = new ServiceOperation();
                GetByIdOutputModel m = new GetByIdOutputModel();
                try
                {
                    m = ou.GetById(model);
                    if (m != null)
                    {
                        if (m.isSuccess == true)
                        {
                            ViewBag.StepSS = "yes";
                            return View(m);
                        }

                        else
                        {

                            ModelState.AddModelError("", m.message.ToString());
                            return View(model);

                        }
                    }
                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Hata Oluştu");
                    return View(model);

                }


            }
            ModelState.AddModelError("", "Hata Oluştu");
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
