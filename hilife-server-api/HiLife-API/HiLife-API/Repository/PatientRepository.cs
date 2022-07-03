using HiLife_API.Model;
using HiLife_API.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace HiLife_API.Repository;

public class PatientRepository : IPatientRepository
{
    private readonly MySQLContext _context;

    public PatientRepository(MySQLContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Patient>> FindAll()
    {
        List<Patient> patients = await _context.Patients.Include(p => p.Appointments).ToListAsync();
        return patients;
    }

    public async Task<Patient> FindById(long id)
    {
        Patient patient = await _context.Patients.Where(p => p.Id == id).FirstOrDefaultAsync();
        if (patient == null) return null;
        return patient;
    }

    public async Task<Patient> Create(Patient patient)
    {
        if (patient == null) return null;
        _context.Patients.Add(patient);
        _context.SaveChanges();
        return patient;
    }

    public async Task<Patient> Update(Patient patient)
    {
        if (patient == null) return null;

        if (!Exist(patient.Id)) return null;

        _context.Patients.Update(patient);
        await _context.SaveChangesAsync();
        return patient;
    }

    public async Task<bool> Delete(long id)
    {
        
        if (!Exist(id)) return false;
        Patient patient = await _context.Patients.Where(p => p.Id == id).FirstOrDefaultAsync();
        _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();
        return true;
    }

    public bool Exist(long id)
    {
        return _context.Patients.Any(p => p.Id == id);
    }

    public async Task<Patient> ValidateCredentials(Patient patient)
    {
        var info = await _context.Patients.FirstOrDefaultAsync(u => u.Email == patient.Email && u.Password == patient.Password);

        return info;
    }

    public async Task<Patient> RefreshUserInfo(Patient patient)
    {
        if (!Exist(patient.Id)) return null;

        var result = await _context.Patients.SingleOrDefaultAsync(p => p.Id == patient.Id);
        Console.WriteLine(result);
        if (result != null)
        {
            try
            {
                _context.Entry(result).CurrentValues.SetValues(patient);
                _context.SaveChanges();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        return result;
    }
}
