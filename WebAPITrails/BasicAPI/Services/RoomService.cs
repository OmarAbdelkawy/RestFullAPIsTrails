using AutoMapper;
using BasicAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace BasicAPI.Services
{
    public class RoomService : IRoomService
    {
        private readonly HotelApiDbcontext dbcontext;
        private readonly IMapper mapper;

        public RoomService(HotelApiDbcontext dbcontext , IMapper _mapper)
        {
            this.dbcontext = dbcontext;
            mapper = _mapper;
        }
        public List<RoomEntity> GetRooms()
        {
            return dbcontext.Rooms.ToList();
        }
        public Room GetRoomByID(Guid roomid)
        {
            var room = dbcontext.Rooms.SingleOrDefault(x => x.Id == roomid);
            return mapper.Map<Room>(room);
            //Room ReturnRoom = new Room()
            //{
            //    Name = room.Name,
            //    Rate = (room.Rate / 100.0m)
            //};

            //return ReturnRoom;

        }
    }
}
