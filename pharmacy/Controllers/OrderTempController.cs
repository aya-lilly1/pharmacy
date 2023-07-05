using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pharmacy_core.Manager.Order;
using pharmacy_modelview;

namespace pharmacy.Controllers
{
    //[Authorize]
    public class OrderTempController : BaseController
    {
        private readonly IOrder _order;
        private readonly IHttpContextAccessor __httpContextAccessor;
        public OrderTempController(IOrder order, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _order = order;
            __httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public JsonResult AddOrderTemp(TempOrderMV orderMV)
        {
            var Order = new TempOrderMV
            {
                DurgId = orderMV.DurgId,
                DurgName = orderMV.DurgName,
                Price = orderMV.Price,
                TotalPrice = orderMV.TotalPrice,
                Quantity = orderMV.Quantity,
                OrderAt = DateTime.Now
            };

            var res = _order.OrderDurgTEMP(_UserId , Order);
            return new JsonResult("done");
        }
        [HttpPost]
        public JsonResult UpdateOrderTemp(TempOrderMV orderMV)
        {
            var order = new TempOrderMV
            {
                Id = orderMV.Id,
                DurgId = orderMV.DurgId,
                DurgName = orderMV.DurgName,
                Price = orderMV.Price,
                TotalPrice = orderMV.TotalPrice,
                Quantity = orderMV.Quantity
            };
            var res = _order.UpdateOrderDurgTEMP(order);
            return new JsonResult("done");
        }
        [HttpGet]
        public JsonResult GetAllOrderTEMP()
        {
           //var userId= User.Identity.GetUserId();
            var res = _order.GetAllOrderTEMP(_UserId);
            return new JsonResult(res);
        }

    }
}
