using System.ComponentModel.DataAnnotations;

namespace HiLife_API.Model
{
    public class Appointment
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public Patient Patient { get; set; }

        public long PatientId { get; set; }

        [Required]
        public Doctor Doctor { get; set; }

        public long DoctorId { get; set; }

        public string? Modality { get; set; }

        [Required]
        public DateTime AppointmentTime { get; set; }

    }
}
