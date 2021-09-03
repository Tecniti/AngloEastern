using AngloEastern.Service;
using AngloEastern.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngloEastern.Controllers
{
    [ApiController]    
    [Route("api/[controller]")]
    public class ShipController : Controller
    {
        public ShipController(IShipService shipService)
        {
            _shipService = shipService;
        }

        private   IShipService _shipService { get; }

        [HttpPost("AddNewShip")]
        public IActionResult AddNewShip([FromBody] AddShipDetailViewModel addShipDetailViewModel)
        {
            _shipService.AddShipDetail(addShipDetailViewModel);
            return Ok("ShipDetail added successfully");
        }
        [HttpGet("GetAllShipDetails")]
        public IActionResult GetAllShipDetails( )
        {
            
            return Ok(_shipService.GetAllShipDetails());
        }

        [HttpGet("GetNearestPort")]
        public IActionResult GetNerestPort(int shipID)
        {
          var result=  _shipService.GetNerestPort(shipID);
            return Ok(result);
        }
        [HttpPost("UpdateVelocity")]
        public IActionResult UpdateVelocity([FromBody] UpdateVelocityViewModel updateVelocityViewModel)
        {
            var result=_shipService.UpdateVelocity(updateVelocityViewModel);
            return Ok(result);
        }
    }
}
