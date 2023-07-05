using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using pharmacy_core.Manager.Admin;
using System.IO.Packaging;

namespace pharmacy.Controllers
{
    [Route("/{controller}/{action}")]
    public class AdminController : Controller
    {
        private  IAdmin _admin;
        public AdminController(IAdmin admin) { 
            _admin = admin; 
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ImportPharmacies()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> ImportExcelFilePharmacies(IFormFile excelFile)
        {
            if (excelFile != null && excelFile.Length > 0)
            {
              await _admin.AddPharmacyExcel(excelFile);
                return Json("Excel file processed successfully.");
            }

            return Json("No file was uploaded.");
        }


        [HttpPost]
        public IActionResult ImportExcelFileDurgs(IFormFile excelFile)
        {
            if (excelFile != null && excelFile.Length > 0)
            {
                _admin.AddDurgsExcel(excelFile);
                return Json("Excel file processed successfully.");
            }

            return Json("No file was uploaded.");
        }
    }
}

