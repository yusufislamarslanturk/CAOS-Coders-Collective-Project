using Business.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RosslerController : ControllerBase
    {
        [HttpPost]
        public IActionResult RosslerMethod([FromBody] RosslerParameters parameters)
        {
            double[] s = parameters.InitialState;
            double dt = parameters.Dt;
            double σ = parameters.σ;
            double β = parameters.β;
            double ρ = parameters.ρ;

            RosslerManager.RosslerMethod(s, dt, σ, β, ρ);

            return Ok(s);
        }
    }
}
