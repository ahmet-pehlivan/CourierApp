﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using trendyolGO.Services;

namespace trendyolGO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

    }
}
