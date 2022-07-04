using HiLife_API.Model;

namespace HiLife_API.Repository;

public interface IAppointmentRepository
{
    Task<IEnumerable<Appointment>> FindAll();

    Task<Appointment> FindById(long id);

    Task<Appointment> Create(Appointment appointment);

    Task<Appointment> Update(Appointment appointment);

    Task<bool> Delete(long id);

    bool Exist(long id);

    Task<IEnumerable<Appointment>> FindAllAppointmentsByIdPatient(long id);

    Task<IEnumerable<Appointment>> FindAllAppointmentsByIdDoctor(long id);
}
