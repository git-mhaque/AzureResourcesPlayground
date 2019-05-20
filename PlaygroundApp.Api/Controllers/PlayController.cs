using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlaygroundApp.Core;

namespace PlaygroundApp.Api.Controllers
{
    [Route("api/[controller]")]
    public class PlayController : Controller
    {
        private readonly INotificationService _notificationService;

        public PlayController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
                
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var message = Request.Query["msg"];    
            await _notificationService.NotifyMessage(message.ToString() ?? "Hello");
            return new [] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}