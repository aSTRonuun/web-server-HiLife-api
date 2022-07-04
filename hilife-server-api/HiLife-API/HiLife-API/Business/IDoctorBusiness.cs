using HiLife_API.Data.ValueObjects;
using HiLife_API.Model;

namespace HiLife_API.Business;

public interface IDoctorBusiness
{
    Task<List<DoctorVO>> FindAll();

    Task<List<AppointmentVO>> FindAllAppointmentsByIdDoctor(long id);

    Task<DoctorVO> FindById(long id);

    Task<DoctorVO> Create(DoctorVO vo);

    Task<DoctorVO> Update(DoctorVO vo);

    Task<bool> Delete(long id);
}
