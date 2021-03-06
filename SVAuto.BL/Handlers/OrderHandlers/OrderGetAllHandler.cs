﻿using Microsoft.Extensions.Logging;
using SVAuto.BL.Handlers.BaseHandlers;
using SVAuto.DAL.Repositories.SVAutoRepositories;
using SVAuto.EF.Model;

namespace SVAuto.BL.Handlers.OrderHandlers
{
    public class OrderGetAllHandler
        : BaseGetAllHandler<Order>
    {
        public OrderGetAllHandler(
            IOrderRepository orderRepository,
            ILogger<OrderGetAllHandler> logger)
            : base(orderRepository, logger)
        {

        }
    }
}
