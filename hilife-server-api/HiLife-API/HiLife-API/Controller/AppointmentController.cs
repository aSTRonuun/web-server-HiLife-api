using HiLife_API.Business;
using HiLife_API.Data.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiLife_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private IAppointmentBusiness _business;

        public AppointmentController(IAppointmentBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentVO>>> FindAll()
        {
            var appointments = await _business.FindAll();

            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentVO>> FindById(long id)
        {
            var appointment = await _business.FindById(id);
            if (appointment == null) return NotFound();

            return Ok(appointment);
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentVO>> Create(AppointmentVO vo)
        {
            if (vo == null) return BadRequest();
            var appointment = await _business.Create(vo);
            if (appointment == null) return BadRequest();
            return Ok(appointment);
        }

        [HttpPut]
        public async Task<ActionResult<AppointmentVO>> Update(AppointmentVO vo)
        {
            if (vo == null) return BadRequest();
            var appointment = await _business.Update(vo);
            if (appointment == null) return BadRequest();
            return Ok(appointment);
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
}
