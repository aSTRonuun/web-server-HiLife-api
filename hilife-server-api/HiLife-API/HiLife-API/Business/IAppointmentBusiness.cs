using HiLife_API.Data.ValueObjects;

namespace HiLife_API.Business;

public interface IAppointmentBusiness
{
    Task<List<AppointmentVO>> FindAll();

    Task<AppointmentVO> FindById(long id);

    Task<AppointmentVO> Create(AppointmentVO appointment);

    Task<AppointmentVO> Update(AppointmentVO appointment);

    Task<bool> Delete(long id);
}
