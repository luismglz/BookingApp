using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiBooking.Models;
using Xamarin.Forms;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiBooking.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LodgingController : ControllerBase
    {
        // GET: api/<LodgingController>
        [HttpGet]
        public ResponseModel Get() {
            return new LodgingModel().GetAll();
        }

        // GET api/<LodgingController>/5
        [HttpGet("{id}")]
        public ResponseModel Get(int id) {
            //return new LodgingModel().Get(id);
            return new LodgingModel().Get(id);
        }

        // POST api/<LodgingController>
        [HttpPost]
        public ResponseModel Post([FromBody] LodgingModel lodging) {
            return new LodgingModel().Insert(lodging);
        }

        // PUT api/<LodgingController>/5
        [HttpPut]
        public ResponseModel Put([FromBody] LodgingModel lodging) {
            return lodging.Update(lodging);
        }

        // DELETE api/<LodgingController>/5
        [HttpDelete("{id}")]
        public ResponseModel Delete(int id) {
            return new LodgingModel().Delete(id);
        }
    }
}
