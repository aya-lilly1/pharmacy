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
       
            var res = _order.OrderDurgTEMP(_UserId , orderMV);
            return new JsonResult("done");
        }
        [HttpPost]
        public JsonResult UpdateOrderTemp([FromBody] TempOrderMV orderMV)
        {
      
            var res = _order.UpdateOrderDurgTEMP(orderMV);
            return new JsonResult("done");
        }
        [HttpGet]
        public JsonResult GetAllOrderTEMP()
        {
           //var userId= User.Identity.GetUserId();
            var res = _order.GetAllOrderTEMP(_UserId);
            return new JsonResult(res);
        }

        [HttpPost]
        public JsonResult DeleteOrderTemp(int id)
        {
            _order.DeleteOrderTemp(id);
            return new JsonResult("done");
        }
        [HttpPost]
        public JsonResult SaveOrder()
        {
            _order.SaveOrder(_UserId);
            return new JsonResult("done");
        }

    }
}
