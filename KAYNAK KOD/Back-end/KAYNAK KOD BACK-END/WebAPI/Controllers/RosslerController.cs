using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RosslerController : ControllerBase
    {

        private readonly LorenzService _lorenzService;

        public RosslerController()
        {
            _lorenzService = new LorenzService();
        }

        [HttpPost]
        [Route("nextstate")]
        public IActionResult GetNextState([FromBody] double[] currentState)
        {
            if (currentState.Length != 3)
            {
                return BadRequest("State must contain exactly 3 values.");
            }

            var nextState = _lorenzService.ComputeNextState(currentState);
            return Ok(nextState);
        }
    }
}
