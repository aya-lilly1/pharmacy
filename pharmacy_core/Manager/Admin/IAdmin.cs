using Microsoft.AspNetCore.Http;
using pharmacy_modelview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_core.Manager.Admin
{
    public interface IAdmin
    {
        Task AddPharmacyExcel(IFormFile excelFile);
        void AddDrugsExcel(IFormFile excelFile);
     
    }
}
