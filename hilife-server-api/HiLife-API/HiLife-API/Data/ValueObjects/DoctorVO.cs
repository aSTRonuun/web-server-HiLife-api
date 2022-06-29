﻿namespace HiLife_API.Data.ValueObjects
{
    public class DoctorVO
    {
        public long Id { get; set; }
        public string? HospitalName { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public int CRM { get; set; }
        public List<AvailableTimeVO> AvailableTimes { get; set; }
    }

    public class AvailableTimeVO
    {
        public long DoctorId { get; set; }
        public DateTime? Time { get; set; }
    }

}
