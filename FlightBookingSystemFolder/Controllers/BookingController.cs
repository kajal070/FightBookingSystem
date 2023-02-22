 using Microsoft.AspNetCore.Mvc;
using FlightBookingSystemFolder.Repository;
using FlightBookingSystemFolder.Models;
using FlightBookingSystemFolder.DTO.Booking;
using FlightBookingSystemFolder.Helper;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;

[Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
         private readonly IRepositoryBase<Booking> interfaceobj = null;
         private readonly IMapper mapper;
       
       public BookingController(IRepositoryBase<Booking> interfaceobj, IMapper mapper)
        {
            this.interfaceobj = interfaceobj;
            this.mapper=mapper;
        }
        [Authorize]
        [HttpPost]
        [Route("Booking")]
        public async Task<IActionResult> AddBooking([FromBody]BookingDto book)
        {
                var BOOK=mapper.Map<Booking>(book);
                 BOOK.ReferenceNo=21;
                BOOK.FlightId=2;
               /* var Book = new Booking();
                Book.Age=book.Age;
                Book.City=book.City;
                Book.Country = book.Country;
                Book.Passenger_Name=book.Passenger_Name;
                Book.PhoneNumber= book.PhoneNumber;
                Book.Gender=book.Gender;
                Book.Passport_No=book.Passport_No;
                //Random s = new Random();
                Book.Email=book.Email;*/
                interfaceobj.InsertModel(BOOK);
             return Ok("Successfully Booked!");
             //else
            // return StatusCode(StatusCodes.Status500InternalServerError,"Something Went Wrong");
            
        }
        // [Authorize]
        [HttpGet]
        [Route("Booking_Information")]
        public async Task<IActionResult> GetAllData()
        {
            var result =  interfaceobj.GetModel();

            return Ok(result);
        }

    }
    