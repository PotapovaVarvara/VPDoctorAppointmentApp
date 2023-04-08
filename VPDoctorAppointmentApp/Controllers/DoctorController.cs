using DomainModels.Doctor;
using DomainModels.Schedule;
using Dto;
using Dto.FormControl;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Repository.Doctor;
using ServicesBLL.Doctor;

namespace VPDoctorAppointmentApp.Controllers;

[ApiController]
[Route("api/[controller]")]
//[Route("Doctor")]
//
//[Route("[controller]")]
public class DoctorController: ControllerBase
{
    private readonly IDoctorService _doctorService;
        
    public DoctorController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }
    
    [HttpPost("Add")]
    public async Task Add([FromBody] AddDoctorDto dto)
    {
        await _doctorService.AddAsync(dto);
    }
    
    [HttpGet("GetAll")]
    public async Task GetAll()
    {
        await _doctorService.GetAll();
    }

    [HttpGet("GetDoctorSpecialitySelect")]
    public IEnumerable<SelectItem> GetDoctorSpecialitySelect()
    {
        return Enum.GetValues(typeof(DoctorSpeciality)).Cast<DoctorSpeciality>()
            .Select(_ => new SelectItem {Name = (int) _, Text = _.Description()});
    }

    [HttpGet("GetScheduleDays")]
    public IEnumerable<SelectItem> GetScheduleDays()
    {
        return Enum.GetValues(typeof(Day)).Cast<Day>()
            .Select(_ => new SelectItem {Name = (int) _, Text = _.Description()});
    }
}