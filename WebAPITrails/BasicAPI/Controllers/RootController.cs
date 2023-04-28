using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class RootController : ControllerBase
    {
        [HttpGet(Name = nameof(GetRoot))]
        public IActionResult GetRoot()
        {
            var Resp = new
            {
                href = Url.Link(nameof(GetRoot), null),
                rooms = new
                {
                    href = Url.Link(nameof(RoomsController.GetRooms), null),
                },
                info = new
                {
                    href = Url.Link(nameof(InfoController.GetInfo), null),
                }
            };
            return Ok(Resp);
        }
    }
}
