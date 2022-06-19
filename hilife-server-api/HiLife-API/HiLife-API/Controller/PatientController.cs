using HiLife_API.Data.ValueObjects;
using HiLife_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiLife_API.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private IPatientRepository _repository;

        public PatientController(IPatientRepository repository)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientVO>>> FindAll()
        {
            var patients = await _repository.FindAll();

            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientVO>> FindById(long id)
        {
            var patient = await _repository.FindById(id);
            if (patient == null) return NotFound();

            return Ok(patient);
        }

        [HttpPost]
        public async Task<ActionResult<PatientVO>> Create(PatientVO vo)
        {
            if (vo == null) return BadRequest();
            var patient = await _repository.Create(vo);
            return Ok(patient);
        }

        [HttpPut]
        public async Task<ActionResult<PatientVO>> Update(PatientVO vo)
        {
            if (vo == null) return BadRequest();
            var patient = await _repository.Update(vo);
            return Ok(patient);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.Delete(id);
            if (!status) return BadRequest();
            return Ok(status);
        }
    }
}
