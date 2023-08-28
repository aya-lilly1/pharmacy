using Microsoft.AspNetCore.Mvc;
using pharmacy_core.Manager.Order;

namespace pharmacy.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IOrder _order;
        private readonly IHttpContextAccessor __httpContextAccessor;
        public OrderController(IOrder order, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _order = order;
            __httpContextAccessor = httpContextAccessor;
        }
      

    }
}
