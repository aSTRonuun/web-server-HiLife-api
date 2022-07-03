using HiLife_API.Model;

namespace HiLife_API.Data.ValueObjects
{
    public class AppointmentVO
    {
        public long Id { get; set; }

        public long PatientId { get; set; }

        public long DoctorId { get; set; }

        public string? Modality { get; set; }
        public DateTime AppointmentTime { get; set; }
    }
}
