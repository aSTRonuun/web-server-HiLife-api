namespace HiLife_API.Data.ValueObjects
{
    public class DoctorVO
    {
        public long Id { get; set; }
        public string? HospitalName { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string CRM { get; set; }
    }
}
