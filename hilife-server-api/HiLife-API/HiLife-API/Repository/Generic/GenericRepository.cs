using AutoMapper;
using HiLife_API.Model;
using HiLife_API.Model.Base;
using HiLife_API.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace HiLife_API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly MySQLContext _context;
        private IMapper _mapper;
        private DbSet<T> dataset;

        public GenericRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            dataset = _context.Set<T>();
        }

        public Task<T> Create(T vo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> FindById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Update(T vo)
        {
            throw new NotImplementedException();
        }
    }
}
