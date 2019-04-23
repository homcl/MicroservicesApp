using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Microservice1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            using (var client = new HttpClient())
            {
                var jsonResponse = await client.GetStringAsync("http://localhost:5002/api/values");
                var response = JsonConvert.DeserializeObject<IEnumerable<string>>(jsonResponse);
                return Ok(response);
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            using (var client = new HttpClient())
            {
                var httpResponse = await client.GetAsync($"http://localhost:5002/api/values/{id}");
                var content = await httpResponse.Content.ReadAsStringAsync();
                return Ok(content);
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
