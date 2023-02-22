using Microsoft.AspNetCore.Mvc;
using FlightBookingSystemFolder.Repository;
using FlightBookingSystemFolder.Models;
using Microsoft.AspNetCore.Authorization;
using FlightBookingSystemFolder.DTO;
using FlightBookingSystemFolder.DTO.Flight;
using AutoMapper;

namespace FlightBookingSystemFolder.Controllers;
[Route("api/[controller]")]
[ApiController]

public class FlightController : ControllerBase
    {
        private readonly IRepositoryBase<Flight> interfaceobj = null;
       private readonly IMapper mapper;
        public FlightController(IRepositoryBase<Flight> interfaceobj,IMapper mapper)
        {
            this.interfaceobj = interfaceobj;
            this.mapper=mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult>GetSearchFlight(DateTime date,string from,string to)
        {
           //DateTime date,string from,string to
            var result= interfaceobj.GetModel().Where(x => (x.DateAndTime.Date ==date) && (x.To == to) && (x.From ==from)).ToList();
            /*List<FlightSearchDto> list=new List<FlightSearchDto>();
           foreach( Flight f in result)
           {
            list =mapper.Map<FlightSearchDto>(f);
           }*/
            return Ok(result);
        }
         [HttpPost]
         [Route("AddFlight")]
        public async Task<IActionResult> AddPost(Flight fl)
        {
                
               interfaceobj.InsertModel(fl);
             return Ok("Successfully Added Flight!");
            
        }
        [HttpGet]
        [Route("Getflight")]
        public async Task<IActionResult> GetAllData(int id)
        {
            var result =  interfaceobj.GetModelbyID(id);
            var DATA =mapper.Map<FlightSearchDto>(result);

            return Ok(DATA);
        }
    }


