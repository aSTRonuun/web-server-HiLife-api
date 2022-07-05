using AutoMapper;
using HiLife_API.Data.ValueObjects;
using HiLife_API.Model;
using HiLife_API.Repository;

namespace HiLife_API.Business.Implementations;

public class AppointmentBusiness : IAppointmentBusiness
{
    private IAppointmentRepository _repository;
    private IPatientRepository _patientRepository;
    private IDoctorRepository _doctorRepository;
    private IMapper _mapper;

    public AppointmentBusiness(IAppointmentRepository repository,
        IPatientRepository patientRepository,
        IDoctorRepository doctorRepository,
        IMapper mapper)
    {
        _repository = repository;
        _patientRepository = patientRepository;
        _doctorRepository = doctorRepository;
        _mapper = mapper;
    }

    public async Task<List<AppointmentVO>> FindAll()
    {
        var appointments = await _repository.FindAll();
        return _mapper.Map<List<AppointmentVO>>(appointments);

    }

    public async Task<AppointmentVO> FindById(long id)
    {
        var appointment = await _repository.FindById(id);
        if (appointment == null) return null;
        return _mapper.Map<AppointmentVO>(appointment);
    }

    public async Task<AppointmentVO> Create(AppointmentVO vo)
    {
        Appointment appointment = _mapper.Map<Appointment>(vo);
        if (!_patientRepository.Exist(appointment.PatientId)) return null;

        var availableTimes = await _doctorRepository.FindAllAvailableTimeByIdDoctor(appointment.DoctorId);

        if (!availableTimes.Any(a => a.Time == appointment.AppointmentTime))
        {
            return null;
        }

        _repository.Create(appointment);
        return _mapper.Map<AppointmentVO>(appointment);


    }

    public async Task<AppointmentVO> Update(AppointmentVO vo)
    {
        if (vo == null) return null;

        var appointment = _mapper.Map<Appointment>(vo);
        await _repository.Update(appointment);
        return _mapper.Map<AppointmentVO>(appointment);

    }

    public async Task<bool> Delete(long id)
    {
        var result = await _repository.Delete(id);
        return result;
    }
}
