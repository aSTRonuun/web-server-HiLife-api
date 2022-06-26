using AutoMapper;
using HiLife_API.Data.ValueObjects;
using HiLife_API.Model;
using HiLife_API.Repository;

namespace HiLife_API.Business;

public class PatientBusiness : IPatientBusiness
{
    private IPatientRepository _repository;
    private IMapper _mapper;

    public PatientBusiness(IPatientRepository repository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentException(nameof(repository));
        _mapper = mapper;
    }

    public async Task<List<PatientVO>> FindAll()
    {
        var patients = await _repository.FindAll();
        return _mapper.Map<List<PatientVO>>(patients);
    }

    public async Task<PatientVO> FindById(long id)
    {
        var patient = await _repository.FindById(id);
        return _mapper.Map<PatientVO>(patient);

    }

    public async Task<PatientVO> Create(PatientVO vo)
    {
        Patient patient = _mapper.Map<Patient>(vo);
        var result = await _repository.Create(patient);
        if (result == null) return null;
        return _mapper.Map<PatientVO>(result);
    }

    public async Task<bool> Delete(PatientVO vo)
    {
        Patient patient = _mapper.Map<Patient>(vo);
        var result = await _repository.Delete(patient.Id);
        if (!result) return false;
        return true;
    }

    public async Task<PatientVO> Update(PatientVO vo)
    {
        Patient patient = _mapper.Map<Patient>(vo);
        var result = await _repository.Update(patient);
        if (result == null) return null;
        return _mapper.Map<PatientVO>(result);
    }
}
