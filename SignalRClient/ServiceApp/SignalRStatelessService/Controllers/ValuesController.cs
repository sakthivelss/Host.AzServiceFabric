using SignalRStatelessService.SignalR;
using System.Collections.Generic;
using System.Web.Http;

namespace SignalRStatelessService.Controllers
{
    [ServiceRequestActionFilter]
    public class ValuesController : ApiController
    {
        // GET api/values 
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5 
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values 
        public void Post([FromBody] DeviceMessage message)
        {
            var deviceID = message.DeviceID;
            Notifier notify = new Notifier();
            notify.Notify(deviceID, "from server message" );
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {

        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
        }
    }
}
