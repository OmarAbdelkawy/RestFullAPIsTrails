using BasicAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Policy;

namespace BasicAPI.Services
{
    public interface IRoomService
    {
        public Room GetRoomByID(Guid roomid);
        public List<RoomEntity> GetRooms();
    }
}
