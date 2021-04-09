using airplanereservationsystem.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace airplanereservationsystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {

  
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<Administrator> Get()
        {
            using (var context = new airplanereservationsystemContext())
            {
                //Get all Admins
                return context.Administrator.ToList();
            }
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post(JObject payload)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
