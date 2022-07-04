using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiLife_API.Model
{
    [Table("appointments")]
    public class Appointment
    {
        [Key]
        public long Id { get; set; }

        public long PatientId { get; set; }

        public long DoctorId { get; set; }

        public string? Modality { get; set; }

        [Required]
        public DateTime AppointmentTime { get; set; }

    }
}
