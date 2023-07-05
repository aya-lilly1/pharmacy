using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using pharmacy_core.Manager.Pharmacy;
using pharmacy_DbModel.Data;

namespace pharmacy.Controllers
{
    [Route("/{controller}/{action}")]
    public class PharmacyController : Controller
    {
        private IPharmacy _pharmacy;
        public PharmacyController( IPharmacy pharmacy)
        {
            _pharmacy = pharmacy;
            
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult PharmacyControl()
        {
            return View();
        }
        public IActionResult ProfileAccountPartialView()
        {
          
            return PartialView("_ProfileAccount");
        }

        public IActionResult PartialViewOfPharmacyControl()
        {

            return PartialView("_PartialViewOfPharmacyControl");
        }
        public IActionResult CurrentOrderPartialView()
        {

            return PartialView("_CurrentOrder");
        }
        public IActionResult ArchivedOrderPartialView()
        {

            return PartialView("_ArchivedOrder");
        }



        public IActionResult GetAllDurgs(string term, int page)
        {
            int resultCount = 10;
            var durgs = _pharmacy.GetAllDurgs(term, page, resultCount);

            return Json(new { items = durgs.Item1, morePages = durgs.Item2 });
        }


    }
}
