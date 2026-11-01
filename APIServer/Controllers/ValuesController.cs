using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;


namespace APIServer.Controllers
{
    
    public class DefaultController : ApiController
    {
        [AcceptVerbs("GET")]
        [Route("Pyng/{id}")]
        public async Task<IHttpActionResult> Ping(int id)
        {
            return Ok(new { date = DateTime.Now, data = id });
        }
    }
}
