using Microsoft.Extensions.Logging;
using SVAuto.DAL.Repositories;
using SVAuto.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SVAuto.BL.Handlers.OrderHandlers
{
    public class OrderGetAllHandler : BaseHandler
    {
        private readonly IOrderRepository orderRepository;

        public OrderGetAllHandler(
            IOrderRepository orderRepository,
            ILogger<OrderGetAllHandler> logger)
            : base(logger)
        {
            this.orderRepository = orderRepository;
        }

        public HandlerResult<List<Order>> Execute()
        {
            try
            {
                logger.LogDebug("Get all orders");
                var result = orderRepository.GetAll().ToList();
                return HandlerResultFactory.GetSuccessResult(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Get all orders failed");
                return HandlerResultFactory.GetFailResult<List<Order>>(ex);
            }
        }
    }
}
