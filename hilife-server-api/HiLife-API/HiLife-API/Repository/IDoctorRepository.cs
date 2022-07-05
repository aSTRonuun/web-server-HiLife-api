using HiLife_API.Model;

namespace HiLife_API.Repository;

public interface IDoctorRepository
{

    Task<IEnumerable<Doctor>> FindAll();

    Task<Doctor> FindById(long id);

    Task<Doctor> Create(Doctor doctor);

    Task<Doctor> Update(Doctor doctor);

    Task<bool> Delete(long id);

    bool Exist(long crm);

    Task<Doctor> ValidateCredentials(Doctor doctor);

    Task<Doctor> RefreshUserInfo(Doctor doctor);

    Task<IEnumerable<AvailableTime>> FindAllAvailableTimeByIdDoctor(long id);

    Task<AvailableTime> CreateAvailableTime(AvailableTime availableTime);
}
