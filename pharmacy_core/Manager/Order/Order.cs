using AutoMapper;
using pharmacy_core.Helper.Enums;
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
            var existDurg = _dbContext.TempOrders.FirstOrDefault(x=> x.DurgId == orderMV.DurgId);
            var res = _mapper.Map<TempOrder>(orderMV);
            res.UserId = userId;
            if (existDurg == null) {
              
                _dbContext.TempOrders.Add(res);
            }
            else
            {
                existDurg.DurgName = res.DurgName;
                existDurg.DurgId= res.DurgId;
                existDurg.Price= res.Price;
                existDurg.Quantity +=  res.Quantity;
                existDurg.TotalPrice= res.TotalPrice;
                existDurg.OrderAt = DateTime.Now;
            }
           
         
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
        public void  DeleteOrderTemp(int id)
        {
            var durg = _dbContext.TempOrders.Find(id);
            _dbContext.TempOrders.Remove(durg);
            _dbContext.SaveChanges();

        }


        public void SaveOrder(string userId)
        {
            var order = _dbContext.TempOrders.Where(x => x.UserId == userId).ToList();
            var res = _mapper.Map< pharmacy_dbmodel.Models.Order>(order);
         
            res.Status = OrderStatus.pending.ToString();
            res.ExpiryDate=DateTime.Now;
            res.OrderAt=DateTime.Now;


            _dbContext.Orders.AddRange(res);
            _dbContext.SaveChanges();

        }





    }
}
