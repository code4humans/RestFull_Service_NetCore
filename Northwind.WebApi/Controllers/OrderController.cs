using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Northwind.BusinessLogic.Interfaces;

namespace Northwind.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Order")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderLogic _logic;
        public OrderController(IOrderLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        [Route("GetPaginatedOrders/{page:int}/{rows:int}")]
        public IActionResult GetPaginatedOrders(int page, int rows)
        {            
            return Ok(_logic.GetPaginatedOrder(page, rows));
        }
        [HttpGet]
        [Route("GetOrderById/{orderId:int}")]
        public IActionResult GetOrderById(int orderId)
        {
            return Ok(_logic.GetOrderById(orderId));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var request = _logic.GetById(id);
            return Ok(_logic.Delete(request));
        }
    }
}
