using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SVAuto.BL.Handlers.OrderHandlers;
using SVAuto.EF.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SVAuto.Web.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly OrderGetAllHandler orderGetAllHandler;
        private readonly OrderAddHandler orderAddHandler;
        private readonly OrderGetHandler orderGetHandler;
        private readonly OrderRemoveHandler orderRemoveHandler;
        private readonly OrderUpdateHandler orderUpdateHandler;

        public OrderController(
            OrderGetAllHandler orderGetAllHandler,
            OrderAddHandler orderAddHandler,
            OrderGetHandler orderGetHandler,
            OrderRemoveHandler orderRemoveHandler,
            OrderUpdateHandler orderUpdateHandler)
        {
            this.orderGetAllHandler = orderGetAllHandler;
            this.orderAddHandler = orderAddHandler;
            this.orderGetHandler = orderGetHandler;
            this.orderRemoveHandler = orderRemoveHandler;
            this.orderUpdateHandler = orderUpdateHandler;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var result = orderGetAllHandler.Execute();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.FirstError.Message);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = orderGetHandler.Execute(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.FirstError.Message);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Order order)
        {
            var result = orderAddHandler.Execute(order);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.FirstError.Message);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Order order)
        {
            var result = orderUpdateHandler.Execute(order);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.FirstError.Message);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = orderRemoveHandler.Execute(id);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.FirstError.Message);
        }
    }
}
