﻿using HiLife_API.Business;
using HiLife_API.Data.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiLife_API.Controller;

[Route("api/[controller]")]
[ApiController]
public class DoctorController : ControllerBase
{
    private IDoctorBusiness _business;
    public DoctorController(IDoctorBusiness business)
    {
        _business = business;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DoctorVO>>> FindAll()
    {
        var doctors = await _business.FindAll();

        return Ok(doctors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DoctorVO>> FindById(long id)
    {
        var doctor = await _business.FindById(id);
        if (doctor == null) return NotFound();

        return Ok(doctor);
    }

    [HttpGet("{id}/availableTimes")]
    public async Task<ActionResult<IEnumerable<AvailableTimeVO>>> FindAllAvailableTimeByIdDoctor(long id)
    {
        var availables = await _business.FindAllAvailableTimeByIdDoctor(id);
        if (availables == null) return NotFound();

        return Ok(availables);
    }

    [HttpGet("{id}/appointments")]
    public async Task<ActionResult<IEnumerable<AppointmentVO>>> FindAllAppointmentsByIdDoctor(long id)
    {
        var appointments = await _business.FindAllAppointmentsByIdDoctor(id);
        if (appointments == null) return NotFound();

        return Ok(appointments);
    }

    [HttpPost]
    public async Task<ActionResult<DoctorVO>> Create(DoctorVO vo)
    {
        if (vo == null) return BadRequest();
        var doctor = await _business.Create(vo);
        return Ok(doctor);
    }

    [HttpPost("availableTimes")]
    public async Task<ActionResult<AvailableTimeVO>> CreateAvailableTime(AvailableTimeVO vo)
    {
        if (vo == null) return BadRequest();
        var available = await _business.CreateAvailableTime(vo);
        return Ok(available);
    }

    [HttpPut]
    public async Task<ActionResult<DoctorVO>> Update(DoctorVO vo)
    {
        if (vo == null) return BadRequest();
        var doctor = await _business.Update(vo);
        if (doctor == null) return BadRequest();
        return Ok(doctor);
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(long id)
    {
        if (id == null) return BadRequest();
        var status = await _business.Delete(id);
        if (!status) return BadRequest();
        return Ok(status);
    }



}
