using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRooms))]
        [ApiVersion("2")]
        public IActionResult GetRooms()
        {
            throw new NotImplementedException();
            var Resp = new
            {
                href = Url.Link(nameof(GetRooms), null)
            };
            return Ok(Resp);
        }
    }
}
