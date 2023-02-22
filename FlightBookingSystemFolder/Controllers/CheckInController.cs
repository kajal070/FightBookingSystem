 using Microsoft.AspNetCore.Mvc;
using FlightBookingSystemFolder.Repository;
using FlightBookingSystemFolder.Models;
using FlightBookingSystemFolder.DTO;
using Microsoft.AspNetCore.Authorization;

    [Route("api/[controller]")]
    [ApiController]
    public class CheckInController : ControllerBase
    {
         private readonly IRepositoryBase<CheckIn> interfaceobj = null;
       
       public CheckInController(IRepositoryBase<CheckIn> interfaceobj)
        {
            this.interfaceobj = interfaceobj;
        }
        [HttpPost]
        [Route("CheckIn")]
        public async Task<IActionResult> AddPost()
        {
                var Ch = new CheckIn();
                Ch.Check_Id=1;
                Ch.Booking_id=9;
                Ch.Seat_Allocation = 22;
              interfaceobj.InsertModel(Ch);
             return Ok("Successfully CheckIn!");
             
            
        }
        

    }