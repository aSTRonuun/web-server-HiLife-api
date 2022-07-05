using HiLife_API.Model;
using HiLife_API.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace HiLife_API.Repository.Implementations;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly MySQLContext _context;

    public AppointmentRepository(MySQLContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Appointment>> FindAll()
    {
        List<Appointment> appointments = await _context.Appointments.ToListAsync();

        return appointments;
    }

    public async Task<Appointment> FindById(long id)
    {
        Appointment appointment = await _context.Appointments
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();

        if (appointment == null) return null;
        return appointment;
    }


    public async Task<Appointment> Create(Appointment appointment)
    {
        _context.Appointments.Add(appointment);
        await _context.SaveChangesAsync();
        return appointment;
    }

    public async Task<Appointment> Update(Appointment appointment)
    {

        if (!Exist(appointment.Id)) return null;

        _context.Appointments.Update(appointment);
        await _context.SaveChangesAsync();
        return appointment;
    }

    public async Task<bool> Delete(long id)
    {
        Appointment appointment = await _context.Appointments.Where(a => a.Id == id).FirstOrDefaultAsync();
        if (appointment == null) return false;
        _context.Appointments.Remove(appointment);
        await _context.SaveChangesAsync();
        return true;
    }

    public bool Exist(long id)
    {
        return _context.Appointments.Any(p => p.Id == id);
    }

    public bool ExistAppointmentPatient(long id)
    {
        return _context.Appointments.Any(p => p.PatientId == id);
    }

    public bool ExistAppointmentDoctor(long id)
    {
        return _context.Appointments.Any(p => p.PatientId == id);
    }


    public async Task<IEnumerable<Appointment>> FindAllAppointmentsByIdPatient(long id)
    {
        if (!ExistAppointmentPatient(id)) return null;
        List<Appointment> appointments = await _context.Appointments.Where(a => a.PatientId == id).ToListAsync();
        return appointments;
    }

    public async Task<IEnumerable<Appointment>> FindAllAppointmentsByIdDoctor(long id)
    {
        if (!ExistAppointmentDoctor(id)) return null;
        List<Appointment> appointments = await _context.Appointments.Where(a => a.DoctorId == id).ToListAsync();
        return appointments;
    }
}
