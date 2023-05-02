using AutoMapper;
using BasicAPI.Models;
using BasicAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService roomService;
        private readonly IMapper mapper;

        public RoomsController(IRoomService roomService , IMapper _mapper)
        {
            this.roomService = roomService;
            mapper = _mapper;
        }
        [HttpGet(Name = nameof(GetRooms))]
        [ApiVersion("2")]
        public ActionResult<RoomEntity> GetRooms()
        {
            return Ok(roomService.GetRooms());
        }
        [HttpGet("{roomid}", Name = nameof(GetRoomByID))]
        [ApiVersion("2")]
        public ActionResult<Room> GetRoomByID(Guid roomid)
        {
            return Ok(roomService.GetRoomByID(roomid));
        }

    }

}
