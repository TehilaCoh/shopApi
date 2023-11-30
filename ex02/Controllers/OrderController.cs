using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ex02.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _map;

        private readonly IOrderService orderServices;

        public OrderController(IOrderService _orderServices, IMapper map) {

            orderServices = _orderServices;
            _map = map;
        }
        [HttpPost]
        public async Task<ActionResult<OrderDto>> post([FromBody]OrderDto orderdto)
        {
            Order orderM = _map.Map<OrderDto, Order>(orderdto);
            Order order= await orderServices.Post(orderM);
            OrderDto orderDTO = _map.Map<Order, OrderDto>(order);

            return orderDTO;

        }
    }
}
