using AutoMapper;
using HiLife_API.Data.ValueObjects;
using HiLife_API.Model;

namespace HiLife_API.Config;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config =>
        {
        config.CreateMap<PatientVO, Patient>()
            .ForMember(dest => dest.Appointments,
            opt => opt.MapFrom(src => src.Appointments));
            config.CreateMap<Patient, PatientVO>();
            config.CreateMap<Doctor, DoctorVO>()
                .ForMember(dest => dest.AvailableTimes,
                opt => opt.MapFrom(src => src.AvailableTimes.
                    Select(x => new AvailableTimeVO { Id = x.DoctorId,  Time = x.Time})));
            config.CreateMap<DoctorVO, Doctor>()
                .ForMember(dest => dest.AvailableTimes,
                opt => opt.MapFrom(src => src.AvailableTimes
                    .Select(x => new AvailableTime { DoctorId = x.Id, Time = x.Time})));
            config.CreateMap<Appointment, AppointmentVO>();
            config.CreateMap<AppointmentVO, Appointment>();
        });
        return mappingConfig;
    }
}
