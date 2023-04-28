using BasicAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BasicAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class InfoController : Controller
    {
        private readonly HotelInfo _hotelinfowrapper;

        public InfoController(IOptions<HotelInfo> hotelinfowrapper)
        {
            _hotelinfowrapper = hotelinfowrapper.Value;
        }
        // GET: InfoController
        [HttpGet(Name = nameof(GetInfo))]
        [ProducesResponseType(200)]
        public ActionResult<HotelInfo> GetInfo()
        {
            _hotelinfowrapper.Href = Url.Link(nameof(GetInfo), null);
            return _hotelinfowrapper;
        }

    }
}
