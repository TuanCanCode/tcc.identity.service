using Microsoft.AspNetCore.Mvc;

namespace Tcc.Identity.Api.Controllers
{
    /// <summary>
    /// PingController
    /// </summary>
    [Route("api/ping")]
    [ApiController]
    public class PingController : ControllerBase
    {

        /// <summary>
        /// Ping
        /// </summary>
        /// <returns>Pong</returns>
        [HttpGet]
        public string Ping()
        {
            return "Pong";
        }
    }
}
