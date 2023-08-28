using AutoMapper;
using pharmacy_dbmodel.Models;
using pharmacy_modelview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_core.Mapper
{
    public class Mapping :Profile
    {
        public Mapping()
        {
            CreateMap<Durg, DurgsMV>().ReverseMap();
            CreateMap<TempOrder, TempOrderMV>().ReverseMap();
            CreateMap<Order, OrderMV>().ReverseMap();

        }
    }
}
