using AutoMapper;
using pharmacy_DbModel.Data;
using pharmacy_modelview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_core.Manager.Pharmacy
{
    public interface IPharmacy
    {
        (List<DurgsMV>, bool) GetAllDurgs(string name, int page, int resultCount);
    }
}
