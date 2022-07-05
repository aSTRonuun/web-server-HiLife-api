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
                opt => opt.MapFrom(src => src.AvailableTimes));
            config.CreateMap<DoctorVO, Doctor>()
                .ForMember(dest => dest.AvailableTimes,
                opt => opt.MapFrom(src => src.AvailableTimes));
            config.CreateMap<Appointment, AppointmentVO>();
            config.CreateMap<AppointmentVO, Appointment>();
            config.CreateMap<AvailableTime, AvailableTimeVO>().ReverseMap();
        });
        return mappingConfig;
    }
}
