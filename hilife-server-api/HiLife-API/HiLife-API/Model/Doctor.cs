using HiLife_API.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiLife_API.Model;

public class Doctor : BaseEntity
{

    [Column("name_hospital")]
    public string? HospitalName { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("password")]
    public string Password { get; set; }

    [Column("specialty")]
    public string Specialty { get; set; }

    [Column("crm")]
    [Required]
    public int CRM { get; set; }

    public List<AvailableTime>? AvailableTimes { get; set; }

    public List<Appointment>? Appointments { get; set; }

}

[Table("availabletime")]
public class AvailableTime
{
    [Key]
    public long DoctorId { get; set; }
    public DateTime? Time { get; set; }
}
