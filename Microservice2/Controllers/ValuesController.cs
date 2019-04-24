using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Microservice2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "hello";
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Dictionary<string, string>>> Post([FromBody] Dictionary<string, string> value)
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostAsJsonAsync("http://localhost:5001/api/food", value);
                return Ok(response.Headers.Location); 
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
