using HiLife_API.Model;
using HiLife_API.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace HiLife_API.Repository;

public class DoctorRepository : IDoctorRepository
{
    private readonly MySQLContext _context;

    public DoctorRepository(MySQLContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Doctor>> FindAll()
    {
        List<Doctor> doctors = await _context.Doctors
            .Include(d => d.AvailableTimes)
            .Include(d => d.Appointments)
            .ToListAsync();

        return doctors;
    }

    public async Task<Doctor> FindById(long id)
    {
        Doctor doctor = await _context.Doctors
            .Include(d => d.AvailableTimes)
            .Include(d => d.Appointments)
            .Where(d => d.Id == id).FirstOrDefaultAsync();

        if (doctor == null) return null;
        return doctor;
    }

    public async Task<Doctor> Create(Doctor doctor)
    {
        if (doctor == null) return null;
        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync();
        return doctor;
    }

    public async Task<Doctor> Update(Doctor doctor)
    {
        if (doctor == null) return null;

        if (!Exist(doctor.CRM)) return null;

        _context.Doctors.Update(doctor);
        await _context.SaveChangesAsync();
        return doctor;
    }

    public async Task<bool> Delete(long id)
    {
        Doctor doctor = await _context.Doctors.Where(p => p.Id == id).FirstOrDefaultAsync();
        if (doctor == null) return false;
        _context.Doctors.Remove(doctor);
        await _context.SaveChangesAsync();
        return true;
    }

    public bool Exist(long crm)
    {
        return _context.Doctors.Any(p => p.CRM == crm);
    }

    public async Task<IEnumerable<AvailableTime>> FindAllAvailableTimeByIdDoctor(long id)
    {
        List<AvailableTime> availables = await _context.AvailableTimes.Where(a => a.DoctorId == id).ToListAsync();
        if (availables == null) return null;
        return availables;
    }

    public async Task<AvailableTime> CreateAvailableTime(AvailableTime availableTime)
    {
        _context.AvailableTimes.Add(availableTime);
        await _context.SaveChangesAsync();
        return availableTime;
    }

    public async Task<Doctor> ValidateCredentials(Doctor doctor)
    {
        var info = await _context.Doctors.FirstOrDefaultAsync(u => u.Email == doctor.Email && u.Password == doctor.Password);

        return info;
    }

    public Task<Doctor> RefreshUserInfo(Doctor doctor)
    {
        throw new NotImplementedException();
    } 
}
