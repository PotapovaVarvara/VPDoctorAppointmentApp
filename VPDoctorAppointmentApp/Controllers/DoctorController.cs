using Dto;
using Microsoft.AspNetCore.Mvc;

namespace VPDoctorAppointmentApp.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Route("Doctor")]
//
//[Route("[controller]")]
public class DoctorController: ControllerBase
{
    [HttpPost("Add")]
    public string Add([FromBody] AddDoctorDto dto)
    {
        return "Autorized";
    }
  
    [HttpGet]
    public IEnumerable<string> GetDoctorSpecialitySelect()
    {
        return "Autorized";
    }
}