using HiLife_API.Data.ValueObjects;

namespace HiLife_API.Business
{
    public interface IPatientBusiness
    {
        Task<List<PatientVO>> FindAll();

        Task<PatientVO> FindById(long id);

        Task<PatientVO> Create(PatientVO vo);

        Task<PatientVO> Update(PatientVO vo);

        Task<bool> Delete(PatientVO vo);

        Task<List<AppointmentVO>>FindAllAppointmentsByIdPatient(long id);
    }
}
