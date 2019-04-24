using System.Collections.Generic;
using System.Threading.Tasks;
using Microservice1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Microservice1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private static Dictionary<string, string> _foodItem = new Dictionary<string, string>()
        {
            {"fruit", "banana"},
            {"drink", "wine"},
            {"cake", "doughnut"},
            {"thai", "noodles" }
        };

        // GET: api/Food
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _foodItem.Values; // return all foods
        }

        // GET: api/Food/5
        [HttpGet("{foodTypeKey}", Name = "GetFood")]
        public string GetFood(string foodTypeKey)
        {
            return _foodItem[foodTypeKey];
        }

        // POST api/food
        [HttpPost]
        public ActionResult<IDictionary<string, string>> Post(FoodItem shoppingItem)
        {
            _foodItem.Add(shoppingItem.Type, shoppingItem.Item);
            return CreatedAtAction(nameof(FoodController.GetFood), new {foodTypeKey = shoppingItem.Type}, shoppingItem);
        }

        //// POST api/values
        //[HttpPost("{shoppingItem}")]
        //public string Post(FoodItem shoppingItem)
        //{
        //    return "Returned from POST";
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

    // public class FoodItem
    // {
    //     public string Type { get; set; }
    //     public string Item { get; set; }
    // }
}
