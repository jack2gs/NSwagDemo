using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace NSwagDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderLineController:ControllerBase
    {
        private readonly ILogger<OrderLineController> _logger;

        public OrderLineController(ILogger<OrderLineController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{orderId}")]
        public Task<IList<OrderLineContract>> GetAsync(int orderId)
        {
            _logger.LogInformation($"Order Id: {orderId}");

            return Task.FromResult((IList<OrderLineContract>)new List<OrderLineContract>()
            {
                new OrderLineContract(1, 1, 1, 10.5m, 20),
                new OrderLineContract(2, 1, 2, 5.5m, 10),
            });
        }

        [HttpPost]
        [Route("")]
        public  Task<OrderLineContract> PostAsync([FromBody]OrderLineContract orderLineContract)
        {
           var body =   new StreamReader(Request.Body).ReadToEndAsync().Result;
            _logger.LogInformation($"POST Order Line, request content: {body}");
            _logger.LogInformation($"POST Order Line: {JsonConvert.SerializeObject(orderLineContract)}");

            return Task.FromResult(orderLineContract);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<OrderLineContract> PutAsync(int id, OrderLineContract orderLineContract)
        {
            var body = new StreamReader(Request.Body).ReadToEndAsync().Result;
            _logger.LogInformation($"PUT Order Line, request content: {body}");
            _logger.LogInformation($"PUT Order Line:  {JsonConvert.SerializeObject(orderLineContract)}");

            return Task.FromResult(orderLineContract);
        }

        //[HttpPut]
        //[Route("{id}")]
        //public Task<OrderLineContract> PutAsync(int id, decimal price, int quantity, int productId)
        //{
        //    var body = new StreamReader(Request.Body).ReadToEndAsync().Result;
        //    _logger.LogInformation($"PUT Order Line, request content: {body}");
        //    _logger.LogInformation($"PUT Order Line: price={price}, quantity={quantity}, productId={productId}");

        //    return Task.FromResult(new OrderLineContract(id, 1, productId, price, quantity));
        //}
    }
}
