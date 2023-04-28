using BasicAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BasicAPI
{
    public class HotelApiDbcontext : DbContext
    {
        public HotelApiDbcontext(DbContextOptions options): base(options) 
        {
            
        }
        public DbSet<RoomEntity> Rooms { get; set; }
    }
}
