using HiLife_API.Model;
using HiLife_API.Model.Context;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

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
        List<Doctor> doctors = await _context.Doctors.ToListAsync();
        return doctors;
    }

    public async Task<Doctor> FindById(long id)
    {
        Doctor doctor = await _context.Doctors.Where(d => d.Id == id).FirstOrDefaultAsync();
        if (doctor == null) return null;
        return doctor;
    }

    public async Task<Doctor> Create(Doctor doctor)
    {
        if (doctor == null) return null;
        var passCrypt = ComputeHash(doctor.Password, SHA256.Create());
        doctor.Password = passCrypt;
        _context.Doctors.Add(doctor);
        await _context.SaveChangesAsync();
        return doctor;
    }

    public async Task<Doctor> Update(Doctor doctor)
    {
        if (doctor == null) return null;

        if (!Exist(doctor.Id)) return null;

        _context.Doctors.Update(doctor);
        await _context.SaveChangesAsync();
        return doctor;
    }

    public async Task<bool> Delete(long id)
    {
        if (!Exist(id)) return false;
        Doctor doctor = await _context.Doctors.Where(p => p.Id == id).FirstOrDefaultAsync();
        _context.Doctors.Remove(doctor);
        await _context.SaveChangesAsync();
        return true;
    }

    public bool Exist(long id)
    {
        return _context.Doctors.Any(p => p.Id == id);
    }

    public Task<Doctor> RefreshUserInfo(Doctor doctor)
    {
        throw new NotImplementedException();
    }

    

    public Task<Doctor> ValidateCredentials(Doctor doctor)
    {
        throw new NotImplementedException();
    }

    private string ComputeHash(string input, SHA256 algorithm)
    {
        Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
        Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
        return BitConverter.ToString(hashedBytes);
    }
}
