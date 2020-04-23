using PlayerMaxMonitor.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlayerMaxMonitor.API.Controllers
{
    public class EnvironmentController : ApiController
    {
        // GET api/<controller>
        //public IHttpActionResult Get()
        //{
        //    //return new string[] { "value1", "value2" };

        //    return Ok(new
        //    {
        //        FirstName = "Raouf",
        //        LastName = "Ali"
        //    });

        //    //return BadRequest("Bad request");
        //}

        // GET api/<controller>

        public IHttpActionResult Get()
        {

            return Ok(new
            {
                FirstName = "Raouf",
                LastName = "Ali"
            });
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}