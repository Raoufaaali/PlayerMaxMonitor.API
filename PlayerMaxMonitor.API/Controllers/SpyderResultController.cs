using PlayerMaxMonitor.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlayerMaxMonitor.API.Controllers
{
    public class SpyderResultController : ApiController
    {
        // GET: api/SpyderResult
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", "value n" };
        }

        // GET: api/SpyderResult/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/SpyderResult
        public IHttpActionResult Post([FromBody]string value)
        {

            return Ok("entry added");
        }

        // PUT: api/SpyderResult/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SpyderResult/5
        public void Delete(int id)
        {
        }
    }
}
