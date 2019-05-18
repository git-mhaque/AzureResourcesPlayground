using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;

namespace ApiApp.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var serviceBusConnectionString = "Endpoint=sb://mh-messaging.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=zq2dnRSYcFZEG2ldDJRlhKAABXFWElTCon31dre5MmI=";
            var topicName = "mytopic";
            var topicClient = new TopicClient(serviceBusConnectionString, topicName);

            var message = new Message(Encoding.UTF8.GetBytes("hello"));
            await topicClient.SendAsync(message);

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
