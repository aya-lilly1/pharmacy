using AutoMapper;
using pharmacy_dbmodel.Models;
using pharmacy_DbModel.Data;
using pharmacy_modelview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_core.Manager.Order
{
    public class Order :IOrder
    {
        private ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public Order(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public TempOrderMV OrderDurgTEMP(string userId,TempOrderMV orderMV)
        {

            
            var res = _mapper.Map<TempOrder>( orderMV);
            res.UserId = userId;
            _dbContext.TempOrders.Add(res);
            _dbContext.SaveChanges();
            return orderMV;
        }
        public List<TempOrderMV> GetAllOrderTEMP(string userId)
        {
            var allOrder = _dbContext.TempOrders.Where(x => x.UserId == userId).ToList();
            var res = _mapper.Map<List<TempOrderMV>>(allOrder);
            return res;
        }

        public TempOrderMV UpdateOrderDurgTEMP( TempOrderMV orderMV)
        {
            var durg =_dbContext.TempOrders.Find(orderMV.Id);
            var res= _mapper.Map(orderMV, durg);
            _dbContext.SaveChanges();
         //   var result =_mapper.Map<TempOrderMV>(res);
            return orderMV;
        }


    }
}
