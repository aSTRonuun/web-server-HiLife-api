

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
            config.CreateMap<PatientVO, Patient>();
            config.CreateMap<Patient, PatientVO>();
            config.CreateMap<DoctorVO, Doctor>();
            config.CreateMap<Doctor, DoctorVO>();
        });
        return mappingConfig;
    }
}
