using HiLife_API.Model.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiLife_API.Model
{
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
        public int Specialty { get; set; }

        [Column("crm")]
        [Required]
        public string CRM { get; set; }
    }
}
