using HiLife_API.Data.ValueObjects;

namespace HiLife_API.Business
{
    public interface IDoctorBusiness
    {
        Task<List<DoctorVO>> FindAll();

        Task<DoctorVO> FindById(long id);

        Task<DoctorVO> Create(DoctorVO vo);

        Task<DoctorVO> Update(DoctorVO vo);

        Task<bool> Delete(DoctorVO vo);
    }
}
