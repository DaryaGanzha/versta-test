using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Versta.Services;

namespace Versta.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : Controller
    {
        private OrderService _orderService;
        public OrderController()
        {
            _orderService = new OrderService();
        }
        [Route("create")]
        [HttpPost]
        public OkResult CreateOrder([FromBody] OrderData orderData)
        {
            _orderService.CreateOrder(orderData);
            return Ok();
        }
        [Route("getAll")]
        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = _orderService.GetAllOrders();
            return Ok(orders);
        }
    }
}
