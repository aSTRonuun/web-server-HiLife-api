using HiLife_API.Business;
using HiLife_API.Data.ValueObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HiLife_API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("Bearer")]
    public class PatientController : ControllerBase
    {
        private IPatientBusiness _business;


        public PatientController(IPatientBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientVO>>> FindAll()
        {
            var patients = await _business.FindAll();

            return Ok(patients);
        }

        

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientVO>> FindById(long id)
        {
            var patient = await _business.FindById(id);
            if (patient == null) return NotFound();

            return Ok(patient);
        }

        [HttpGet("{id}/appointments")]
        public async Task<ActionResult<IEnumerable<AppointmentVO>>> FindAllAppointmentsByIdPatient(long id)
        {
            var appointments = await _business.FindAllAppointmentsByIdPatient(id);
            if (appointments == null) return NotFound();
            return Ok(appointments);

        }

        [HttpPost]
        public async Task<ActionResult<PatientVO>> Create(PatientVO vo)
        {
            if (vo == null) return BadRequest();
            var patient = await _business.Create(vo);
            return Ok(patient);
        }

        [HttpPut]
        public async Task<ActionResult<PatientVO>> Update(PatientVO vo)
        {
            if (vo == null) return BadRequest();
            var patient = await _business.Update(vo);
            if (patient == null) return BadRequest();
            return Ok(patient);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(PatientVO vo)
        {
            if (vo == null) return BadRequest();
            var status = await _business.Delete(vo);
            if (!status) return BadRequest();
            return Ok(status);
        }

        
    }
}
