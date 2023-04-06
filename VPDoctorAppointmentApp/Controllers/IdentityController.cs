using Microsoft.AspNetCore.Mvc;

namespace VPDoctorAppointmentApp.Controllers;

[ApiController]
[Route("[controller]")]
public class IdentityController: ControllerBase
{
    [HttpGet]
    public string Get()
    {
        return "Autorized";
    }
    
    [HttpGet]
    public string Authenticate()
    {
        return "Autorized";
    }
}