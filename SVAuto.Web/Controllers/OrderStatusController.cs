using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SVAuto.BL.Handlers.OrderStatusHandlers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SVAuto.Web.Controllers
{
    [Route("api/[controller]")]
    public class OrderStatusController : Controller
    {
        private readonly OrderStatusGetAllHandler orderStatusGetAllHandler;
        private readonly OrderStatusGetHandler orderStatusGetHandler;
        private readonly OrderStatusAddHandler orderStatusAddHandler;
        private readonly OrderStatusRemoveHandler orderStatusRemoveHandler;
        private readonly OrderStatusUpdateHandler orderStatusUpdateHandler;

        public OrderStatusController(
            OrderStatusGetAllHandler getAllHandler,
            OrderStatusGetHandler getHandler,
            OrderStatusAddHandler addHandler,
            OrderStatusRemoveHandler removeHandler,
            OrderStatusUpdateHandler updateHandler)
        {
            orderStatusGetAllHandler = getAllHandler;
            orderStatusGetHandler = getHandler;
            orderStatusAddHandler = addHandler;
            orderStatusRemoveHandler = removeHandler;
            orderStatusUpdateHandler = updateHandler;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var result = orderStatusGetAllHandler.Execute();
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.FirstError);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = orderStatusGetHandler.Execute(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.FirstError);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
