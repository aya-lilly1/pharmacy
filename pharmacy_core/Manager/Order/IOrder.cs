using pharmacy_modelview;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pharmacy_core.Manager.Order
{
    public interface IOrder
    {
        TempOrderMV  OrderDurgTEMP(string userId, TempOrderMV orderMV);
        List<TempOrderMV> GetAllOrderTEMP(string userId);
        TempOrderMV UpdateOrderDurgTEMP(TempOrderMV orderMV);
        void DeleteOrderTemp(int id);
        void SaveOrder(string userId);

    }
}
