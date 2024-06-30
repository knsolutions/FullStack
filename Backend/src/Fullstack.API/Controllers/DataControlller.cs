using Microsoft.AspNetCore.Mvc;  
using Fullstack.API.Models;
using System.Collections.Generic;  
using System.Linq;

namespace Fullstack.API.Controllers;

public class DataControlller
{
    [Route("api/[controller]")]  
    [ApiController]  
    public class DataController : ControllerBase  
    {  
        private static List<DataModel> dataStore = new List<DataModel>();  
  
        [HttpGet]  
        public ActionResult<IEnumerable<DataModel>> Get([FromQuery] string filter)  
        {  
            if (string.IsNullOrEmpty(filter))  
            {  
                return Ok(dataStore);  
            }  
  
            var filteredData = dataStore.Where(d => d.Key.Contains(filter)).ToList();  
            return Ok(filteredData);  
        }  
  
        [HttpPost]  
        public ActionResult<DataModel> Post([FromBody] DataModel data)  
        {  
            data.Id = dataStore.Count > 0 ? dataStore.Max(d => d.Id) + 1 : 1;  
            dataStore.Add(data);  
            return CreatedAtAction(nameof(GetById), new { id = data.Id }, data);  
        }  
  
        [HttpGet("{id}")]  
        public ActionResult<DataModel> GetById(int id)  
        {  
            var data = dataStore.FirstOrDefault(d => d.Id == id);  
            if (data == null)  
            {  
                return NotFound();  
            }  
            return Ok(data);  
        }  
  
        [HttpPut("{id}")]  
        public ActionResult<DataModel> Put(int id, [FromBody] DataModel updatedData)  
        {  
            var data = dataStore.FirstOrDefault(d => d.Id == id);  
            if (data == null)  
            {  
                return NotFound();  
            }  
  
            data.Key = updatedData.Key;  
            data.Value = updatedData.Value;  
            return Ok(data);  
        }  
  
        [HttpDelete("{id}")]  
        public ActionResult Delete(int id)  
        {  
            var data = dataStore.FirstOrDefault(d => d.Id == id);  
            if (data == null)  
            {  
                return NotFound();  
            }  
  
            dataStore.Remove(data);  
            return NoContent();  
        }  
    }

}
