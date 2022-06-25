using HiLife_API.Model.Base;

namespace HiLife_API.Model;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> FindAll();

    Task<T> FindById(long id);

    Task<T> Create(T vo);

    Task<T> Update(T vo);

    Task<bool> Delete(long id);

    Task<bool> Exists(long id);
}
