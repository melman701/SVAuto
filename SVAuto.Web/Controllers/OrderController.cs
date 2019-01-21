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

        public OrderController(OrderGetAllHandler orderGetAllHandler)
        {
            this.orderGetAllHandler = orderGetAllHandler;
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
        public string Get(int id)
        {
            return "value";
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
