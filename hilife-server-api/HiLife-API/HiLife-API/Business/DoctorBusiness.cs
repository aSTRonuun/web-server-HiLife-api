using AutoMapper;
using HiLife_API.Data.ValueObjects;
using HiLife_API.Model;
using HiLife_API.Repository;

namespace HiLife_API.Business
{
    public class DoctorBusiness
    {
        private IDoctorRepository _repository;
        private IMapper _mapper;

        public DoctorBusiness(IDoctorRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentException(nameof(repository));
            _mapper = mapper;
        }

        public async Task<List<DoctorVO>> FindAll()
        {
            var doctors = await _repository.FindAll();
            return _mapper.Map<List<DoctorVO>>(doctors);
        }

        public async Task<DoctorVO> FindById(long id)
        {
            var doctor = await _repository.FindById(id);
            return _mapper.Map<DoctorVO>(doctor);

        }

        public async Task<DoctorVO> Create(DoctorVO vo)
        {
            Doctor doctor = _mapper.Map<Doctor>(vo);
            if (_repository.Exist(doctor.CRM)) return null;

            var result = await _repository.Create(doctor);
            if (result == null) return null;
            return _mapper.Map<DoctorVO>(result);
        }

        public async Task<bool> Delete(DoctorVO vo)
        {
            Doctor doctor = _mapper.Map<Doctor>(vo);
            var result = await _repository.Delete(doctor.Id);
            if (!result) return false;
            return true;
        }

        public async Task<DoctorVO> Update(DoctorVO vo)
        {
            Doctor doctor = _mapper.Map<Doctor>(vo);
            var result = await _repository.Update(doctor);
            if (result == null) return null;
            return _mapper.Map<DoctorVO>(result);
        }
    }
}
