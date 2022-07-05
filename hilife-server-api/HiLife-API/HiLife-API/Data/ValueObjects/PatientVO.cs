namespace HiLife_API.Data.ValueObjects;

public class PatientVO
{
    public long Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Name { get; set; }
    public string? Cep { get; set; }
    public string? Address { get; set; }
    public string? ImageURL { get; set; }

    public List<AppointmentVO>? Appointments { get; set; }
}
