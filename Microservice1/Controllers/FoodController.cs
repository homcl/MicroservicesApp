using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservice1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        public Dictionary<string, string> _foodItem { get; set; }

        public FoodController()
        {
            Dictionary<string, string> foodItem = new Dictionary<string, string>()
            {
                {"fruit", "banana"},
                {"drink", "wine"},
                {"cake", "doughnut"},
                {"thai", "noodles" }
            };

            _foodItem = foodItem;
        }

        // GET: api/Food
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _foodItem.Values; // return all foods
        }

        // GET: api/Food/5
        [HttpGet("{foodTypeKey}", Name = "Get")]
        public string Get(string foodTypeKey)
        {
            return _foodItem[foodTypeKey];
        }

        
        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
         
        // POST: api/Food
        //[HttpPost("{foodTypeKey}/{foodTypeValue}", Name = "Post")]
        //[HttpPost]
        // public void Post([FromBody] string foodTypeKey, [FromBody] string foodTypeValue)
        //public void Post([FromBody] string foodTypeKey)
        //{
           // _foodItem.Add(foodTypeKey, foodTypeValue);
           //foodItem.Add("ice cream", "mint choc chip");
        //}

        // PUT: api/Food/5
        [HttpPut("{foodTypeKey}")]
        public void Put(string foodTypeKey, [FromBody] string value)
        {
            _foodItem.Add("ice cream", "mint choc chip");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
