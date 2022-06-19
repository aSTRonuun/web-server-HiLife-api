

using HiLife_API.Data.ValueObjects;

namespace HiLife_API.Repository;

public interface IPatientRepository
{
    Task<IEnumerable<PatientVO>> FindAll();

    Task<PatientVO> FindById(long id);

    Task<PatientVO> Create(PatientVO vo);

    Task<PatientVO> Update(PatientVO vo);

    Task<bool> Delete(long id);
}
