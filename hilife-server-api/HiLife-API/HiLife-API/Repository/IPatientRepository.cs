

using HiLife_API.Model;

namespace HiLife_API.Repository;

public interface IPatientRepository
{
    Task<IEnumerable<Patient>> FindAll();

    Task<Patient> FindById(long id);

    Task<Patient> Create(Patient patient);

    Task<Patient> Update(Patient patient);

    Task<bool> Delete(long id);

    bool Exist(long id);
}
