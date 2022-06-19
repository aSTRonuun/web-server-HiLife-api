using AutoMapper;
using HiLife_API.Data.ValueObjects;
using HiLife_API.Model;
using HiLife_API.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace HiLife_API.Repository;

public class PatientRepository : IPatientRepository
{
    private readonly MySQLContext _context;
    private IMapper _mapper;

    public PatientRepository(MySQLContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PatientVO>> FindAll()
    {
        List<Patient> patients = await _context.Patients.ToListAsync();
        return _mapper.Map<List<PatientVO>>(patients);
    }

    public async Task<PatientVO> FindById(long id)
    {
        Patient patient = await _context.Patients.Where(p => p.Id == id).FirstOrDefaultAsync();
        return _mapper.Map<PatientVO>(patient);
    }

    public async Task<PatientVO> Create(PatientVO vo)
    {
        Patient patient = _mapper.Map<Patient>(vo);
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
        return _mapper.Map<PatientVO>(patient);
    }

    public async Task<PatientVO> Update(PatientVO vo)
    {
        Patient patient = _mapper.Map<Patient>(vo);
        _context.Patients.Update(patient);
        await _context.SaveChangesAsync();
        return _mapper.Map<PatientVO>(patient);
    }

    public async Task<bool> Delete(long id)
    {
        try
        {
            Patient patient = await _context.Patients.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (patient == null) return false;
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex) { return false; }
    }

    

    
}
