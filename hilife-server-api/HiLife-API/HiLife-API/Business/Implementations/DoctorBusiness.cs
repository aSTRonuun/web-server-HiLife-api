using AutoMapper;
using HiLife_API.Data.ValueObjects;
using HiLife_API.Model;
using HiLife_API.Repository;

namespace HiLife_API.Business.Implementations;

public class DoctorBusiness : IDoctorBusiness
{
    private IDoctorRepository _repository;
    private IAppointmentRepository _appointmentRepository;
    private IMapper _mapper;

    public DoctorBusiness(IDoctorRepository repository, IAppointmentRepository appointmentRepository, IMapper mapper)
    {
        _repository = repository ?? throw new ArgumentException(nameof(repository));
        _appointmentRepository = appointmentRepository ?? throw new ArgumentException(nameof(appointmentRepository));
        _mapper = mapper;
    }

    public async Task<List<DoctorVO>> FindAll()
    {
        var doctors = await _repository.FindAll();
        return _mapper.Map<List<DoctorVO>>(doctors);
    }

    public async Task<DoctorVO> FindById(long id)
    {
        var doctor = await _repository.FindById(id);
        return _mapper.Map<DoctorVO>(doctor);

    }

    public async Task<DoctorVO> Create(DoctorVO vo)
    {
        Doctor doctor = _mapper.Map<Doctor>(vo);
        if (_repository.Exist(doctor.CRM)) return null;

        var result = await _repository.Create(doctor);
        if (result == null) return null;
        return _mapper.Map<DoctorVO>(result);
    }

    public async Task<bool> Delete(long id)
    {
        var result = await _repository.Delete(id);
        if (!result) return false;
        return true;
    }

    public async Task<DoctorVO> Update(DoctorVO vo)
    {
        Doctor doctor = _mapper.Map<Doctor>(vo);
        var result = await _repository.Update(doctor);
        if (result == null) return null;
        return _mapper.Map<DoctorVO>(result);
    }

    public async Task<List<AvailableTimeVO>> FindAllAvailableTimeByIdDoctor(long id)
    {
        var availables = await _repository.FindAllAvailableTimeByIdDoctor(id);
        if (availables == null) return null;
        return _mapper.Map<List<AvailableTimeVO>>(availables);
    }



    public async Task<List<AppointmentVO>> FindAllAppointmentsByIdDoctor(long id)
    {
        var appointments = await _appointmentRepository.FindAllAppointmentsByIdDoctor(id);
        if (appointments == null) return null;
        return _mapper.Map<List<AppointmentVO>>(appointments);
    }

    public async Task<AvailableTimeVO> CreateAvailableTime(AvailableTimeVO vo)
    {
        var available = _mapper.Map<AvailableTime>(vo);
        await _repository.CreateAvailableTime(available);
        return _mapper.Map<AvailableTimeVO>(available);
    }
}
